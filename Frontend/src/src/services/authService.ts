import api from '@/services/apiClient';
import jwtDecode from 'jwt-decode';
import { LoginRequest, LoginResponse, RegisterRequest } from '@/types/api/auth';

interface TokenPayload {
    sub: string;
    nickname: string;
    roles: string[];
    exp: number;
}

export const registerUser = async (data: RegisterRequest): Promise<string> => {
    const response = await api.post<string>('/api/Auth/Register', data);
    return response.data;
};

export const loginUser = async (data: LoginRequest): Promise<LoginResponse> => {
    const response = await api.post<LoginResponse>('/api/Auth/Login', data);
    return response.data;
};
