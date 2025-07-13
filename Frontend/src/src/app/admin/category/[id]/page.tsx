'use client';

import { useEffect, useState } from 'react';
import CategoryNameEdit from './components/CategoryNameEdit';
import ListingPropertiesList from './components/ListingPropertiesList';
import AvailablePropertiesList from './components/AvailablePropertiesList';
import {
    fetchCategoryById,
    updateCategory,
    removeListingPropertyFromCategory,
    addListingPropertiesToCategory,
} from '@/services/categoryService';
import { CategoryDetail } from '@/types/api/categories';
import { ListingProperty } from '@/types/api/listingProperties';
import { fetchListingProperties } from '@/services/listingPropertyService';
import RequireAdmin from '@/sharedComponents/RequireAdmin';

export default function CategoryPage({ params }: { params: { id: string } }) {
    const { id } = params; // get the category id from the route
    const [category, setCategory] = useState<CategoryDetail | null>(null);
    const [allProperties, setAllProperties] = useState<ListingProperty[]>([]);
    const [selectedProperties, setSelectedProperties] = useState<string[]>([]);

    useEffect(() => {
        if (id) {
            const fetchCategory = async () => {
                try {
                    const res = await fetchCategoryById(id);
                    setCategory(res);
                } catch (error) {
                    console.error('Failed to fetch category data', error);
                }
            };
            const fetchAllProperties = async () => {
                try {
                    const res = await fetchListingProperties();
                    setAllProperties(res);
                } catch (error) {
                    console.error('Failed to fetch listing properties', error);
                }
            };
            fetchCategory();
            fetchAllProperties();
        }
    }, [id, category?.name]);

    const handleSaveCategoryName = async (newName: string) => {
        if (!category) return;
        try {
            await updateCategory(category.id, { name: newName });
            const res = await fetchCategoryById(id);
            setCategory(res);
        } catch (error) {
            console.error('Failed to update category name', error);
        }
    };

    const handleRemoveProperty = async (propertyId: string) => {
        if (!category) return;
        try {
            await removeListingPropertyFromCategory(category.id, {
                id: propertyId,
            });
            const res = await fetchCategoryById(id);
            setCategory(res);
        } catch (error) {
            console.error('Failed to remove property from category', error);
        }
    };

    const handleAddProperties = async () => {
        if (!category) return;
        try {
            await addListingPropertiesToCategory(category.id, {
                listingPropertyIds: selectedProperties,
            });
            const res = await fetchCategoryById(id);
            setCategory(res);
            setSelectedProperties([]);
        } catch (error) {
            console.error('Failed to add properties to category', error);
        }
    };

    const handleCheckboxChange = (propertyId: string) => {
        if (selectedProperties.includes(propertyId)) {
            setSelectedProperties(
                selectedProperties.filter((id) => id !== propertyId)
            );
        } else {
            setSelectedProperties([...selectedProperties, propertyId]);
        }
    };

    // filter out properties already tied to the category
    const availableProperties = allProperties.filter(
        (prop) =>
            !category?.listingProperties.some(
                (tiedProp) => tiedProp.id === prop.id
            )
    );

    if (!category) return <p>Loading...</p>;

    return (
        <RequireAdmin>
            <div className="container mt-5">
                <h1 className="text-center text-md-left">
                    Manage Category: {category.name}
                </h1>
                <div className="my-4">
                    <div className="card">
                        <div className="card-body">
                            <CategoryNameEdit
                                categoryName={category.name}
                                onSave={handleSaveCategoryName}
                            />
                        </div>
                    </div>
                </div>
                <div className="row gx-4 gy-4">
                    <div className="col-12 col-md-6">
                        <div className="card h-100">
                            <div className="card-header">
                                Current Listing Properties
                            </div>
                            <div className="card-body">
                                <ListingPropertiesList
                                    listingProperties={
                                        category.listingProperties
                                    }
                                    onRemove={handleRemoveProperty}
                                />
                            </div>
                        </div>
                    </div>

                    <div className="col-12 col-md-6">
                        <div className="card h-100">
                            <div className="card-header">
                                Add More Properties
                            </div>
                            <div className="card-body">
                                <AvailablePropertiesList
                                    availableProperties={availableProperties}
                                    selectedProperties={selectedProperties}
                                    onCheckboxChange={handleCheckboxChange}
                                    onAdd={handleAddProperties}
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </RequireAdmin>
    );
}
