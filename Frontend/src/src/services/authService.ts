import api from '@/services/apiClient';
import { LoginRequest, LoginResponse, RegisterRequest } from '@/types/api/auth';

export const registerUser = async (data: RegisterRequest): Promise<string> => {
    const response = await api.post<string>('/api/Auth/Register', data);
    return response.data;
};

export const loginUser = async (data: LoginRequest): Promise<LoginResponse> => {
    const response = await api.post<LoginResponse>('/api/Auth/Login', data);
    return response.data;
};
