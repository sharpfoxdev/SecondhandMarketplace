'use client';

import React, { useState, ChangeEvent } from 'react';
import { fetchListingById, deleteListing } from '@/services/listingService';
import { ListingDetail } from '@/types/api/listings';

export default function ListingManagementSection() {
    const [guid, setGuid] = useState<string>('');
    const [listing, setListing] = useState<ListingDetail | null>(null);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    const handleSearch = async () => {
        if (!guid.trim()) {
            setError('Please enter a GUID');
            return;
        }
        setLoading(true);
        setError(null);
        try {
            const res = await fetchListingById(guid);
            setListing(res);
        } catch (err: any) {
            setListing(null);
            setError(err.response?.data?.message || 'Listing not found');
        } finally {
            setLoading(false);
        }
    };

    const handleDelete = async (id: string) => {
        if (!window.confirm('Are you sure you want to delete this listing?'))
            return;
        try {
            await deleteListing(id);
            setListing(null);
            setGuid('');
            alert('Listing deleted successfully');
        } catch (err: any) {
            alert(err.response?.data?.message || 'Delete failed');
        }
    };

    const onGuidChange = (e: ChangeEvent<HTMLInputElement>) => {
        setGuid(e.target.value);
    };

    return (
        <div className="card mb-4">
            <div className="card-header">
                <h5 className="mb-0">Manage Listing by GUID</h5>
            </div>
            <div className="card-body">
                <div className="input-group mb-3">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Enter listing GUID"
                        value={guid}
                        onChange={onGuidChange}
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
                {listing && (
                    <div className="d-flex align-items-center">
                        <span className="text-truncate flex-grow-1 me-3">
                            <a
                                href={`/listing/${listing.id}`}
                                className="fw-bold text-decoration-none"
                                style={{
                                    display: 'inline-block',
                                    maxWidth: '100%',
                                }}
                            >
                                {listing.title}
                            </a>
                        </span>
                        <div className="flex-shrink-0">
                            <button
                                className="btn btn-danger"
                                onClick={() => handleDelete(listing.id)}
                            >
                                Delete
                            </button>
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
}
