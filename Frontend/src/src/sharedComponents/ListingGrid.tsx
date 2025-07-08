import React from 'react';
import { ListingCard } from './ListingCard';

export interface Listing {
  id: string;
  title: string;
  description: string;
  price: number;
  images: { imageUrl: string }[];
}

interface ListingGridProps {
  listings: Listing[];
  page: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

export function ListingGrid({ listings, page, totalPages, onPageChange }: ListingGridProps) {
  return (
    <>
      <div className="row">
        {listings.map(listing => (
          <div key={listing.id} className="col-md-4 col-sm-6 mb-4">
            <ListingCard listing={listing} />
          </div>
        ))}
      </div>
      <nav>
        <ul className="pagination justify-content-center mt-4">
          <li className={`page-item ${page === 1 ? 'disabled' : ''}`}>
            <button className="page-link" onClick={() => onPageChange(Math.max(page - 1, 1))}>Previous</button>
          </li>
          <li className="page-item disabled">
            <span className="page-link">{page} / {totalPages}</span>
          </li>
          <li className={`page-item ${page === totalPages ? 'disabled' : ''}`}>
            <button className="page-link" onClick={() => onPageChange(Math.min(page + 1, totalPages))}>Next</button>
          </li>
        </ul>
      </nav>
    </>
  );
}
