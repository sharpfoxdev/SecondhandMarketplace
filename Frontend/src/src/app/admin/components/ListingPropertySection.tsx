'use client';

import { useEffect, useState } from 'react';
import ListingPropertyForm from './ListingPropertyForm';
import ListingPropertyItem from './ListingPropertyItem';
import { fetchListingProperties, createListingProperty, deleteListingProperty, updateListingProperty, addPropertyValuesToProperty } from '@/services/listingPropertyService';
import { CreateListingPropertyRequest, ListingPropertyDetail } from '@/types/api/listingProperties';
import { deleteListingPropertyValue, updateListingPropertyValue } from '@/services/listingPropertyValueService';


export default function ListingPropertySection() {
    const [listingProperties, setListingProperties] = useState<ListingPropertyDetail[]>([]);

    useEffect(() => {
        const getListingProperties = async () => {
            try {
                const res = await fetchListingProperties();
                setListingProperties(res);
            } catch (error) {
                console.error('Failed to fetch listing properties', error);
            }
        };
        getListingProperties();
    }, []);

    const handleAddProperty = async (name: string) => {
        try {
            const request: CreateListingPropertyRequest = {
                name: name
            }
            await createListingProperty(request)
            const res = await fetchListingProperties();
            setListingProperties(res);
        } catch (error) {
            console.error('Failed to add listing property', error);
        }
    };

    const handleDeleteProperty = async (propertyId: string) => {
        try {
            await deleteListingProperty(propertyId);
            const res = await fetchListingProperties();
            setListingProperties(res);
        } catch (error) {
            console.error('Failed to delete listing property', error);
        }
    };

    const handleEditProperty = async (propertyId: string, name: string) => {
        try {
            await updateListingProperty(propertyId, { name });
            const res = await fetchListingProperties();
            setListingProperties(res);
        } catch (error) {
            console.error('Failed to update listing property', error);
        }
    };

    const handleAddValue = async (propertyId: string, valueName: string) => {
        try {

            await addPropertyValuesToProperty(propertyId, [{ name: valueName }])
            const res = await fetchListingProperties();
            setListingProperties(res);
        } catch (error) {
            console.error('Failed to add listing property value', error);
        }
    };

    const handleDeleteValue = async (valueId: string) => {
        try {
            await deleteListingPropertyValue(valueId);
            const res = await fetchListingProperties();
            setListingProperties(res);
        } catch (error) {
            console.error('Failed to delete listing property value', error);
        }
    };

    const handleEditValue = async (valueId: string, name: string) => {
        try {
            await updateListingPropertyValue(valueId, { name })
            const res = await fetchListingProperties();
            setListingProperties(res);
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
