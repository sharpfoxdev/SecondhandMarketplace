'use client';

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import 'bootstrap/dist/css/bootstrap.min.css';
import { StateOfItem } from '@/types/api/stateOfItem';
import { ListingDetail, UpdateListingRequest } from '@/types/api/listings';
import { fetchListingById, updateListing } from '@/services/listingService';
import { fetchStatesOfItem } from '@/services/stateOfItemService';
import CustomDropdown from '@/sharedComponents/CustomDropdown';

export default function EditListingPage({ params }: { params: { id: string } }) {
    const { id } = params;
    const [listing, setListing] = useState<ListingDetail | null>(null);
    const [statesOfItems, setStatesOfItems] = useState<StateOfItem[]>([]);
    const [loading, setLoading] = useState(true);
    const router = useRouter();

    useEffect(() => {
        const fetchListing = async () => {
            try {
                const res = await fetchListingById(id);
                setListing(res);
            } catch (error) {
                console.error('Failed to fetch listing', error);
            }
        };

        const fetchStatesOfItems = async () => {
            try {
                const res = await fetchStatesOfItem();
                setStatesOfItems(res);
            } catch (error) {
                console.error('Failed to fetch states of items', error);
            }
        };

        fetchListing();
        fetchStatesOfItems();
        setLoading(false);
    }, [id]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!listing) return;

        try {
            const updatedListing: UpdateListingRequest = {
                title: listing.title,
                description: listing.description,
                reasonOfSale: listing.reasonOfSale,
                price: listing.price,
                stateOfItemId: listing.stateOfItem.id,
                isSold: listing.isSold,
            };
            await updateListing(listing.id, updatedListing);

            alert('Listing updated successfully!');
            router.push('/user');
        } catch (error) {
            console.error('Failed to update listing', error);
            alert('Failed to update listing.');
        }
    };

    if (loading || !listing) {
        return <div className="container mt-5">Loading...</div>;
    }

    return (
        <div className="container mt-5">
            <h1>Edit Listing</h1>

            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label htmlFor="title" className="form-label">Title</label>
                    <input
                        type="text"
                        className="form-control"
                        id="title"
                        value={listing.title}
                        onChange={(e) => setListing({ ...listing, title: e.target.value })}
                        required
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="price" className="form-label">Price</label>
                    <input
                        type="number"
                        className="form-control"
                        id="price"
                        value={listing.price}
                        onChange={(e) => setListing({ ...listing, price: parseFloat(e.target.value) })}
                        required
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="description" className="form-label">Description</label>
                    <textarea
                        className="form-control"
                        id="description"
                        value={listing.description}
                        onChange={(e) => setListing({ ...listing, description: e.target.value })}
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="reasonOfSale" className="form-label">Reason of Sale</label>
                    <textarea
                        className="form-control"
                        id="reasonOfSale"
                        value={listing.reasonOfSale}
                        onChange={(e) => setListing({ ...listing, reasonOfSale: e.target.value })}
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="stateOfItem" className="form-label">State of Item</label>
                    <CustomDropdown
                        options={statesOfItems}
                        selectedId={listing.stateOfItem.id}
                        onSelect={(id) => {
                            const selectedState = statesOfItems.find(s => s.id === id);
                            if (selectedState) {
                                setListing({ ...listing, stateOfItem: selectedState });
                            }
                        }}
                    />
                </div>
                <button type="submit" className="btn btn-primary">Save Changes</button>
            </form>
        </div>
    );
}
