import React from 'react';
import Link from 'next/link';
import { Listing } from '@/types/api/listings';

interface ListingCardProps {
    listing: Listing;
}

export function ListingCard({ listing }: ListingCardProps) {
    const imageUrl = listing.images[0]?.imageUrl || '/default-image.jpg';
    const createdDate = new Date(listing.createdAt);
    const formattedDate = createdDate.toLocaleDateString(undefined, {
        year: 'numeric',
        month: 'long',
        day: 'numeric',
    });
    return (
        <Link href={`/listing/${listing.id}`} className="text-decoration-none">
            <div className="card listing-card h-100">
                <img src={imageUrl} className="card-img-top" alt={listing.title} />
                <div className="card-body d-flex flex-column">
                    <h5 className="card-title">
                        {listing.title}
                        <br />
                        <small className="text-muted">Posted on {formattedDate}</small>
                    </h5>
                    <p className="card-text flex-grow-1">{listing.description}</p>
                    <p className="card-text text-primary">{listing.price.toFixed(2)}</p>
                </div>
            </div>
        </Link>
    );
}