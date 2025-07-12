'use client';

import { useEffect, useState, useRef } from 'react';
import { useRouter } from 'next/navigation';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';
import { Message } from '@/types/api/messages';
import { fetchMessagesByConversationId } from '@/services/conversationService';
import Button from 'react-bootstrap/Button';
import { User } from '@/types/api/users';
import { fetchUserById } from '@/services/userService';

function getCurrentUserId(): string | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
    try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        return (
            payload[
                'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
            ] ||
            payload['sub'] ||
            null
        );
    } catch {
        return null;
    }
}

export default function ConversationPage({
    params,
}: {
    params: { conversationId: string };
}) {
    const { conversationId } = params;
    const router = useRouter();
    const currentUserId = getCurrentUserId();

    const [messages, setMessages] = useState<Message[]>([]);
    const [messageText, setMessageText] = useState('');
    const [otherUser, setOtherUser] = useState<User | null>(null);

    const hubRef = useRef<HubConnection | null>(null);
    const endRef = useRef<HTMLDivElement | null>(null);

    useEffect(() => {
        (async () => {
            const res = await fetchMessagesByConversationId(conversationId);
            setMessages(res);
        })();
    }, [conversationId]);

    useEffect(() => {
        if (!currentUserId) return;
        const otherId = messages.find(
            (m) => m.senderId !== currentUserId
        )?.senderId;
        if (otherId) {
            fetchUserById(otherId)
                .then((user) => setOtherUser(user))
                .catch(console.error);
        }
    }, [messages, currentUserId]);

    useEffect(() => {
        const conn = new HubConnectionBuilder()
            .withUrl(`${process.env.NEXT_PUBLIC_API_BASE_URL}/chathub`, {
                accessTokenFactory: () => localStorage.getItem('token') || '',
            })
            .withAutomaticReconnect()
            .build();

        const handleReceive = (senderId: string, msg: Message) => {
            if (msg.conversationId === conversationId) {
                setMessages((prev) => [...prev, msg]);
            }
        };

        conn.on('ReceiveMessage', handleReceive);
        conn.start()
            .then(() => conn.invoke('JoinConversation', conversationId))
            .catch(console.error);

        hubRef.current = conn;

        return () => {
            conn.off('ReceiveMessage', handleReceive);
            conn.stop().catch(console.error);
            hubRef.current = null;
        };
    }, [conversationId]);

    // scrol to bottom on new messages
    useEffect(() => {
        endRef.current?.scrollIntoView({ behavior: 'smooth' });
    }, [messages]);

    const handleSend = async () => {
        const conn = hubRef.current;
        const text = messageText.trim();
        if (!text || !conn) return;
        try {
            await conn.invoke('SendMessage', conversationId, text);
            setMessageText('');
        } catch (e) {
            console.error(e);
        }
    };

    return (
        <div className="d-flex justify-content-center mt-5">
            <div
                className="d-flex flex-column border rounded shadow-sm"
                style={{ width: '100%', maxWidth: '600px', height: '80vh' }}
            >
                {/*header*/}
                <div className="p-3 border-bottom d-flex justify-content-between align-items-center">
                    {otherUser ? (
                        <>
                            <a
                                href={`/user/${otherUser.id}`}
                                className="fw-bold text-decoration-none"
                            >
                                {otherUser.nickname}
                            </a>
                            <Button
                                variant="outline-primary"
                                size="sm"
                                onClick={() =>
                                    router.push(`/user/${otherUser.id}/review`)
                                }
                            >
                                Give Review To User
                            </Button>
                        </>
                    ) : (
                        <span>Loading…</span>
                    )}
                </div>

                {/*messages*/}
                <div className="flex-grow-1 overflow-auto p-3">
                    {messages.map((m) => (
                        <div
                            key={m.id}
                            className={`d-flex mb-2 ${
                                m.senderId === currentUserId
                                    ? 'justify-content-end'
                                    : 'justify-content-start'
                            }`}
                        >
                            <div
                                className={`p-2 rounded ${
                                    m.senderId === currentUserId
                                        ? 'bg-primary text-white'
                                        : 'bg-light'
                                }`}
                                style={{ maxWidth: '75%' }}
                            >
                                {m.content}
                                <div className="text-muted small text-end">
                                    {new Date(m.createdAt).toLocaleTimeString(
                                        'en-GB',
                                        { timeZone: 'CET' }
                                    )}
                                </div>
                            </div>
                        </div>
                    ))}
                    <div ref={endRef} />
                </div>

                {/*input bar at the bottom*/}
                <div className="p-3 border-top">
                    <div className="d-flex gap-2">
                        <textarea
                            className="form-control"
                            rows={2}
                            value={messageText}
                            onChange={(e) => setMessageText(e.target.value)}
                            placeholder="Type a message…"
                        />
                        <Button
                            onClick={handleSend}
                            disabled={!messageText.trim()}
                            variant="primary"
                        >
                            Send
                        </Button>
                    </div>
                </div>
            </div>
        </div>
    );
}
