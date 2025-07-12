import api from './apiClient';
import {
    CreateListingPropertyRequest,
    ListingProperty,
    ListingPropertyDetail,
    UpdateListingPropertyRequest,
} from '@/types/api/listingProperties';

import { CreatePropertyValueInsidePropertyRequest } from '@/types/api/listingPropertyValues';

export const fetchListingProperties = async (): Promise<
    ListingPropertyDetail[]
> => {
    const { data } = await api.get<ListingPropertyDetail[]>(
        '/api/ListingProperties'
    );
    return data;
};

export const fetchListingPropertyById = async (
    id: string
): Promise<ListingPropertyDetail> => {
    const { data } = await api.get<ListingPropertyDetail>(
        `/api/ListingProperties/${id}`
    );
    return data;
};

export const createListingProperty = async (
    payload: CreateListingPropertyRequest
): Promise<ListingProperty> => {
    const { data } = await api.post<ListingProperty>(
        '/api/ListingProperties',
        payload
    );
    return data;
};

export const updateListingProperty = async (
    id: string,
    payload: UpdateListingPropertyRequest
): Promise<ListingProperty> => {
    const { data } = await api.put<ListingProperty>(
        `/api/ListingProperties/${id}`,
        payload
    );
    return data;
};

export const deleteListingProperty = async (
    id: string
): Promise<ListingProperty> => {
    const { data } = await api.delete<ListingProperty>(
        `/api/ListingProperties/${id}`
    );
    return data;
};

export const addPropertyValuesToProperty = async (
    id: string,
    propertyValues: CreatePropertyValueInsidePropertyRequest[]
): Promise<ListingPropertyDetail> => {
    const { data } = await api.post<ListingPropertyDetail>(
        `/api/ListingProperties/AddPropertyValues/${id}`,
        propertyValues
    );
    return data;
};
