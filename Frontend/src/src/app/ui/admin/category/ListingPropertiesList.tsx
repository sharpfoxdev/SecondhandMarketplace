'use client';

interface ListingProperty {
  id: string;
  name: string;
}

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
      <h2>Listing Properties Tied to this Category</h2>
      <ul className="list-unstyled">
        {listingProperties.map((property) => (
          <li key={property.id} className="d-flex align-items-center">
            <span>{property.name}</span>
            <button
              className="btn btn-danger btn-sm ml-2"
              onClick={() => onRemove(property.id)}
            >
              Remove
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
