'use client';

import { useState } from 'react';

interface CategoryFormProps {
  onSubmit: (name: string) => void;
  initialValue?: string;
  placeholder?: string;
}

export default function CategoryForm({
  onSubmit,
  initialValue = '',
  placeholder = 'Category name',
}: CategoryFormProps) {
  const [categoryName, setCategoryName] = useState(initialValue);

  const handleSubmit = () => {
    if (categoryName.trim()) {
      onSubmit(categoryName);
      setCategoryName('');
    }
  };

  return (
    <div className="d-flex mt-2">
      <input
        type="text"
        className="form-control"
        value={categoryName}
        onChange={(e) => setCategoryName(e.target.value)}
        placeholder={placeholder}
      />
      <button className="btn btn-success ml-2" onClick={handleSubmit}>
        Add Category
      </button>
    </div>
  );
}
