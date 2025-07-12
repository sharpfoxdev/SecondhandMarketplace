import api from './apiClient';
import {
    CreateListingPropertyValueRequest,
    ListingPropertyValue,
    UpdateListingPropertyValueRequest,
} from '@/types/api/listingPropertyValues';

export const fetchListingPropertyValues = async (): Promise<
    ListingPropertyValue[]
> => {
    const { data } = await api.get<ListingPropertyValue[]>(
        '/api/ListingPropertyValues'
    );
    return data;
};

export const fetchListingPropertyValueById = async (
    id: string
): Promise<ListingPropertyValue> => {
    const { data } = await api.get<ListingPropertyValue>(
        `/api/ListingPropertyValues/${id}`
    );
    return data;
};

export const createListingPropertyValue = async (
    payload: CreateListingPropertyValueRequest
): Promise<ListingPropertyValue> => {
    const { data } = await api.post<ListingPropertyValue>(
        '/api/ListingPropertyValues',
        payload
    );
    return data;
};

export const updateListingPropertyValue = async (
    id: string,
    payload: UpdateListingPropertyValueRequest
): Promise<ListingPropertyValue> => {
    const { data } = await api.put<ListingPropertyValue>(
        `/api/ListingPropertyValues/${id}`,
        payload
    );
    return data;
};

export const deleteListingPropertyValue = async (
    id: string
): Promise<ListingPropertyValue> => {
    const { data } = await api.delete<ListingPropertyValue>(
        `/api/ListingPropertyValues/${id}`
    );
    return data;
};
