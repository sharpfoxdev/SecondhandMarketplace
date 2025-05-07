'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';

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
  sellerId: string;
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
  const [selectedImageIndex, setSelectedImageIndex] = useState<number | null>(null);

  const [hubConnection, setHubConnection] = useState<HubConnection | null>(null);
  const [showMessageForm, setShowMessageForm] = useState(false);
  const [messageText, setMessageText] = useState('');

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

    if (id) fetchListing();
  }, [id]);

  useEffect(() => {
    const initHub = async () => {
      const token = localStorage.getItem('token');
      console.log(token);
      const connection = new HubConnectionBuilder()
        .withUrl('https://localhost:7192/chathub', { accessTokenFactory: () => token || '' })
        .withAutomaticReconnect()
        .build();

      connection.on('ReceiveMessage', (senderId: string, messageDto: any) => {
        console.log('Message received:', senderId, messageDto);
      });

      try {
        await connection.start();
        setHubConnection(connection);
      } catch (err) {
        console.error('SignalR connection error:', err);
      }
    };

    initHub();
    return () => {
      hubConnection?.stop();
    };
  }, []);

  const handleSendMessage = async () => {
    if (!messageText.trim() || !hubConnection || !listing) return;
    try {
      const token = localStorage.getItem('token');
      const res = await axios.post('https://localhost:7192/api/conversations', { recipientId: listing.sellerId }, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      const conversationId: string = res.data.id;
      await hubConnection.invoke('JoinConversation', conversationId);
      await hubConnection.invoke('SendMessage', conversationId, messageText);
      setMessageText('');
      setShowMessageForm(false);
    } catch (error) {
      console.error('Error sending message:', error);
    }
  };

  const handleNextImage = () => {
    if (selectedImageIndex !== null && listing) {
      setSelectedImageIndex((prev) => (prev! + 1) % listing.images.length);
    }
  };

  const handlePreviousImage = () => {
    if (selectedImageIndex !== null && listing) {
      setSelectedImageIndex((prev) => (prev! - 1 + listing.images.length) % listing.images.length);
    }
  };

  if (loading) return <div className="container mt-5">Loading...</div>;
  if (!listing) return <div className="container mt-5">Listing not found</div>;

  return (
    <div className="container mt-5">
      <h1>{listing.title}</h1>

      {/* Image Gallery */}
      {listing.images.length > 0 && (
        <div className="row">
          {listing.images.map((img, idx) => (
            <div className="col-4 mb-3" key={img.id}>
              <img
                src={img.imageUrl}
                alt="Listing Image"
                className="img-fluid thumbnail"
                onClick={() => setSelectedImageIndex(idx)}
                style={{ cursor: 'pointer' }}
              />
            </div>
          ))}
        </div>
      )}

      {/* Modal for full-size images */}
      <Modal show={selectedImageIndex !== null} onHide={() => setSelectedImageIndex(null)} centered>
        <Modal.Header closeButton />
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
                <Button onClick={handlePreviousImage}>Previous</Button>
                <Button onClick={handleNextImage}>Next</Button>
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

        <h4>Property values</h4>
        <ul>
          {listing.selectedListingPropertyValues.map((value) => (
            <li key={value.id}>
              <strong>{value.listingProperty.name}:</strong> {value.name}
            </li>
          ))}
        </ul>
      </div>

      {/* Message Seller Section */}
      <div className="mt-4">
        {!showMessageForm ? (
          <Button onClick={() => setShowMessageForm(true)}>Message Seller</Button>
        ) : (
          <div className="mt-3">
            <textarea
              rows={3}
              className="form-control"
              value={messageText}
              onChange={(e) => setMessageText(e.target.value)}
              placeholder="Write your message..."
            />
            <div className="mt-2">
              <Button onClick={handleSendMessage} disabled={!messageText.trim()} className="me-2">
                Send
              </Button>
              <Button variant="secondary" onClick={() => setShowMessageForm(false)}>
                Cancel
              </Button>
            </div>
          </div>
        )}
      </div>

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
