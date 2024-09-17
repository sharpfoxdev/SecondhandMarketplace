'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import CategoryNameEdit from '../../../ui/admin/category/CategoryNameEdit';
import ListingPropertiesList from '../../../ui/admin/category/ListingPropertiesList';
import AvailablePropertiesList from '../../../ui/admin/category/AvailablePropertiesList';

interface ListingPropertyDto {
  id: string;
  name: string;
}

interface CategoryDto {
  id: string;
  name: string;
  listingProperties: ListingPropertyDto[];
}

export default function CategoryPage({ params }: { params: { id: string } }) {
  const { id } = params; // Get the category id from the route
  const [category, setCategory] = useState<CategoryDto | null>(null);
  const [categoryName, setCategoryName] = useState('');
  const [allProperties, setAllProperties] = useState<ListingPropertyDto[]>([]);
  const [selectedProperties, setSelectedProperties] = useState<string[]>([]);

  useEffect(() => {
    if (id) {
      const fetchCategory = async () => {
        try {
          const response = await axios.get<CategoryDto>(`https://localhost:7192/api/Categories/${id}`);
          setCategory(response.data);
          setCategoryName(response.data.name);
        } catch (error) {
          console.error('Failed to fetch category data', error);
        }
      };
      const fetchAllProperties = async () => {
        try {
          const response = await axios.get<ListingPropertyDto[]>(`https://localhost:7192/api/ListingProperties`);
          setAllProperties(response.data);
        } catch (error) {
          console.error('Failed to fetch listing properties', error);
        }
      };
      fetchCategory();
      fetchAllProperties();
    }
  }, [id]);

  const handleSaveCategoryName = async (newName: string) => {
    if (!category) return;
    try {
      await axios.put(`https://localhost:7192/api/Categories/${category.id}`, { name: newName });
    } catch (error) {
      console.error('Failed to update category name', error);
    }
  };

  const handleRemoveProperty = async (propertyId: string) => {
    if (!category) return;
    try {
      await axios.put(`https://localhost:7192/api/Categories/RemoveListingProperty/${category.id}`, { id: propertyId });
      const updatedCategory = { ...category };
      updatedCategory.listingProperties = updatedCategory.listingProperties.filter((prop) => prop.id !== propertyId);
      setCategory(updatedCategory);
    } catch (error) {
      console.error('Failed to remove property from category', error);
    }
  };

  const handleAddProperties = async () => {
    if (!category) return;
    try {
      await axios.put(`https://localhost:7192/api/Categories/AddListingProperties/${category.id}`, {listingPropertyIds : selectedProperties});
      const response = await axios.get<CategoryDto>(`https://localhost:7192/api/Categories/${category.id}`);
      setCategory(response.data); // Refresh the category after adding properties
      setSelectedProperties([]); // Clear selected properties
    } catch (error) {
      console.error('Failed to add properties to category', error);
    }
  };

  const handleCheckboxChange = (propertyId: string) => {
    if (selectedProperties.includes(propertyId)) {
      setSelectedProperties(selectedProperties.filter((id) => id !== propertyId));
    } else {
      setSelectedProperties([...selectedProperties, propertyId]);
    }
  };

  // Filter out properties already tied to the category
  const availableProperties = allProperties.filter(
    (prop) => !category?.listingProperties.some((tiedProp) => tiedProp.id === prop.id)
  );

  if (!category) return <p>Loading...</p>;

  return (
    <div className="container mt-5">
      <h1>Manage Category: {category.name}</h1>

      <CategoryNameEdit 
        categoryName={categoryName}
        onSave={handleSaveCategoryName} 
      />
      <ListingPropertiesList 
        listingProperties={category.listingProperties} 
        onRemove={handleRemoveProperty} />
      <AvailablePropertiesList
        availableProperties={availableProperties}
        selectedProperties={selectedProperties}
        onCheckboxChange={handleCheckboxChange}
        onAdd={handleAddProperties}
      />
    </div>
  );
}
