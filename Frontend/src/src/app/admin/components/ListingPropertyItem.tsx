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
        <li className="mb-4 list-unstyled">
            <div className="card shadow-sm">
                <div className="card-body">
                    <div className="d-flex flex-column flex-md-row justify-content-between align-items-start align-items-md-center gap-2">
                        {isEditing ? (
                            <div className="d-flex flex-grow-1 gap-2 flex-wrap">
                                <input
                                    type="text"
                                    className="form-control flex-grow-1"
                                    value={newName}
                                    onChange={(e) => setNewName(e.target.value)}
                                />
                                <button className="btn btn-primary" onClick={handleEdit}>
                                    Confirm
                                </button>
                            </div>
                        ) : (
                            <span className="h6 mb-0">{property.name}</span>
                        )}

                        <div className="d-flex flex-wrap gap-2">
                            {!isEditing && (
                                <>
                                    <button
                                        className="btn btn-sm btn-primary"
                                        onClick={() => setIsEditing(true)}
                                    >
                                        Edit
                                    </button>
                                    <button
                                        className="btn btn-sm btn-danger"
                                        onClick={() => onDelete(property.id)}
                                    >
                                        Delete
                                    </button>
                                </>
                            )}

                            <button
                                className="btn btn-sm btn-secondary"
                                onClick={() => setShowAddValueForm((v) => !v)}
                            >
                                {showAddValueForm ? 'Cancel' : 'Add Value'}
                            </button>
                        </div>
                    </div>

                    {showAddValueForm && (
                        <div className="mt-3">
                            <ListingPropertyValueForm
                                onSubmit={(valueName) => {
                                    onAddValue(property.id, valueName)
                                    setShowAddValueForm(false)
                                }}
                            />
                        </div>
                    )}

                    {property.listingPropertyValues.length > 0 && (
                        <ul className="mt-3 ps-0">
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
                </div>
            </div>
        </li>
    );
}
