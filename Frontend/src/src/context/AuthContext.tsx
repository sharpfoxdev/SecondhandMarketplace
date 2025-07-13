'use client';
import React, {
    createContext,
    useState,
    useEffect,
    useContext,
    ReactNode,
} from 'react';
import { decodeToken, removeToken, saveToken } from '@/services/tokenService';
import { loginUser } from '@/services/authService';
import { LoginResponse } from '@/types/api/auth';
import { useRouter } from 'next/navigation';

interface AuthUser {
    id: string;
    nickname: string;
    roles: string[];
}

interface AuthContextType {
    user: AuthUser | null;
    loading: boolean;
    login: (username: string, password: string) => Promise<void>;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [user, setUser] = useState<AuthUser | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const router = useRouter();

    useEffect(() => {
        const payload = decodeToken();
        if (payload && payload.exp * 1000 > Date.now()) {
            setUser({
                id: payload.sub,
                nickname: payload.nickname,
                roles: payload.roles,
            });
        }
        setLoading(false);
    }, []);

    const login = async (username: string, password: string) => {
        const res: LoginResponse = await loginUser({ username, password });
        saveToken(res.jwtToken);
        const payload = decodeToken();
        if (payload) {
            setUser({
                id: payload.sub,
                nickname: payload.nickname,
                roles: payload.roles,
            });
            router.push('/');
        }
    };

    const logout = () => {
        removeToken();
        setUser(null);
        router.push('/auth/login');
    };

    return (
        <AuthContext.Provider value={{ user, loading, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (!context) throw new Error('useAuth must be used within AuthProvider');
    return context;
};
