import api from './apiClient';
import {
    Conversation,
    CreateConversationRequest,
} from '@/types/api/conversations';
import { Message } from '@/types/api/messages';

export const createConversation = async (
    payload: CreateConversationRequest
): Promise<Conversation> => {
    const { data } = await api.post<Conversation>(
        '/api/Conversations',
        payload
    );
    return data;
};

export const fetchAllConversations = async (): Promise<Conversation[]> => {
    const { data } = await api.get<Conversation[]>('/api/Conversations');
    return data;
};

export const fetchConversationById = async (
    conversationId: string
): Promise<Conversation> => {
    const { data } = await api.get<Conversation>(
        `/api/Conversations/${conversationId}`
    );
    return data;
};

export const fetchMessagesByConversationId = async (
    conversationId: string
): Promise<Message[]> => {
    const { data } = await api.get<Message[]>(
        `/api/Conversations/${conversationId}/messages`
    );
    return data;
};
