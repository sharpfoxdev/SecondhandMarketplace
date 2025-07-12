'use client';

import { useEffect, useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import { HubConnectionBuilder, HubConnection } from '@microsoft/signalr';
import { ListingDetail } from '@/types/api/listings';
import { fetchListingById } from '@/services/listingService';
import { createConversation } from '@/services/conversationService';
import { useRouter } from 'next/navigation';
import styles from './ListingPage.module.css';
import { fetchUserById } from '@/services/userService';
import { User } from '@/types/api/users';
import Image from 'next/image';

export default function ListingPage({ params }: { params: { id: string } }) {
    const { id } = params;
    const router = useRouter();
    const [listing, setListing] = useState<ListingDetail | null>(null);
    const [user, setUser] = useState<User | null>(null);
    const [loading, setLoading] = useState(true);
    const [selectedImageIndex, setSelectedImageIndex] = useState<number | null>(
        null
    );

    const [hubConnection, setHubConnection] = useState<HubConnection | null>(
        null
    );
    const [showMessageForm, setShowMessageForm] = useState(false);
    const [messageText, setMessageText] = useState('');

    useEffect(() => {
        const fetchListing = async () => {
            try {
                const res = await fetchListingById(id);
                setListing(res);
                const user = await fetchUserById(res.sellerId);
                setUser(user);
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
            const connection = new HubConnectionBuilder()
                .withUrl(`${process.env.NEXT_PUBLIC_API_BASE_URL}/chathub`, {
                    accessTokenFactory: () =>
                        localStorage.getItem('token') || '',
                })
                .withAutomaticReconnect()
                .build();

            connection.on(
                'ReceiveMessage',
                (senderId: string, message: any) => {
                    console.log('Message received:', senderId, message);
                }
            );

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
    }, [hubConnection]);

    const handleSendMessage = async () => {
        if (!messageText.trim() || !hubConnection || !listing) return;
        try {
            const res = await createConversation({
                recipientId: listing.sellerId,
            });
            const conversationId: string = res.id;
            await hubConnection.invoke('JoinConversation', conversationId);
            await hubConnection.invoke(
                'SendMessage',
                conversationId,
                messageText
            );
            setMessageText('');
            setShowMessageForm(false);
            router.push(`/inbox/${conversationId}`);
        } catch (error) {
            alert("Couldn't send message");
            console.error('Error sending message:', error);
        }
    };

    const handleNextImage = () => {
        if (selectedImageIndex !== null && listing) {
            setSelectedImageIndex(
                (prev) => (prev! + 1) % listing.images.length
            );
        }
    };

    const handlePreviousImage = () => {
        if (selectedImageIndex !== null && listing) {
            setSelectedImageIndex(
                (prev) =>
                    (prev! - 1 + listing.images.length) % listing.images.length
            );
        }
    };

    if (loading) return <div className="container mt-5">Loading...</div>;
    if (!listing)
        return <div className="container mt-5">Listing not found</div>;

    return (
        <div className="container mt-5">
            <h1 className="mb-4">{listing.title}</h1>
            {/* gallery */}
            {listing.images.length > 0 && (
                <div className="row row-cols-2 row-cols-sm-3 row-cols-md-4 row-cols-lg-6 g-3">
                    {listing.images.map((img, idx) => (
                        <div
                            className="col"
                            key={img.id}
                        >
                            <div
                                className={`ratio ratio-4x3 ${styles.thumbnailWrapper}`}
                            >
                                {/* <Image
                                    src={img.imageUrl}
                                    alt="Listing"
                                    fill
                                    style={{ objectFit: 'cover' }}
                                    className={styles.thumbnail}
                                /> */}
                                <img
                                    src={img.imageUrl}
                                    alt="Listing"
                                    className={styles.thumbnail}
                                    onClick={() => setSelectedImageIndex(idx)}
                                />
                            </div>
                        </div>
                    ))}
                </div>
            )}

            {/* modal for images */}
            <Modal
                show={selectedImageIndex !== null}
                onHide={() => setSelectedImageIndex(null)}
                centered
            >
                <Modal.Header closeButton />
                <Modal.Body>
                    {selectedImageIndex !== null && (
                        <div className="d-flex flex-column align-items-center">
                            {/* <Image
                                src={listing.images[selectedImageIndex].imageUrl}
                                alt="Full size"
                                className="img-fluid"
                            /> */}
                            <img
                                src={
                                    listing.images[selectedImageIndex].imageUrl
                                }
                                alt="Full size"
                                className="img-fluid"
                            />
                            <div className="mt-3 d-flex justify-content-between w-100">
                                <Button onClick={handlePreviousImage}>
                                    Previous
                                </Button>
                                <Button onClick={handleNextImage}>Next</Button>
                            </div>
                        </div>
                    )}
                </Modal.Body>
            </Modal>

            {/* listing info */}
            <div className="mt-5">
                <h3>Details</h3>
                <p>
                    <strong>Price:</strong> {listing.price}
                </p>
                <p>
                    <strong>Seller:</strong>{' '}
                    <a
                        href={`/user/${listing.sellerId}`}
                        className="text-decoration-none"
                    >
                        {user?.nickname ?? listing.sellerId}
                    </a>
                </p>
                <p>
                    <strong>City:</strong> {listing.city.name}
                </p>
                <p>
                    <strong>State of Item:</strong> {listing.stateOfItem.name}
                </p>
                <p>
                    <strong>Category:</strong>{' '}
                    <a
                        href={`/category/${listing.category.name}`}
                        className="text-decoration-none"
                    >
                        {listing.category.name}
                    </a>
                </p>
                <p>
                    <strong>Description:</strong> {listing.description}
                </p>
                <p>
                    <strong>Reason of Sale:</strong> {listing.reasonOfSale}
                </p>

                {listing.selectedListingPropertyValues.length > 0 && (
                    <>
                        <h4 className="mt-4">Property Values</h4>
                        <ul className="list-unstyled">
                            {listing.selectedListingPropertyValues.map(
                                (value) => (
                                    <li key={value.id}>
                                        <strong>
                                            {value.listingProperty.name}:
                                        </strong>{' '}
                                        {value.name}
                                    </li>
                                )
                            )}
                        </ul>
                    </>
                )}
            </div>

            {/* message seller */}
            <div className="mt-5 mb-5">
                {!showMessageForm ? (
                    <Button onClick={() => setShowMessageForm(true)}>
                        Message Seller
                    </Button>
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
                            <Button
                                onClick={handleSendMessage}
                                disabled={!messageText.trim()}
                                className="me-2"
                            >
                                Send
                            </Button>
                            <Button
                                variant="secondary"
                                onClick={() => setShowMessageForm(false)}
                            >
                                Cancel
                            </Button>
                        </div>
                    </div>
                )}
            </div>
        </div>
    );
}
