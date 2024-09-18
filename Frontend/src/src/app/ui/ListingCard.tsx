import React from 'react';
import Link from 'next/link';

interface Listing {
  id: string;
  title: string;
  description: string;
  price: number;
  images: { imageUrl: string }[];
}

interface ListingCardProps {
  listing: Listing;
}

const ListingCard: React.FC<ListingCardProps> = ({ listing }) => {
  const { id, title, description, price, images } = listing;
  const imageUrl = images[0]?.imageUrl || '/default-image.jpg';

  return (
    <Link href={`/listing/${id}`} className="text-decoration-none">
      <div className="card listing-card h-100">
        <img src={imageUrl} className="card-img-top" alt={title} />
        <div className="card-body d-flex flex-column">
          <h5 className="card-title">{title}</h5>
          <p className="card-text flex-grow-1">{description}</p>
          <p className="card-text text-primary">{price.toFixed(2)}</p>
        </div>
      </div>
    </Link>
  );
};

export default ListingCard;
