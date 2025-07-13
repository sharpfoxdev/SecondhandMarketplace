import api from './apiClient';
import { CreateReviewRequest, Review } from '@/types/api/reviews';
import { Page } from '@/types/api/page';

export const fetchReviewsByReviewee = async (
    revieweeId: string,
    pageNumber = 1,
    pageSize = 20
): Promise<Page<Review>> => {
    const { data } = await api.get<Page<Review>>(
        `/api/Reviews/byReviewee/${revieweeId}`,
        { params: { pageNumber, pageSize } }
    );
    return data;
};

export const createReview = async (
    payload: CreateReviewRequest
): Promise<Review> => {
    const { data } = await api.post<Review>('/api/Reviews', payload);
    return data;
};