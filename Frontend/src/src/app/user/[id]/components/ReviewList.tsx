import React from 'react';
import { Page } from '@/types/api/page';
import { Review } from '@/types/api/reviews';

export interface ReviewListProps {
    page: Page<Review>;
    onPageChange: (pageNumber: number) => void;
}

export function ReviewList({ page, onPageChange }: ReviewListProps) {
    return (
        <>
            <ul className="list-group">
                {page.items.map((review) => (
                    <li key={review.id} className="list-group-item">
                        <div className="d-flex w-100 justify-content-between">
                            <h5 className="mb-1">{review.reviewer.nickname}</h5>
                            <small className="text-muted">
                                {new Date(review.createdAt).toLocaleString()}
                            </small>
                        </div>
                        <p className="mb-1">{review.reviewText}</p>
                    </li>
                ))}
            </ul>

            <nav aria-label="Review pagination">
                <ul className="pagination justify-content-center mt-4">
                    <li className={`page-item ${page.pageNumber === 1 ? 'disabled' : ''}`}>
                        <button
                            className="page-link"
                            onClick={() => onPageChange(Math.max(page.pageNumber - 1, 1))}
                        >
                            Previous
                        </button>
                    </li>

                    <li className="page-item disabled">
                        <span className="page-link">
                            {page.pageNumber} / {page.totalPages}
                        </span>
                    </li>

                    <li className={`page-item ${page.pageNumber === page.totalPages ? 'disabled' : ''}`}>
                        <button
                            className="page-link"
                            onClick={() => onPageChange(Math.min(page.pageNumber + 1, page.totalPages))}
                        >
                            Next
                        </button>
                    </li>
                </ul>
            </nav>
        </>
    );
}
