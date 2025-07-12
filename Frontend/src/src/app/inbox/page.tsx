'use client';

import { useEffect, useState } from 'react';
import Link from 'next/link';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';
import { fetchUserById } from '@/services/userService';
import { fetchAllConversations } from '@/services/conversationService';
import { User } from '@/types/api/users';
import { Conversation } from '@/types/api/conversations';

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

export default function InboxPage() {
    const [conversations, setConversations] = useState<Conversation[]>([]);
    const [users, setUsers] = useState<Record<string, User>>({});
    const [hubConnection, setHubConnection] = useState<HubConnection | null>(
        null
    );
    const [unread, setUnread] = useState<Record<string, boolean>>({});
    const currentUserId = getCurrentUserId();

    useEffect(() => {
        const fetchConvs = async () => {
            try {
                const res = await fetchAllConversations();
                const sorted = res.sort(
                    (a, b) =>
                        new Date(b.lastUpdatedAt).getTime() -
                        new Date(a.lastUpdatedAt).getTime()
                );

                sorted.forEach((conv) => {
                    const other = conv.conversationParticipants.find(
                        (p) => p.userId !== currentUserId
                    )?.userId;
                    if (other && !users[other]) {
                        fetchUserById(other)
                            .then((user) =>
                                setUsers((prev) => ({ ...prev, [other]: user }))
                            )
                            .catch(console.error);
                    }
                    conv.lastUpdatedAt = new Date(
                        conv.lastUpdatedAt
                    ).toLocaleString();
                });
                setConversations(sorted);
            } catch (err) {
                console.error('Failed to load conversations', err);
            }
        };

        fetchConvs();
    }, [currentUserId, users]);

    useEffect(() => {
        const initHub = async () => {
            const token = localStorage.getItem('token');
            const conn = new HubConnectionBuilder()
                .withUrl(`${process.env.NEXT_PUBLIC_API_BASE_URL}/chathub`, {
                    accessTokenFactory: () => token || '',
                })
                .withAutomaticReconnect()
                .build();

            conn.on('ReceiveMessage', (senderId: string, msg: any) => {
                // if new message for existing conversation
                const convId = msg.conversationId as string;
                setConversations((prev) => {
                    const idx = prev.findIndex((c) => c.id === convId);
                    if (idx === -1) return prev;
                    const updated = [...prev];
                    updated[idx].lastUpdatedAt = new Date().toLocaleString();
                    // move to the top
                    const [conv] = updated.splice(idx, 1);
                    return [conv, ...updated];
                });
                setUnread((u) => ({ ...u, [msg.conversationId]: true }));
            });

            try {
                await conn.start();
                setHubConnection(conn);
                conversations.forEach((c) =>
                    conn.invoke('JoinConversation', c.id)
                );
            } catch (e) {
                console.error(e);
            }
        };
        initHub();
        return () => {
            hubConnection?.stop();
        };
    }, [conversations]);

    return (
        <div className="container mt-5">
            <h2 className="mb-4">Inbox</h2>

            <div className="list-group">
                {conversations.map((conv) => {
                    const otherId = conv.conversationParticipants.find(
                        (p) => p.userId !== currentUserId
                    )?.userId;
                    const name = otherId
                        ? users[otherId]?.nickname || otherId
                        : '-';
                    const isUnread = !!unread[conv.id];

                    return (
                        <Link
                            key={conv.id}
                            href={`/inbox/${conv.id}`}
                            className={`
            list-group-item 
            list-group-item-action 
            d-flex justify-content-between align-items-center
            ${isUnread ? 'fw-bold bg-light' : 'text-body'}
            text-decoration-none
          `}
                        >
                            <span>{name}</span>
                            <small className="text-muted">
                                {new Date(conv.lastUpdatedAt).toLocaleString()}
                            </small>
                        </Link>
                    );
                })}
            </div>
        </div>
    );
}
