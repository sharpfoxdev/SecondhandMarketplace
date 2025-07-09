import api from './apiClient';
import {
    CreateListingRequest,
    Listing,
    ListingDetail,
    UpdateListingRequest,
} from '@/types/api/listings';

export const fetchListings = async (): Promise<Listing[]> => {
    const { data } = await api.get<Listing[]>('/api/Listings');
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