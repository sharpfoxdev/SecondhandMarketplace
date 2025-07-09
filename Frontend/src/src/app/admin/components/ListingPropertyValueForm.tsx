'use client';

import { useState } from 'react';

interface ListingPropertyValueFormProps {
  onSubmit: (name: string) => void;
}

export default function ListingPropertyValueForm({
  onSubmit,
}: ListingPropertyValueFormProps) {
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
        placeholder="Listing Property Value Name"
      />
      <button className="btn btn-success ml-2" onClick={handleSubmit}>
        Add Value
      </button>
    </div>
  );
}
