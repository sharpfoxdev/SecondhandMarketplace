'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/router';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

interface ListingPropertyValue {
  id: string;
  name: string;
  listingProperty: { name: string };
}

interface Image {
  id: string;
  imageUrl: string;
}

interface Listing {
  id: string;
  title: string;
  description: string;
  reasonOfSale: string;
  price: number;
  isSold: boolean;
  category: { name: string };
  selectedListingPropertyValues: ListingPropertyValue[];
  images: Image[];
}

export default function ListingPage({ params }: { params: { id: string } }) {
  const { id } = params;
  const [listing, setListing] = useState<Listing | null>(null);
  const [loading, setLoading] = useState(true);
  const [selectedImageIndex, setSelectedImageIndex] = useState<number | null>(null); // For the modal

  useEffect(() => {
    const fetchListing = async () => {
      try {
        const response = await axios.get<Listing>(`https://localhost:7192/api/Listings/${id}`);
        setListing(response.data);
      } catch (error) {
        console.error('Failed to fetch listing', error);
      } finally {
        setLoading(false);
      }
    };

    if (id) {
      fetchListing();
    }
  }, [id]);
  const handleNextImage = () => {
    if (selectedImageIndex !== null && listing) {
      setSelectedImageIndex((prevIndex) => (prevIndex + 1) % listing.images.length);
    }
  };

  const handlePreviousImage = () => {
    if (selectedImageIndex !== null && listing) {
      setSelectedImageIndex((prevIndex) => (prevIndex - 1 + listing.images.length) % listing.images.length);
    }
  };
  if (loading) {
    return <div className="container mt-5">Loading...</div>;
  }

  if (!listing) {
    return <div className="container mt-5">Listing not found</div>;
  }

  return (
    <div className="container mt-5">
      <h1>{listing.title}</h1>

      {/* Image Gallery */}
      {listing.images.length > 0 && (
        <div className="row">
          {listing.images.map((image, index) => (
            <div className="col-4 mb-3" key={image.id}>
              <img
                src={image.imageUrl}
                alt="Listing Image"
                className="img-fluid thumbnail"
                onClick={() => setSelectedImageIndex(index)}
                style={{ cursor: 'pointer' }}
              />
            </div>
          ))}
        </div>
      )}

      {/* Modal for full-size images */}
      <Modal show={selectedImageIndex !== null} onHide={() => setSelectedImageIndex(null)} centered>
        <Modal.Header closeButton>
        </Modal.Header>
        <Modal.Body>
          {selectedImageIndex !== null && (
            <div className="d-flex flex-column align-items-center">
              <img
                src={listing.images[selectedImageIndex].imageUrl}
                alt="Full size listing image"
                className="img-fluid"
                style={{ width: '100%' }}
              />
              <div className="mt-3 d-flex justify-content-between" style={{ width: '100%' }}>
                <Button variant="primary" onClick={handlePreviousImage}>
                  Previous
                </Button>
                <Button variant="primary" onClick={handleNextImage}>
                  Next
                </Button>
              </div>
            </div>
          )}
        </Modal.Body>
      </Modal>

      {/* Listing Information */}
      <div className="mt-4">
        <h3>Details</h3>
        <p><strong>Price:</strong> {listing.price}</p>
        <p><strong>Is Sold:</strong> {listing.isSold ? 'Yes' : 'No'}</p>
        <p><strong>Category:</strong> {listing.category.name}</p>
        <p><strong>Description:</strong> {listing.description}</p>
        <p><strong>Reason of Sale:</strong> {listing.reasonOfSale}</p>

        {/* Listing Property Values */}
        <h4>Property values</h4>
        <ul>
          {listing.selectedListingPropertyValues.map((value) => (
            <li key={value.id}>
              <strong>{value.listingProperty.name}:</strong> {value.name}
            </li>
          ))}
        </ul>
      </div>
      {/* Custom styles */}
      
      <style jsx>{`
        .thumbnail {
          object-fit: cover;
          height: 200px;
          width: 100%;
        }
      `}</style>
    </div>
  );
}
