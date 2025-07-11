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
        <li className="d-flex justify-content-between align-items-center mb-2 w-100">
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
                <>
                    <span className="me-auto">{value.name}</span>
                    <div className="d-flex gap-2">
                        <button
                            className="btn btn-sm btn-primary"
                            onClick={() => setIsEditing(true)}
                        >
                            Edit
                        </button>
                        <button
                            className="btn btn-sm btn-danger"
                            onClick={() => onDelete(value.id)}
                        >
                            Delete
                        </button>
                    </div>
                </>
            )}
        </li>
    );
}
