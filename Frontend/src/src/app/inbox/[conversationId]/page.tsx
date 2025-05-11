'use client';

import { useEffect, useState, useRef } from 'react';
import { useRouter } from 'next/navigation';
import axios from 'axios';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';
import Button from 'react-bootstrap/Button';

interface MessageDto {
  id: string;
  conversationId: string;
  senderId: string;
  content: string;
  createdAt: string;
}

function getCurrentUserId(): string | null {
  const token = localStorage.getItem('token');
  if (!token) return null;
  try {
    const payload = JSON.parse(atob(token.split('.')[1]));
    return (
      payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] ||
      payload['sub'] ||
      null
    );
  } catch {
    return null;
  }
}

export default function ConversationPage({ params }: { params: { conversationId: string } }) {
  const { conversationId } = params;
  const [messages, setMessages] = useState<MessageDto[]>([]);
  const [messageText, setMessageText] = useState('');
  const [hubConnection, setHubConnection] = useState<HubConnection | null>(null);
  const endRef = useRef<HTMLDivElement | null>(null);
  const currentUserId = getCurrentUserId();

  useEffect(() => {
    const fetchMsgs = async () => {
      const token = localStorage.getItem('token');
      const res = await axios.get<MessageDto[]>(`https://localhost:7192/api/conversations/${conversationId}/messages`, {
        headers: { Authorization: `Bearer ${token}` },
      });
      setMessages(res.data);
    };
    fetchMsgs();
  }, [conversationId]);

  useEffect(() => {
    const initHub = async () => {
      const token = localStorage.getItem('token');
      const conn = new HubConnectionBuilder()
        .withUrl('https://localhost:7192/chathub', { accessTokenFactory: () => token || '' })
        .withAutomaticReconnect()
        .build();

      conn.on('ReceiveMessage', (senderId: string, msg: MessageDto) => {
        if (msg.conversationId === conversationId) {
          setMessages((prev) => [...prev, msg]);
        }
      });

      try {
        await conn.start();
        setHubConnection(conn);
        await conn.invoke('JoinConversation', conversationId);
      } catch (e) {
        console.error(e);
      }
    };
    initHub();
    return () => {
      hubConnection?.stop();
    };
  }, [conversationId]);

  useEffect(() => {
    endRef.current?.scrollIntoView({ behavior: 'smooth' });
  }, [messages]);

  const handleSend = async () => {
    if (!messageText.trim() || !hubConnection) return;
    try {
      await hubConnection.invoke('SendMessage', conversationId, messageText);
      setMessageText('');
    } catch (e) {
      console.error(e);
    }
  };

  return (
    <div className="container mt-5 d-flex flex-column" style={{ height: '100vh' }}>
      <div className="flex-grow-1 overflow-auto mb-3">
        {messages.map((m) => (
          <div
            key={m.id}
            className={`d-flex mb-2 ${
              m.senderId === currentUserId ? 'justify-content-end' : 'justify-content-start'
            }`}
          >
            <div
              className={`p-2 rounded ${
                m.senderId === currentUserId ? 'bg-primary text-white' : 'bg-light'
              }`}
            >
              {m.content}
              <div className="text-muted small">
                {new Date(m.createdAt).toLocaleTimeString()}
              </div>
            </div>
          </div>
        ))}
        <div ref={endRef} />
      </div>
      <div>
        <textarea
          className="form-control"
          rows={3}
          value={messageText}
          onChange={(e) => setMessageText(e.target.value)}
          placeholder="Type a message..."
        />
        <Button onClick={handleSend} className="mt-2" disabled={!messageText.trim()}>
          Send
        </Button>
      </div>
    </div>
  );
}