'use client';

import { useState, useEffect } from 'react';
import { City } from '@/types/api/cities';
import CitySelector from '@/sharedComponents/CitySelector';
import { fetchCategories } from '@/services/categoryService';
import { fetchStatesOfItem } from '@/services/stateOfItemService';
import { Category } from '@/types/api/categories';
import { StateOfItem } from '@/types/api/stateOfItem';
import { CategoryDetail } from '@/types/api/categories';
import { ListingPropertyDetail } from '@/types/api/listingProperties';
import { fetchCategoryById } from '@/services/categoryService';
import { CreateListingRequest } from '@/types/api/listings';
import { uploadImage } from '@/services/imageService';
import { createListing } from '@/services/listingService';
import { useRouter } from 'next/navigation';

export default function CreateListing() {
    const [categories, setCategories] = useState<Category[]>([]);
    const [statesOfItem, setStatesOfItem] = useState<StateOfItem[]>([]);
    const [selectedStateOfItemId, setSelectedStateOfItemId] = useState<string | null>(null);
    const [selectedCategoryId, setSelectedCategoryId] = useState<string | null>(null);
    const [listingProperties, setListingProperties] = useState<ListingPropertyDetail[]>([]);
    const [selectedPropertyValues, setSelectedPropertyValues] = useState<{ [propertyId: string]: string }>({});
    const [title, setTitle] = useState('');
    const [price, setPrice] = useState<number | undefined>();
    const [description, setDescription] = useState('');
    const [reasonOfSale, setReasonOfSale] = useState('');
    const [city, setCity] = useState<City | null>(null);
    const [photos, setPhotos] = useState<File[]>([]);
    const router = useRouter();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const states = await fetchStatesOfItem();
                const categories = await fetchCategories();
                setCategories(categories);
                setStatesOfItem(states);
            } catch (error) {
                console.error('Failed to fetch data', error);
            }
        };
        fetchData();
    }, []);

    const handleCategorySelect = async (categoryId: string) => {
        setSelectedCategoryId(categoryId);
        try {
            const category: CategoryDetail = await fetchCategoryById(categoryId);
            setListingProperties(category.listingProperties);
        } catch (err) {
            console.error('Failed to load category details', err);
        }
    };

    const handlePropertyValueChange = (propertyId: string, valueId: string) => {
        setSelectedPropertyValues((prev) => ({ ...prev, [propertyId]: valueId }));
    };

    const handlePhotoChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.files) {
            const fileArray = Array.from(e.target.files);
            if (fileArray.length + photos.length <= 20) {
                setPhotos((prev) => [...prev, ...fileArray]);
            } else {
                alert('You can only upload a maximum of 20 photos.');
            }
        }
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (!selectedCategoryId || !description || !reasonOfSale ||
            !city || !title || !price || !selectedStateOfItemId || photos.length === 0) {
            alert('Please fill in all the required fields.');
            return;
        }
        try {
            const listingData: CreateListingRequest = {
                title,
                price,
                description,
                reasonOfSale,
                stateOfItemId: selectedStateOfItemId,
                categoryId: selectedCategoryId,
                cityId: city.id,
                propertyValueSelection: Object.entries(selectedPropertyValues).map(
                    ([propertyId, selectedValueId]) => ({
                        listingPropertyId: propertyId,
                        selectedListingPropertyValueId: selectedValueId,
                    })
                ),
            };

            const created = await createListing(listingData);
            const listingId = created.id;

            await Promise.all(
                photos.map((file) =>
                    uploadImage({
                        file,
                        listingId,
                    })
                )
            );
            router.push('/');
        } catch (err) {
            console.error('Failed to create listing', err);
            alert('Failed to create listing, check that you filled all the fields.');
        }
    };

    return (
        <div className="container mt-5">
            <h1>Create a New Listing</h1>
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label htmlFor="title" className="form-label">
                        Title
                    </label>
                    <input
                        type="text"
                        className="form-control"
                        id="title"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="price" className="form-label">
                        Price
                    </label>
                    <input
                        type="number"
                        className="form-control"
                        id="price"
                        value={price}
                        onChange={(e) => setPrice(Number(e.target.value))}
                        required
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="description" className="form-label">
                        Description
                    </label>
                    <textarea
                        className="form-control"
                        id="description"
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <label htmlFor="reasonOfSale" className="form-label">
                        Reason for Sale
                    </label>
                    <textarea
                        className="form-control"
                        id="reasonOfSale"
                        value={reasonOfSale}
                        onChange={(e) => setReasonOfSale(e.target.value)}
                    />
                </div>
                <div className='mb-3'>
                    <label className='form-label'>City</label>
                    <CitySelector
                        selectedCityId={city?.id}
                        onCitySelect={c => setCity(c)}
                    />
                </div>

                {/* State of item selection */}
                <div className="mb-3">
                    <label className="form-label">Select State of Item</label>
                    <select
                        className="form-select"
                        value={selectedStateOfItemId || ''}
                        onChange={(e) => setSelectedStateOfItemId(e.target.value)}
                        required
                    >
                        <option value="">Select a State of Item</option>
                        {statesOfItem.map((state) => (
                            <option key={state.id} value={state.id}>
                                {state.name}
                            </option>
                        ))}
                    </select>
                </div>

                {/* Category selection */}
                <div className="mb-3">
                    <label className="form-label">Select Category</label>
                    <select
                        className="form-select"
                        value={selectedCategoryId || ''}
                        onChange={(e) => handleCategorySelect(e.target.value)}
                        required
                    >
                        <option value="">Select a Category</option>
                        {categories.map((category) => (
                            <option key={category.id} value={category.id}>
                                {category.name}
                            </option>
                        ))}
                    </select>
                </div>

                {/* Listing property values */}
                {listingProperties.length > 0 && (
                    <div className="mb-3">
                        <h5>Property Values</h5>
                        {listingProperties.map((property) => (
                            <div key={property.id} className="mb-2">
                                <label>{property.name}</label>
                                <select
                                    className="form-select"
                                    onChange={(e) => handlePropertyValueChange(property.id, e.target.value)}
                                >
                                    <option value="">Select a value</option>
                                    {property.listingPropertyValues.map((value) => (
                                        <option key={value.id} value={value.id}>
                                            {value.name}
                                        </option>
                                    ))}
                                </select>
                            </div>
                        ))}
                    </div>
                )}

                {/* Photo upload */}
                <div className="mb-3">
                    <label className="form-label">Upload Photos (max 20)</label>
                    <input type="file" className="form-control" multiple onChange={handlePhotoChange} />
                    <div className="mt-2">Photos Selected: {photos.length}</div>
                </div>

                <button type="submit" className="btn btn-primary">
                    Submit
                </button>
            </form>
        </div>
    );
}
