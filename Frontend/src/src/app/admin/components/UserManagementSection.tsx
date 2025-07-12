import React, { useState, ChangeEvent } from 'react';
import {
    fetchUserDetail,
    addAdminRole,
    removeAdminRole,
    deleteUser,
} from '@/services/userService';
import { UserDetail } from '@/types/api/users';

export default function UserManagementSection(): JSX.Element {
    const [id, setId] = useState<string>('');
    const [user, setUser] = useState<UserDetail | null>(null);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    const handleSearch = async () => {
        if (!id.trim()) {
            setError('Please enter a user ID');
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const data = await fetchUserDetail(id);
            setUser(data);
        } catch (err: any) {
            setUser(null);
            setError(err.message || 'User not found');
        } finally {
            setLoading(false);
        }
    };

    const handleDelete = async (userId: string) => {
        if (!window.confirm('Are you sure you want to delete this user?')) return;
        try {
            await deleteUser(userId);
            setUser(null);
            setId('');
            alert('User deleted successfully');
        } catch (err: any) {
            alert(err.message || 'Delete failed');
        }
    };

    const handleAddAdmin = async (userId: string) => {
        try {
            const data = await addAdminRole(userId);
            setUser(data);
            alert('Admin role added');
        } catch (err: any) {
            alert(err.message || 'Add admin role failed');
        }
    };

    const handleRemoveAdmin = async (userId: string) => {
        try {
            const data = await removeAdminRole(userId);
            setUser(data);
            alert('Admin role removed');
        } catch (err: any) {
            alert(err.message || 'Remove admin role failed');
        }
    };

    const onIdChange = (e: ChangeEvent<HTMLInputElement>) => {
        setId(e.target.value);
    };

    return (
        <div className="card mb-4">
            <div className="card-header">
                <h5 className="mb-0">Manage User by ID</h5>
            </div>
            <div className="card-body">
                <div className="input-group mb-3">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Enter user ID"
                        value={id}
                        onChange={onIdChange}
                    />
                    <button
                        className="btn btn-secondary"
                        onClick={handleSearch}
                        disabled={loading}
                    >
                        {loading ? 'Searching...' : 'Search'}
                    </button>
                </div>
                {error && <div className="text-danger mb-3">{error}</div>}
                {user && (
                    <div className="d-flex align-items-center">
                        <span className="text-truncate flex-grow-1 me-3">
                            <a
                                href={`/users/${user.id}`}
                                className="fw-bold text-decoration-none"
                                style={{ display: 'inline-block', maxWidth: '100%' }}
                            >
                                {user.nickname}
                            </a>
                        </span>
                        <div className="flex-shrink-0">
                            <button
                                className="btn btn-danger me-2"
                                onClick={() => handleDelete(user.id)}
                            >
                                Delete
                            </button>
                            {user.roles.includes('Admin') ? (
                                <button
                                    className="btn btn-warning"
                                    onClick={() => handleRemoveAdmin(user.id)}
                                >
                                    Remove Admin Role
                                </button>
                            ) : (
                                <button
                                    className="btn btn-primary"
                                    onClick={() => handleAddAdmin(user.id)}
                                >
                                    Add Admin Role
                                </button>
                            )}
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
}