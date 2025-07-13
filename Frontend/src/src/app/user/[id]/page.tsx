'use client';

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import { fetchUserById } from '@/services/userService';
import { fetchReviewsByReviewee } from '@/services/reviewService';
import { fetchListings } from '@/services/listingService';
import { ReviewList } from './components/ReviewList';
import { ListingGrid } from '@/sharedComponents/ListingGrid';
import { Page } from '@/types/api/page';
import { Review } from '@/types/api/reviews';
import { Listing } from '@/types/api/listings';
import { Tab, Tabs } from 'react-bootstrap';
import { ListingFilter } from '@/types/api/categories';
import { Ordering, OrderingDirection } from '@/types/api/categories';
import { User } from '@/types/api/users';

export default function UserPage({ params }: { params: { id: string } }) {
    const { id } = params;
    const router = useRouter();

    const [user, setUser] = useState<User | null>(null);
    const [activeTab, setActiveTab] = useState<'listings' | 'reviews'>(
        'listings'
    );

    const [reviewsPage, setReviewsPage] = useState<Page<Review> | null>(null);
    const [listingsPage, setListingsPage] = useState<Page<Listing> | null>(
        null
    );

    const [loadingUser, setLoadingUser] = useState(true);
    const [loadingReviews, setLoadingReviews] = useState(true);
    const [loadingListings, setLoadingListings] = useState(true);

    const [error, setError] = useState<string | null>(null);

    const loadUser = async () => {
        setLoadingUser(true);
        try {
            const u = await fetchUserById(id);
            setUser(u);
        } catch (err: any) {
            setError(err.message || 'Failed to load user.');
        } finally {
            setLoadingUser(false);
        }
    };

    const loadReviews = async (pageNumber: number = 1) => {
        setLoadingReviews(true);
        try {
            const data = await fetchReviewsByReviewee(id, pageNumber);
            setReviewsPage(data);
        } catch (err: any) {
            setError(err.message || 'Failed to load reviews.');
        } finally {
            setLoadingReviews(false);
        }
    };

    const loadListings = async (pageNumber: number = 1) => {
        setLoadingListings(true);
        try {
            const filter: ListingFilter = {
                priceMin: null,
                priceMax: null,
                stateOfItemIds: [],
                selectedListingPropertyValueIds: [],
                sellerId: id,
                cityId: null,
                radius: null,
                search: null,
                ordering: Ordering.CreatedAt,
                orderingDirection: OrderingDirection.Descending,
            };
            const data = await fetchListings(filter, pageNumber);
            setListingsPage(data);
        } catch (err: any) {
            setError(err.message || 'Failed to load listings.');
        } finally {
            setLoadingListings(false);
        }
    };

    useEffect(() => {
        loadUser();
        loadReviews();
        loadListings();
    }, [id]);

    if (loadingUser) {
        return <p>Loading user...</p>;
    }

    if (!user) {
        return <p className="text-danger my-3">User not found.</p>;
    }

    return (
        <div className="container my-5">
            <h1 className="mb-4">{user.nickname}</h1>

            <Tabs
                activeKey={activeTab}
                onSelect={(k) => setActiveTab(k as 'reviews' | 'listings')}
                className="mb-3"
            >
                <Tab
                    eventKey="listings"
                    title="Listings"
                >
                    {error && <p className="text-danger">{error}</p>}
                    {loadingListings ? (
                        <p>Loading listings...</p>
                    ) : (
                        listingsPage && (
                            <ListingGrid
                                page={listingsPage}
                                onPageChange={loadListings}
                            />
                        )
                    )}
                </Tab>
                <Tab
                    eventKey="reviews"
                    title="Reviews"
                >
                    {error && <p className="text-danger">{error}</p>}
                    {loadingReviews ? (
                        <p>Loading reviews...</p>
                    ) : (
                        reviewsPage && (
                            <ReviewList
                                page={reviewsPage}
                                onPageChange={loadReviews}
                            />
                        )
                    )}
                </Tab>
            </Tabs>
        </div>
    );
}
