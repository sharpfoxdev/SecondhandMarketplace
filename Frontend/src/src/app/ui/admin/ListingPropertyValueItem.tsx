'use client';

import { useState } from 'react';

interface ListingPropertyValueItemProps {
  value: { id: string; name: string };
  onDelete: (valueId: string) => void;
  onEdit: (valueId: string, name: string) => void;
}

export default function ListingPropertyValueItem({
  value,
  onDelete,
  onEdit,
}: ListingPropertyValueItemProps) {
  const [isEditing, setIsEditing] = useState(false);
  const [newName, setNewName] = useState(value.name);

  const handleEdit = () => {
    onEdit(value.id, newName);
    setIsEditing(false);
  };

  return (
    <li className="d-flex align-items-center">
      {isEditing ? (
        <>
          <input
            type="text"
            className="form-control"
            value={newName}
            onChange={(e) => setNewName(e.target.value)}
          />
          <button className="btn btn-primary ml-2" onClick={handleEdit}>
            Confirm
          </button>
        </>
      ) : (
        <>
          <span>{value.name}</span>
          <button
            className="btn btn-sm btn-secondary ml-2"
            onClick={() => setIsEditing(true)}
          >
            Edit
          </button>
          <button className="btn btn-sm btn-danger ml-2" onClick={() => onDelete(value.id)}>
            Delete
          </button>
        </>
      )}
    </li>
  );
}
