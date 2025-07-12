import api from './apiClient';
import { User } from '@/types/api/users';

export const fetchUserById = async (id: string): Promise<User> => {
    const { data } = await api.get<User>(`/api/Users/${id}`);
    return data;
};
