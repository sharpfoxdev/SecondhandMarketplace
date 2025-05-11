'use client';

import { useEffect, useState } from 'react';
import Link from 'next/link';
import axios from 'axios';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';

interface ConversationDto {
  id: string;
  conversationParticipants: { conversationId: string; userId: string }[];
  createdAt: string;
  lastUpdatedAt: string;
}

interface UserDto {
  id: string;
  userName: string;
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

export default function InboxPage() {
  const [conversations, setConversations] = useState<ConversationDto[]>([]);
  const [users, setUsers] = useState<Record<string, UserDto>>({});
  const [hubConnection, setHubConnection] = useState<HubConnection | null>(null);
  const [unread, setUnread] = useState<Record<string, boolean>>({});
  const currentUserId = getCurrentUserId();

  useEffect(() => {
    const fetchConvs = async () => {
      const token = localStorage.getItem('token');
      const res = await axios.get<ConversationDto[]>('https://localhost:7192/api/conversations', {
        headers: { Authorization: `Bearer ${token}` },
      });
      const sorted = res.data.sort(
        (a, b) => new Date(b.lastUpdatedAt).getTime() - new Date(a.lastUpdatedAt).getTime()
      );
      setConversations(sorted);

      sorted.forEach((conv) => {
        const other = conv.conversationParticipants.find((p) => p.userId !== currentUserId)?.userId;
        if (other && !users[other]) {
          axios
            .get<UserDto>(`https://localhost:7192/api/users/${other}`, {
              headers: { Authorization: `Bearer ${token}` },
            })
            .then((r) => setUsers((u) => ({ ...u, [other]: r.data })))
            .catch(console.error);
        }
      });
    };

    fetchConvs();
  }, []);

  useEffect(() => {
    const initHub = async () => {
      const token = localStorage.getItem('token');
      const conn = new HubConnectionBuilder()
        .withUrl('https://localhost:7192/chathub', { accessTokenFactory: () => token || '' })
        .withAutomaticReconnect()
        .build();

      conn.on('ReceiveMessage', (senderId: string, msg: any) => {
        // if new message for existing conversation
        const convId = msg.conversationId as string;
        setConversations((prev) => {
          const idx = prev.findIndex((c) => c.id === convId);
          if (idx === -1) return prev;
          const updated = [...prev];
          updated[idx].lastUpdatedAt = new Date().toISOString();
          // move to top
          const [conv] = updated.splice(idx, 1);
          return [conv, ...updated];
        });
        setUnread((u) => ({ ...u, [msg.conversationId]: true }));
      });

      try {
        await conn.start();
        setHubConnection(conn);
        conversations.forEach((c) => conn.invoke('JoinConversation', c.id));
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
      <h2>Inbox</h2>
      <ul className="list-group">
        {conversations.map((conv) => {
          const other = conv.conversationParticipants.find((p) => p.userId !== currentUserId)?.userId;
          const name = other ? users[other]?.userName || other : '—';
          const isUnread = unread[conv.id];
          return (
            <li
              key={conv.id}
              className={`list-group-item d-flex justify-content-between ${
                isUnread ? 'fw-bold' : ''
              }`}
            >
              <Link href={`/inbox/${conv.id}`}>{name}</Link>
              <small>{new Date(conv.lastUpdatedAt).toLocaleString()}</small>
            </li>
          );
        })}
      </ul>
    </div>
  );
}

