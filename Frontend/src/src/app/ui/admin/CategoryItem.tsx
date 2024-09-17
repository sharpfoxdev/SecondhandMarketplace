'use client';

import Link from 'next/link';
import CategoryForm from './CategoryForm';
import { useState } from 'react';
interface CategoryDto {
  id: string;
  name: string;
  childrenCategories: CategoryDto[];
}

interface CategoryItemProps {
  category: CategoryDto;
  onAddSubcategory: (name: string, parentId: string) => void;
  onDeleteCategory: (categoryId: string) => void;
}

export default function CategoryItem({
  category,
  onAddSubcategory,
  onDeleteCategory,
}: CategoryItemProps) {
  const [showAddForm, setShowAddForm] = useState(false);

  return (
    <li className="mb-3">
      <div className="d-flex align-items-center">
        <Link href={`/admin/category/${category.id}`}>
          <span>{category.name}</span>
        </Link>
        <button
          className="btn btn-sm btn-secondary ml-2"
          onClick={() => setShowAddForm(!showAddForm)}
        >
          {showAddForm ? 'Cancel' : 'Add Subcategory'}
        </button>
        <button
          className="btn btn-sm btn-danger ml-2"
          onClick={() => onDeleteCategory(category.id)}
        >
          Delete
        </button>
      </div>
      {showAddForm && (
        <CategoryForm
          onSubmit={(name) => {
            onAddSubcategory(name, category.id);
            setShowAddForm(false);
          }}
          placeholder="Subcategory name"
        />
      )}
      {category.childrenCategories.length > 0 && (
        <ul className="ml-4 mt-2">
          {category.childrenCategories.map((child) => (
            <CategoryItem
              key={child.id}
              category={child}
              onAddSubcategory={onAddSubcategory}
              onDeleteCategory={onDeleteCategory}
            />
          ))}
        </ul>
      )}
    </li>
  );
}
