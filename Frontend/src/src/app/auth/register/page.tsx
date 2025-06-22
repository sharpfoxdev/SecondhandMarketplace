'use client';

import { useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';

export default function Register() {
    const [username, setUsername] = useState('');
    const [nickname, setNickname] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');
    const router = useRouter();

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        try {
            const response = await axios.post('https://localhost:7192/api/Auth/Register', {
                username,
                nickname,
                password
            });
            setSuccess('Registration successful! Please login.');
            router.push('/auth/login');
        } catch (error) {
            setError('Registration failed. Try again.');
        }
    };

    return (
        <div className="container mt-5">
            <h1 className="text-center">Register</h1>
            <form onSubmit={handleSubmit}>
                {error && <p className="text-danger">{error}</p>}
                {success && <p className="text-success">{success}</p>}
                <div className="form-group">
                    <label htmlFor="username">Email</label>
                    <input
                        type="email"
                        className="form-control"
                        id="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="username">Nickname</label>
                    <input
                        type="text"
                        className="form-control"
                        id="nickname"
                        value={nickname}
                        onChange={(e) => setNickname(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        className="form-control"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary mt-3">
                    Register
                </button>
            </form>
        </div>
    );
}
