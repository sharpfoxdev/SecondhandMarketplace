'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import ListingPropertyForm from './ListingPropertyForm';
import ListingPropertyItem from './ListingPropertyItem';

interface ListingProperty {
  id: string;
  name: string;
  listingPropertyValues: { id: string; name: string }[];
}

export default function ListingPropertySection() {
  const [listingProperties, setListingProperties] = useState<ListingProperty[]>([]);

  useEffect(() => {
    const fetchListingProperties = async () => {
      try {
        const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
        setListingProperties(response.data);
      } catch (error) {
        console.error('Failed to fetch listing properties', error);
      }
    };

    fetchListingProperties();
  }, []);

  const handleAddProperty = async (name: string) => {
    try {
      await axios.post('https://localhost:7192/api/ListingProperties', { name });
      const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
      setListingProperties(response.data);
    } catch (error) {
      console.error('Failed to add listing property', error);
    }
  };

  const handleDeleteProperty = async (propertyId: string) => {
    try {
      await axios.delete(`https://localhost:7192/api/ListingProperties/${propertyId}`);
      const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
      setListingProperties(response.data);
    } catch (error) {
      console.error('Failed to delete listing property', error);
    }
  };

  const handleEditProperty = async (propertyId: string, name: string) => {
    try {
      await axios.put(`https://localhost:7192/api/ListingProperties/${propertyId}`, { name });
      const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
      setListingProperties(response.data);
    } catch (error) {
      console.error('Failed to update listing property', error);
    }
  };

  const handleAddValue = async (propertyId: string, valueName: string) => {
    try {
      await axios.post(`https://localhost:7192/api/ListingProperties/AddPropertyValues/${propertyId}`, [{ name: valueName }]);
      const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
      setListingProperties(response.data);
    } catch (error) {
      console.error('Failed to add listing property value', error);
    }
  };

  const handleDeleteValue = async (valueId: string) => {
    try {
      await axios.delete(`https://localhost:7192/api/ListingPropertyValues/${valueId}`);
      const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
      setListingProperties(response.data);
    } catch (error) {
      console.error('Failed to delete listing property value', error);
    }
  };

  const handleEditValue = async (valueId: string, name: string) => {
    try {
      await axios.put(`https://localhost:7192/api/ListingPropertyValues/${valueId}`, { name });
      const response = await axios.get<ListingProperty[]>('https://localhost:7192/api/ListingProperties');
      setListingProperties(response.data);
    } catch (error) {
      console.error('Failed to update listing property value', error);
    }
  };

  return (
    <div className="mt-4">
      <h2>Manage Listing Properties</h2>
      <ListingPropertyForm onSubmit={handleAddProperty} />
      <ul className="list-unstyled mt-4">
        {listingProperties.map((property) => (
          <ListingPropertyItem
            key={property.id}
            property={property}
            onDelete={handleDeleteProperty}
            onEdit={handleEditProperty}
            onAddValue={handleAddValue}
            onDeleteValue={handleDeleteValue}
            onEditValue={handleEditValue}
          />
        ))}
      </ul>
    </div>
  );
}
