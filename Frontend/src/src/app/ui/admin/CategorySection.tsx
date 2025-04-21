'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import CategoryForm from './CategoryForm';
import CategoryTree from './CategoryTree';

interface CategoryDto {
  id: string;
  name: string;
  parentCategory?: CategoryDto;
  childrenCategories: CategoryDto[];
}

export default function CategorySection() {
  const [categories, setCategories] = useState<CategoryDto[]>([]);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await axios.get<CategoryDto[]>('https://localhost:7192/api/Categories/Hierarchy');
        setCategories(response.data);
      } catch (error) {
        console.error('Failed to fetch categories', error);
      }
    };

    fetchCategories();
  }, []);

  const handleAddCategory = async (name: string, parentId: string | null = null) => {
    try {
      await axios.post('https://localhost:7192/api/Categories', {
        name,
        parentCategoryId: parentId,
      });
      const response = await axios.get<CategoryDto[]>('https://localhost:7192/api/Categories/Hierarchy');
      setCategories(response.data);
    } catch (error) {
      console.error('Failed to add category', error);
    }
  };

  const handleDeleteCategory = async (categoryId: string) => {
    try {
      await axios.delete(`https://localhost:7192/api/Categories/${categoryId}`);
      const response = await axios.get<CategoryDto[]>('https://localhost:7192/api/Categories/Hierarchys');
      setCategories(response.data);
    } catch (error) {
      console.error('Failed to delete category', error);
    }
  };

  return (
    <div className="container mt-5">
      <h1>Admin Page - Manage Categories</h1>
      <div className="mt-4">
        <h2>Create a Top-Level Category</h2>
        <CategoryForm
          onSubmit={(name: string) => handleAddCategory(name, null)}
        />
      </div>
      <CategoryTree
        categories={categories}
        onAddSubcategory={handleAddCategory}
        onDeleteCategory={handleDeleteCategory}
      />
    </div>
  );
}
