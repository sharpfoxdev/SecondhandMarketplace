import api from './apiClient';
import { City } from '@/types/api/cities';

export const fetchCities = async (filter?: string): Promise<City[]> => {
    const { data } = await api.get<City[]>('/api/Cities', {
        params: filter ? { filter } : undefined,
    });
    return data;
};
