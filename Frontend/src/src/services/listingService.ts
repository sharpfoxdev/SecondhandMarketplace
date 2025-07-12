import api from './apiClient';
import {
    CreateListingRequest,
    Listing,
    ListingDetail,
    UpdateListingRequest,
} from '@/types/api/listings';
import { Page } from '@/types/api/page';
import { ListingFilter } from '@/types/api/categories';

export const fetchListings = async (
    filter: ListingFilter,
    pageNumber = 1,
    pageSize = 12): Promise<Page<Listing>> => {
    const { data } = await api.post<Page<Listing>>(
        `/api/Listings/GetAll`,
        filter,
        { params: { pageNumber, pageSize } }
    );
    return data;
};

export const fetchListingById = async (id: string): Promise<ListingDetail> => {
    const { data } = await api.get<ListingDetail>(`/api/Listings/${id}`);
    return data;
};

export const fetchListingsByUser = async (): Promise<Listing[]> => {
    const { data } = await api.get<Listing[]>('/api/Listings/GetByUser');
    return data;
};

export const createListing = async (
    payload: CreateListingRequest
): Promise<Listing> => {
    const { data } = await api.post<Listing>('/api/Listings', payload);
    return data;
};

export const updateListing = async (
    id: string,
    payload: UpdateListingRequest
): Promise<Listing> => {
    const { data } = await api.put<Listing>(`/api/Listings/${id}`, payload);
    return data;
};

export const deleteListing = async (id: string): Promise<Listing> => {
    const { data } = await api.delete<Listing>(`/api/Listings/${id}`);
    return data;
};