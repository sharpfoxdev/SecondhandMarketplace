"use client";

import { useState } from 'react';
import { useRouter, useParams } from 'next/navigation';
import { createReview } from '@/services/reviewService';

export default function ReviewPage({ params }: { params: { id: string } }) {
    const { id } = params;
    const router = useRouter();
    const [reviewText, setReviewText] = useState('');
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setIsSubmitting(true);
        setError(null);
        try {
            await createReview({ revieweeId: id, reviewText });
            router.push(`/user/${id}`);
        } catch (err: any) {
            setError(err.message || 'Failed to submit review.');
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <div className="container my-5">
            <div className="row justify-content-center">
                <div className="col-12 col-md-8">
                    <h1 className="mb-4">Leave a Review</h1>
                    <form onSubmit={handleSubmit}>
                        <div className="mb-3">
                            <textarea
                                className="form-control"
                                rows={5}
                                placeholder="Write your review..."
                                value={reviewText}
                                onChange={(e) => setReviewText(e.target.value)}
                                required
                            />
                        </div>
                        {error && <div className="text-danger mb-3">{error}</div>}
                        <button
                            type="submit"
                            className="btn btn-primary"
                            disabled={isSubmitting}
                        >
                            {isSubmitting ? 'Submitting...' : 'Submit Review'}
                        </button>
                    </form>
                </div>
            </div>
        </div>
    );
}
