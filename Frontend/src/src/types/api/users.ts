export interface User {
    id: string;
    nickname: string;
    lastLoggedIn: string;
}

export interface UserDetail extends User {
    roles: string[];
}
