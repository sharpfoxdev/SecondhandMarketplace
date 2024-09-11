'use client';

import { useState } from 'react';
import ListingPropertyValueForm from './ListingPropertyValueForm';
import ListingPropertyValueItem from './ListingPropertyValueItem';

interface ListingPropertyItemProps {
  property: {
    id: string;
    name: string;
    listingPropertyValues: { id: string; name: string }[];
  };
  onDelete: (propertyId: string) => void;
  onEdit: (propertyId: string, name: string) => void;
  onAddValue: (propertyId: string, valueName: string) => void;
  onDeleteValue: (valueId: string) => void;
  onEditValue: (valueId: string, name: string) => void;
}

export default function ListingPropertyItem({
  property,
  onDelete,
  onEdit,
  onAddValue,
  onDeleteValue,
  onEditValue,
}: ListingPropertyItemProps) {
  const [isEditing, setIsEditing] = useState(false);
  const [newName, setNewName] = useState(property.name);
  const [showAddValueForm, setShowAddValueForm] = useState(false);

  const handleEdit = () => {
    onEdit(property.id, newName);
    setIsEditing(false);
  };

  return (
    <li className="mb-4">
      <div className="d-flex align-items-center">
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
            <span>{property.name}</span>
            <button
              className="btn btn-sm btn-secondary ml-2"
              onClick={() => setIsEditing(true)}
            >
              Edit
            </button>
            <button className="btn btn-sm btn-danger ml-2" onClick={() => onDelete(property.id)}>
              Delete
            </button>
          </>
        )}
      </div>
      <button
        className="btn btn-sm btn-link"
        onClick={() => setShowAddValueForm(!showAddValueForm)}
      >
        {showAddValueForm ? 'Cancel' : 'Add Value'}
      </button>
      {showAddValueForm && (
        <ListingPropertyValueForm
          onSubmit={(valueName) => {
            onAddValue(property.id, valueName);
            setShowAddValueForm(false);
          }}
        />
      )}
      {property.listingPropertyValues.length > 0 && (
        <ul className="mt-2">
          {property.listingPropertyValues.map((value) => (
            <ListingPropertyValueItem
              key={value.id}
              value={value}
              onDelete={onDeleteValue}
              onEdit={onEditValue}
            />
          ))}
        </ul>
      )}
    </li>
  );
}
