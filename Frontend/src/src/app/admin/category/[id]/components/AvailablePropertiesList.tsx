'use client';

interface ListingProperty {
  id: string;
  name: string;
}

interface AvailablePropertiesListProps {
  availableProperties: ListingProperty[];
  selectedProperties: string[];
  onCheckboxChange: (propertyId: string) => void;
  onAdd: () => void;
}

export default function AvailablePropertiesList({
  availableProperties,
  selectedProperties,
  onCheckboxChange,
  onAdd,
}: AvailablePropertiesListProps) {
  return (
    <div className="mt-4">
      <h2>Add Listing Properties to Category</h2>
      <ul className="list-unstyled">
        {availableProperties.map((property) => (
          <li key={property.id} className="d-flex align-items-center">
            <input
              type="checkbox"
              checked={selectedProperties.includes(property.id)}
              onChange={() => onCheckboxChange(property.id)}
            />
            <span className="ml-2">{property.name}</span>
          </li>
        ))}
      </ul>
      <button className="btn btn-success mt-2" onClick={onAdd}>
        Add Selected Properties
      </button>
    </div>
  );
}
