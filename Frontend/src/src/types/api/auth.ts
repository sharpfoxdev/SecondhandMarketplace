export interface ApplicationUser {}

export interface LoginRequest {
    username: string;
    password: string;
}

export interface LoginResponse {
    jwtToken: string;
}

export interface RegisterRequest {
    username: string;
    nickname: string;
    password: string;
}
