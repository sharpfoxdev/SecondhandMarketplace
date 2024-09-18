'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import ListingGrid from './ui/ListingGrid';

interface Listing {
  id: string;
  title: string;
  description: string;
  price: number;
  images: { imageUrl: string }[];
}

export default function Home() {
  const [listings, setListings] = useState<Listing[]>([]);

  useEffect(() => {
    const fetchListings = async () => {
      try {
        const response = await axios.get<Listing[]>('https://localhost:7192/api/Listings');
        setListings(response.data);
      } catch (error) {
        console.error('Failed to fetch listings', error);
      }
    };
    fetchListings();
  }, []);

  return (
    <div className="container mt-5">
      <h1 className="mb-4">Listings</h1>
      {listings.length === 0 ? (
        <p>No listings available.</p>
      ) : (
        <ListingGrid listings={listings} />
      )}
    </div>
  );
}
