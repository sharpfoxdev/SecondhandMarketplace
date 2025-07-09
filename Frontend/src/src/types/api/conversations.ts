export interface Conversation {
    id: string;
    conversationParticipants: ConversationParticipant[];
    lastUpdatedAt: string;
    createdAt: string;
}

export interface ConversationParticipant {
    conversationId: string;
    userId: string;
}

export interface CreateConversationRequest {
    recipientId: string;
}
