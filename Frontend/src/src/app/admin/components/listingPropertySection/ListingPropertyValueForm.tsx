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
        <div className="d-flex flex-column flex-md-row align-items-start align-items-md-center gap-2 mt-2">
            <input
                type="text"
                className="form-control flex-grow-1"
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Listing Property Value Name"
            />
            <button
                type="button"
                className="btn btn-success w-100 w-md-auto"
                onClick={handleSubmit}
            >
                Add Value
            </button>
        </div>
    );
}
