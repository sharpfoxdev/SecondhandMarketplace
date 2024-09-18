'use client';

import { useState, useEffect } from 'react';
import axios from 'axios';

interface Category {
  id: string;
  name: string;
  listingProperties: ListingProperty[];
}

interface ListingProperty {
  id: string;
  name: string;
  listingPropertyValues: ListingPropertyValue[];
}

interface ListingPropertyValue {
  id: string;
  name: string;
}

export default function CreateListing() {
  const [categories, setCategories] = useState<Category[]>([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState<string | null>(null);
  const [listingProperties, setListingProperties] = useState<ListingProperty[]>([]);
  const [selectedPropertyValues, setSelectedPropertyValues] = useState<{ [propertyId: string]: string }>({});
  const [title, setTitle] = useState('');
  const [price, setPrice] = useState<number | undefined>();
  const [description, setDescription] = useState('');
  const [reasonOfSale, setReasonOfSale] = useState('');
  const [photos, setPhotos] = useState<File[]>([]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const token = localStorage.getItem('token');
        const response = await axios.get<Category[]>('https://localhost:7192/api/Categories', {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setCategories(response.data);
      } catch (error) {
        console.error('Failed to fetch categories', error);
      }
    };
    fetchCategories();
  }, []);

  const handleCategorySelect = (categoryId: string) => {
    setSelectedCategoryId(categoryId);

    // Find the selected category and its listing properties
    const selectedCategory = categories.find((category) => category.id === categoryId);
    if (selectedCategory) {
      setListingProperties(selectedCategory.listingProperties);
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

    if (!selectedCategoryId || !title || !price || photos.length === 0) {
      alert('Please fill in all the required fields.');
      return;
    }

    try {
      const token = localStorage.getItem('token');

      // Prepare the listing data
      const listingData = {
        title,
        price,
        description,
        reasonOfSale,
        stateOfItemId: "2e0e5d47-2ff5-421e-945e-9fdc08cc762d", // todo placeholder, predelat
        categoryId: selectedCategoryId,
        propertyValueSelection: Object.keys(selectedPropertyValues).map((propertyId) => ({
          listringPropertyId: propertyId,
          selectedListingPropertyValueId: selectedPropertyValues[propertyId],
        })),
      };

      const response = await axios.post('https://localhost:7192/api/Listings', listingData, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      const listingId = response.data.id;

      // Upload photos
      const photoPromises = photos.map((photo) => {
        const formData = new FormData();
        formData.append('File', photo);
        formData.append('ListingId', listingId);

        return axios.post('https://localhost:7192/api/Images/Upload', formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${token}`,
          },
        });
      });

      await Promise.all(photoPromises);

      alert('Listing created successfully!');
    } catch (error) {
      console.error('Failed to create listing', error);
      alert('Failed to create listing.');
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
