'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import Link from 'next/link';

interface CategoryDto {
  id: string;
  name: string;
  parentCategory?: CategoryDto;
  childrenCategories: CategoryDto[];
}

export default function AdminPage() {
  const [categories, setCategories] = useState<CategoryDto[]>([]);
  const [newCategoryName, setNewCategoryName] = useState('');
  const [selectedParentId, setSelectedParentId] = useState<string | null>(null);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await axios.get<CategoryDto[]>('https://localhost:7192/api/Categories');
        setCategories(response.data);
      } catch (error) {
        console.error('Failed to fetch categories', error);
      }
    };

    fetchCategories();
  }, []);

  const handleAddCategory = async (parentId: string | null = null) => {
    try {
      await axios.post('https://localhost:7192/api/Categories', {
        name: newCategoryName,
        parentCategoryId: parentId,
      });
      setNewCategoryName('');
      setSelectedParentId(null);
      const response = await axios.get<CategoryDto[]>('https://localhost:7192/api/Categories');
      setCategories(response.data);
    } catch (error) {
      console.error('Failed to add category', error);
    }
  };

  const handleDeleteCategory = async (categoryId: string) => {
    try {
      await axios.delete(`https://localhost:7192/api/Categories/${categoryId}`);
      const response = await axios.get<CategoryDto[]>('https://localhost:7192/api/Categories');
      setCategories(response.data);
    } catch (error) {
      console.error('Failed to delete category', error);
    }
  };

  const renderCategoryTree = (category: CategoryDto) => {
    return (
      <li key={category.id} className="mb-3">
        <div className="d-flex align-items-center">
          <Link href={`/category/${category.id}`}>
            <span>{category.name}</span>
          </Link>
          <button
            className="btn btn-sm btn-secondary ml-2"
            onClick={() => setSelectedParentId(category.id)}
          >
            Add Subcategory
          </button>
          <button
            className="btn btn-sm btn-danger ml-2"
            onClick={() => handleDeleteCategory(category.id)}
          >
            Delete
          </button>
        </div>
        {selectedParentId === category.id && (
          <div className="d-flex mt-2">
            <input
              type="text"
              className="form-control"
              value={newCategoryName}
              onChange={(e) => setNewCategoryName(e.target.value)}
              placeholder="Subcategory name"
            />
            <button
              className="btn btn-primary ml-2"
              onClick={() => handleAddCategory(category.id)}
            >
              Add
            </button>
            <button
              className="btn btn-secondary ml-2"
              onClick={() => setSelectedParentId(null)}
            >
              Cancel
            </button>
          </div>
        )}
        {category.childrenCategories.length > 0 && (
          <ul className="ml-4 mt-2">
            {category.childrenCategories.map((child) => renderCategoryTree(child))}
          </ul>
        )}
      </li>
    );
  };

  return (
    <div className="container mt-5">
      <h1>Admin Page - Manage Categories</h1>
      <div className="mt-4">
        <h2>Create a Top-Level Category</h2>
        <div className="d-flex">
          <input
            type="text"
            className="form-control"
            value={newCategoryName}
            onChange={(e) => setNewCategoryName(e.target.value)}
            placeholder="Category name"
          />
          <button
            className="btn btn-success ml-2"
            onClick={() => handleAddCategory(null)}
          >
            Add Category
          </button>
        </div>
      </div>
      <ul className="list-unstyled mt-4">
        {categories.length === 0 ? (
          <p>No categories available. Please add a new category above.</p>
        ) : (
          categories
            .filter((category) => !category.parentCategory) // Only top-level categories
            .map((category) => renderCategoryTree(category))
        )}
      </ul>
    </div>
  );
}
