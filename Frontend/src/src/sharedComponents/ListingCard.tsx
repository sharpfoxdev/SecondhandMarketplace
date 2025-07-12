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
                <div className="card-img-wrapper">
                    <img src={imageUrl} className="card-img-top" alt={listing.title} />
                </div>
                <div className="card-body d-flex flex-column">
                    <h5 className="card-title title-clamp">
                        {listing.title}
                    </h5>
                    <small className="text-muted mb-2">
                        Posted on {formattedDate}
                    </small>
                    <p className="card-text description-clamp flex-grow-1">
                        {listing.description}
                    </p>
                    <p className="card-text text-primary price-text">
                        {listing.price.toFixed(2)}
                    </p>
                </div>
            </div>

            <style jsx>{`
    .title-clamp {
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }
    .description-clamp {
        display: -webkit-box;
        -webkit-box-orient: vertical;
        -webkit-line-clamp: 3;
        overflow: hidden;
    }
    .price-text {
        white-space: nowrap;
    }
    .card-img-wrapper {
        width: 100%;
        height: 200px;
        overflow: hidden;
    }
    .card-img-wrapper :global(img) {
        width: 100%;
        height: 100%;
        object-fit: contain;
        object-position: center;
        background: #f8f9fa;
    }
  `}</style>
        </Link>
    );
}