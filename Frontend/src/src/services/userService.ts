import api from './apiClient';
import { User, UserDetail } from '@/types/api/users';

export const fetchUserById = async (id: string): Promise<User> => {
    const { data } = await api.get<User>(`/api/Users/${id}`);
    return data;
};

export const fetchUserDetail = async (id: string): Promise<UserDetail> => {
    const { data } = await api.get<UserDetail>(`/api/Users/${id}/detail`);
    return data;
};

export const deleteUser = async (id: string): Promise<void> => {
    await api.delete(`/api/Users/${id}`);
};

export const addAdminRole = async (id: string): Promise<UserDetail> => {
    const { data } = await api.post<UserDetail>(`/api/Users/${id}/roles/admin`);
    return data;
};

export const removeAdminRole = async (id: string): Promise<UserDetail> => {
    const { data } = await api.delete<UserDetail>(`/api/Users/${id}/roles/admin`);
    return data;
};
