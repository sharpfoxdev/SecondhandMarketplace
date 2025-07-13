import api from './apiClient';
import { jwtDecode } from 'jwt-decode';

interface TokenPayload {
    sub: string;
    nickname: string;
    roles: string[];
    exp: number;
}

export const saveToken = (token: string): void => {
    localStorage.setItem('token', token);
};

export const getToken = (): string | null => {
    return localStorage.getItem('token');
};

export const removeToken = (): void => {
    localStorage.removeItem('token');
};

export const decodeToken = (): TokenPayload | null => {
    const token = getToken();
    if (!token) return null;
    try {
        const raw: any = jwtDecode(token);
        const sub = raw[
            'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'
        ] as string;
        const nickname = (raw.nickname ?? raw['nickname']) as string;
        const rolesRaw =
            raw['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        const roles = Array.isArray(rolesRaw) ? rolesRaw : [rolesRaw];
        const exp = raw.exp as number;

        return { sub, nickname, roles, exp };
    } catch {
        return null;
    }
};
