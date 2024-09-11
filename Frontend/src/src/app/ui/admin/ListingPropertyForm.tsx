'use client';

import { useState } from 'react';

interface ListingPropertyFormProps {
  onSubmit: (name: string) => void;
}

export default function ListingPropertyForm({ onSubmit }: ListingPropertyFormProps) {
  const [name, setName] = useState('');

  const handleSubmit = () => {
    if (name.trim()) {
      onSubmit(name);
      setName('');
    }
  };

  return (
    <div className="d-flex mt-2">
      <input
        type="text"
        className="form-control"
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Listing Property Name"
      />
      <button className="btn btn-primary ml-2" onClick={handleSubmit}>
        Add Listing Property
      </button>
    </div>
  );
}
