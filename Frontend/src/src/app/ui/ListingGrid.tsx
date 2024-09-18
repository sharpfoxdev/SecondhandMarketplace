import React from 'react';
import ListingCard from './ListingCard';

interface Listing {
  id: string;
  title: string;
  description: string;
  price: number;
  images: { imageUrl: string }[];
}

interface ListingGridProps {
  listings: Listing[];
}

const ListingGrid: React.FC<ListingGridProps> = ({ listings }) => {
  return (
    <div className="row">
      {listings.map((listing) => (
        <div className="col-md-4 col-sm-6 mb-4" key={listing.id}>
          <ListingCard listing={listing} />
        </div>
      ))}
    </div>
  );
};

export default ListingGrid;
