import api from './apiClient';
import { Image, AddImageRequest } from '@/types/api/images';

export const fetchImages = async (): Promise<Image[]> => {
    const { data } = await api.get<Image[]>('/api/Images');
    return data;
};

export const fetchImageById = async (id: string): Promise<Image> => {
    const { data } = await api.get<Image>(`/api/Images/${id}`);
    return data;
};

export const uploadImage = async (payload: AddImageRequest): Promise<Image> => {
    const formData = new FormData();
    formData.append('file', payload.file);
    formData.append('listingId', payload.listingId);

    const { data } = await api.post<Image>('/api/Images/Upload', formData, {
        headers: { 'Content-Type': 'multipart/form-data' },
    });
    return data;
};

export const deleteImage = async (id: string): Promise<Image> => {
    const { data } = await api.delete<Image>(`/api/Images/${id}`);
    return data;
};
