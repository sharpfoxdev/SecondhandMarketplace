'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import 'bootstrap/dist/css/bootstrap.min.css';

interface Listing {
  id: string;
  title: string;
}

export default function UserListingsPage() {
  const [listings, setListings] = useState<Listing[]>([]);
  const [loading, setLoading] = useState(true);
  const router = useRouter();
  
  useEffect(() => {
    const fetchUserListings = async () => {
      try {
        const token = localStorage.getItem('token');
        const response = await axios.get<Listing[]>('https://localhost:7192/api/Listings/GetByUser', {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setListings(response.data);
      } catch (error) {
        console.error('Failed to fetch listings', error);
      } finally {
        setLoading(false);
      }
    };

    fetchUserListings();
  }, []);

  const handleDelete = async (id: string) => {
    const confirmDelete = window.confirm('Are you sure you want to delete this listing?');
    if (!confirmDelete) return;

    try {
      const token = localStorage.getItem('token');
      await axios.delete(`https://localhost:7192/api/Listings/${id}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      // remove the listing from the state after deletion
      setListings(listings.filter((listing) => listing.id !== id));
      alert('Listing deleted successfully.');
    } catch (error) {
      console.error('Failed to delete listing', error);
      alert('Failed to delete listing.');
    }
  };

  const handleEdit = (id: string) => {
    router.push(`/listing/${id}/edit`);
  };

  if (loading) {
    return <div className="container mt-5">Loading...</div>;
  }

  return (
    <div className="container mt-5">
      <h1>Your Listings</h1>

      {listings.length === 0 ? (
        <p>No listings found.</p>
      ) : (
        <ul className="list-group">
          {listings.map((listing) => (
            <li key={listing.id} className="list-group-item d-flex justify-content-between align-items-center">
              <span>{listing.title}</span>
              <div>
                <button className="btn btn-primary mr-2" onClick={() => handleEdit(listing.id)}>
                  Edit
                </button>
                <button className="btn btn-danger" onClick={() => handleDelete(listing.id)}>
                  Delete
                </button>
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}
