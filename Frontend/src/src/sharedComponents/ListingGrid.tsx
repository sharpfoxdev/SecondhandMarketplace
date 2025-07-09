import React from 'react';
import { ListingCard } from './ListingCard';
import { Page } from '@/types/api/page';
import { Listing } from '@/types/api/listings';


interface ListingGridProps {
    page: Page<Listing>
    onPageChange: (pageNumber: number) => void;
}

export function ListingGrid({ page, onPageChange }: ListingGridProps) {
    return (
        <>
            <div className="row">
                {page.items.map(listing => (
                    <div key={listing.id} className="col-md-4 col-sm-6 mb-4">
                        <ListingCard listing={listing} />
                    </div>
                ))}
            </div>
            <nav>
                <ul className="pagination justify-content-center mt-4">
                    <li className={`page-item ${page.pageNumber === 1 ? 'disabled' : ''}`}>
                        <button className="page-link" onClick={() => onPageChange(Math.max(page.pageNumber - 1, 1))}>Previous</button>
                    </li>
                    <li className="page-item disabled">
                        <span className="page-link">{page.pageNumber} / {page.totalPages}</span>
                    </li>
                    <li className={`page-item ${page.pageNumber === page.totalPages ? 'disabled' : ''}`}>
                        <button className="page-link" onClick={() => onPageChange(Math.min(page.pageNumber + 1, page.totalPages))}>Next</button>
                    </li>
                </ul>
            </nav>
        </>
    );
}
