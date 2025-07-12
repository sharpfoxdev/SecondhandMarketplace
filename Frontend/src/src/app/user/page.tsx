'use client';

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Listing } from '@/types/api/listings';
import { fetchListingsByUser, deleteListing } from '@/services/listingService';

export default function UserListingsPage() {
    const [listings, setListings] = useState<Listing[]>([]);
    const [loading, setLoading] = useState(true);
    const router = useRouter();

    useEffect(() => {
        const fetchUserListings = async () => {
            try {
                const res = await fetchListingsByUser();
                setListings(res);
            } catch (error) {
                console.error('Failed to fetch listings', error);
            } finally {
                setLoading(false);
            }
        };

        fetchUserListings();
    }, []);

    const handleDelete = async (id: string) => {
        const confirmDelete = window.confirm(
            'Are you sure you want to delete this listing?'
        );
        if (!confirmDelete) return;

        try {
            await deleteListing(id);
            // remove the listing from the state after deletion
            setListings(listings.filter((listing) => listing.id !== id));
            alert('Listing deleted successfully.');
        } catch (error) {
            console.error('Failed to delete listing', error);
            alert('Failed to delete listing.');
        }
    };

    const handleEdit = (id: string) => {
        router.push(`/listing/${id}/edit`);
    };

    const handleRedirectToListing = (id: string) => {
        router.push(`/listing/${id}`);
    };

    if (loading) {
        return <div className="container mt-5">Loading...</div>;
    }

    return (
        <div className="container mt-5">
            <h1 className="mb-4">Your Listings</h1>

            {listings.length === 0 ? (
                <p>No listings found.</p>
            ) : (
                <ul className="list-group">
                    {listings.map((listing) => (
                        <li
                            key={listing.id}
                            className="list-group-item d-flex justify-content-between align-items-center"
                        >
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
                            <div className="d-flex flex-row flex-shrink-0">
                                <button
                                    className="btn btn-primary me-2"
                                    onClick={() => handleEdit(listing.id)}
                                >
                                    Edit
                                </button>
                                <button
                                    className="btn btn-danger"
                                    onClick={() => handleDelete(listing.id)}
                                >
                                    Delete
                                </button>
                            </div>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}
