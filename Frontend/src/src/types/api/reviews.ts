import { User } from './users';
export interface CreateReviewRequest {
    revieweeId: string;
    reviewText: string;
}

export interface Review {
    id: string;
    reviewer: User;
    revieweeId: string;
    reviewText: string;
    createdAt: string;
}
