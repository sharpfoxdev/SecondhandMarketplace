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
import CustomDropdown from '@/sharedComponents/CustomDropdown';

export default function CreateListing() {
    const [categories, setCategories] = useState<Category[]>([]);
    const [statesOfItem, setStatesOfItem] = useState<StateOfItem[]>([]);
    const [selectedStateOfItemId, setSelectedStateOfItemId] =
        useState<string>('');
    const [selectedCategoryId, setSelectedCategoryId] = useState<string>('');
    const [listingProperties, setListingProperties] = useState<
        ListingPropertyDetail[]
    >([]);
    const [selectedPropertyValues, setSelectedPropertyValues] = useState<{
        [propertyId: string]: string;
    }>({});
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
            const category: CategoryDetail =
                await fetchCategoryById(categoryId);
            setListingProperties(category.listingProperties);
        } catch (err) {
            console.error('Failed to load category details', err);
        }
    };

    const handlePropertyValueChange = (propertyId: string, valueId: string) => {
        setSelectedPropertyValues((prev) => ({
            ...prev,
            [propertyId]: valueId,
        }));
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

        if (
            !selectedCategoryId ||
            !description ||
            !reasonOfSale ||
            !city ||
            !title ||
            !price ||
            !selectedStateOfItemId ||
            photos.length === 0
        ) {
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
                propertyValueSelection: Object.entries(
                    selectedPropertyValues
                ).map(([propertyId, selectedValueId]) => ({
                    listingPropertyId: propertyId,
                    selectedListingPropertyValueId: selectedValueId,
                })),
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
            alert(
                'Failed to create listing, check that you filled all the fields.'
            );
        }
    };

    return (
        <div className="container mt-5">
            <h1 className="mb-4">Create a New Listing</h1>

            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label
                        htmlFor="title"
                        className="form-label"
                    >
                        Title
                    </label>
                    <input
                        id="title"
                        type="text"
                        className="form-control"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                    />
                </div>

                <div className="mb-3">
                    <label
                        htmlFor="price"
                        className="form-label"
                    >
                        Price
                    </label>
                    <input
                        id="price"
                        type="number"
                        className="form-control"
                        value={price}
                        onChange={(e) => setPrice(Number(e.target.value))}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label
                        htmlFor="description"
                        className="form-label"
                    >
                        Description
                    </label>
                    <textarea
                        id="description"
                        className="form-control"
                        rows={3}
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <label
                        htmlFor="reasonOfSale"
                        className="form-label"
                    >
                        Reason for Sale
                    </label>
                    <textarea
                        id="reasonOfSale"
                        className="form-control"
                        rows={2}
                        value={reasonOfSale}
                        onChange={(e) => setReasonOfSale(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <label className="form-label">City</label>
                    <CitySelector
                        selectedCityId={city?.id}
                        onCitySelect={(c) => setCity(c)}
                    />
                </div>

                <div className="mb-3">
                    <label className="form-label">State of Item</label>
                    <CustomDropdown
                        options={statesOfItem.map((s) => ({
                            id: s.id,
                            name: s.name,
                        }))}
                        selectedId={selectedStateOfItemId}
                        onSelect={setSelectedStateOfItemId}
                        placeholder="Select a state"
                    />
                </div>

                <div className="mb-3">
                    <label className="form-label">Category</label>
                    <CustomDropdown
                        options={categories.map((c) => ({
                            id: c.id,
                            name: c.name,
                        }))}
                        selectedId={selectedCategoryId}
                        onSelect={handleCategorySelect}
                        placeholder="Select a category"
                    />
                </div>

                {listingProperties.length > 0 && (
                    <div className="mb-3">
                        <h5>Property Values</h5>
                        {listingProperties.map((prop) => (
                            <div
                                className="mb-2"
                                key={prop.id}
                            >
                                <label className="form-label">
                                    {prop.name}
                                </label>
                                <CustomDropdown
                                    options={prop.listingPropertyValues.map(
                                        (v) => ({ id: v.id, name: v.name })
                                    )}
                                    selectedId={
                                        selectedPropertyValues[prop.id] || ''
                                    }
                                    onSelect={(valId) =>
                                        handlePropertyValueChange(
                                            prop.id,
                                            valId
                                        )
                                    }
                                    placeholder={`Select ${prop.name}`}
                                />
                            </div>
                        ))}
                    </div>
                )}

                <div className="mb-3">
                    <label className="form-label">Upload Photos (max 20)</label>
                    <input
                        type="file"
                        className="form-control"
                        multiple
                        accept="image/*"
                        onChange={handlePhotoChange}
                    />
                    <div className="form-text">
                        Photos Selected: {photos.length}
                    </div>
                </div>

                <button
                    type="submit"
                    className="btn btn-primary w-100"
                >
                    Submit
                </button>
            </form>
        </div>
    );
}
