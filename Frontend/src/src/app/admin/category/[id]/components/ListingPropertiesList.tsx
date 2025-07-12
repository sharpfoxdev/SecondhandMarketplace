'use client';
import { ListingProperty } from '@/types/api/listingProperties';

interface ListingPropertiesListProps {
    listingProperties: ListingProperty[];
    onRemove: (propertyId: string) => void;
}

export default function ListingPropertiesList({
    listingProperties,
    onRemove,
}: ListingPropertiesListProps) {
    return (
        <div className="mt-4">
            <h2 className="h5 mb-3">
                Listing Properties Tied to this Category
            </h2>
            <ul className="p-0 m-0">
                {listingProperties.map((property, index) => (
                    <li
                        key={property.id}
                        className={`
            d-flex justify-content-between align-items-center
            py-2 ${index < listingProperties.length - 1 ? 'border-bottom' : ''}
          `}
                    >
                        <span>{property.name}</span>
                        <button
                            className="btn btn-sm btn-outline-danger"
                            onClick={() => onRemove(property.id)}
                        >
                            Remove
                        </button>
                    </li>
                ))}
                {listingProperties.length === 0 && (
                    <li className="text-center text-muted py-2">
                        No properties tied to this category.
                    </li>
                )}
            </ul>
        </div>
    );
}
