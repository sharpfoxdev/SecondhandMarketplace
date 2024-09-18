'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import 'bootstrap/dist/css/bootstrap.min.css';

interface StateOfItem {
  id: string;
  name: string;
}

interface Listing {
  id: string;
  title: string;
  description: string;
  reasonOfSale: string;
  price: number;
  isSold: boolean;
  stateOfItem: StateOfItem;
  stateOfItemId: string;
}

export default function EditListingPage({ params }: { params: { id: string } }) {
  const { id } = params;
  const [listing, setListing] = useState<Listing | null>(null);
  const [statesOfItems, setStatesOfItems] = useState<StateOfItem[]>([]);
  const [loading, setLoading] = useState(true);
  const router = useRouter();

  useEffect(() => {
    const fetchListing = async () => {
      try {
        const token = localStorage.getItem('token');
        const response = await axios.get<Listing>(`https://localhost:7192/api/Listings/${id}`, {
          headers: { Authorization: `Bearer ${token}` },
        });
        setListing({ ...response.data, stateOfItemId: response.data.stateOfItem.id }); // Set the stateOfItemId from the current listing
      } catch (error) {
        console.error('Failed to fetch listing', error);
      }
    };

    const fetchStatesOfItems = async () => {
      try {
        const token = localStorage.getItem('token');
        const response = await axios.get<StateOfItem[]>('https://localhost:7192/api/StateOfItem', {
          headers: { Authorization: `Bearer ${token}` },
        });
        setStatesOfItems(response.data);
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
      const token = localStorage.getItem('token');
      const updatedListing = {
        title: listing.title,
        description: listing.description,
        reasonOfSale: listing.reasonOfSale,
        price: listing.price,
        stateOfItemId: listing.stateOfItemId,
        isSold: listing.isSold,
      };

      await axios.put(`https://localhost:7192/api/Listings/${listing.id}`, updatedListing, {
        headers: { Authorization: `Bearer ${token}` },
      });

      alert('Listing updated successfully!');
      router.push('/user');
    } catch (error) {
      console.error('Failed to update listing', error);
      alert('Failed to update listing.');
    }
  };

  const handleStateChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const selectedStateId = e.target.value;
    const selectedState = statesOfItems.find((state) => state.id === selectedStateId);
    
    if (selectedState && listing) {
      setListing({
        ...listing,
        stateOfItemId: selectedState.id,
        stateOfItem: selectedState,
      });
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
          <select
            className="form-select"
            id="stateOfItem"
            value={listing.stateOfItemId}
            onChange={handleStateChange}
          >
            {statesOfItems.map((state) => (
              <option key={state.id} value={state.id}>
                {state.name}
              </option>
            ))}
          </select>
        </div>

        <div className="form-check mb-3">
          <input
            className="form-check-input"
            type="checkbox"
            id="isSold"
            checked={listing.isSold}
            onChange={(e) => setListing({ ...listing, isSold: e.target.checked })}
          />
          <label className="form-check-label" htmlFor="isSold">
            Is Sold
          </label>
        </div>

        <button type="submit" className="btn btn-primary">Save Changes</button>
      </form>
    </div>
  );
}
