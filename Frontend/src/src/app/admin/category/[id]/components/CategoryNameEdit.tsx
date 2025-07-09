'use client';

import { useState } from 'react';

interface CategoryNameEditProps {
  categoryName: string;
  onSave: (newName: string) => void;
}

export default function CategoryNameEdit({ categoryName, onSave }: CategoryNameEditProps) {
  const [name, setName] = useState(categoryName);

  const handleSave = () => {
    if (name.trim()) {
      onSave(name);
    }
  };

  return (
    <div className="mt-4">
      <label htmlFor="categoryName">Edit Category Name</label>
      <input
        type="text"
        className="form-control"
        id="categoryName"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <button className="btn btn-primary mt-2" onClick={handleSave}>
        Save
      </button>
    </div>
  );
}
