'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import ListingGrid from '../../ui/ListingGrid';

interface Listing {
  id: string;
  title: string;
  description: string;
  price: number;
  images: { imageUrl: string }[];
}

interface ListingPropertyValue {
  id: string;
  name: string;
}

interface ListingProperty {
  id: string;
  name: string;
  listingPropertyValues: ListingPropertyValue[];
}

interface StateOfItem {
  id: string;
  name: string;
}

interface Category {
  id: string;
  name: string;
  listingProperties: ListingProperty[];
}

interface ListingFilter {
  priceMin?: number | null;
  priceMax?: number | null;
  stateOfItemIds: string[];
  selectedListingPropertyValueIds: string[];
}

export default function CategoryPage({ params }: { params: { categoryName: string } }) {
  const { categoryName } = params;
  const [category, setCategory] = useState<Category | null>(null);
  const [listings, setListings] = useState<Listing[]>([]);
  const [statesOfItem, setStatesOfItem] = useState<StateOfItem[]>([]);
  const [loading, setLoading] = useState(true);

  // Filter states
  const [priceMin, setPriceMin] = useState<number | null>(null);
  const [priceMax, setPriceMax] = useState<number | null>(null);
  const [selectedStateOfItems, setSelectedStateOfItems] = useState<string[]>([]);
  const [selectedPropertyValues, setSelectedPropertyValues] = useState<string[]>([]);

  const handleStateOfItemChange = (stateId: string) => {
    setSelectedStateOfItems((prev) =>
      prev.includes(stateId) ? prev.filter((id) => id !== stateId) : [...prev, stateId]
    );
  };

  const handlePropertyValueChange = (valueId: string) => {
    setSelectedPropertyValues((prev) =>
      prev.includes(valueId) ? prev.filter((id) => id !== valueId) : [...prev, valueId]
    );
  };

  // maps empty input to null (otherwise it would be 0 and it breaks filtering)
  const handlePriceMinChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setPriceMin(value === '' ? null : Number(value));
  };

  const handlePriceMaxChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = e.target.value;
    setPriceMax(value === '' ? null : Number(value));
  };

    const applyFilter = async (initialLoad = false) => {
      //during the initial load we use an empty filter
    setLoading(true);
      try {
      const filter: ListingFilter = {
        priceMin: initialLoad ? null : priceMin,
        priceMax: initialLoad ? null : priceMax,
        stateOfItemIds: selectedStateOfItems,
        selectedListingPropertyValueIds: initialLoad ? [] : selectedPropertyValues,
      };

      const response = await axios.post<Listing[]>(
        `https://localhost:7192/api/Categories/${categoryName}`,
        filter,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );
      setListings(response.data);
    } catch (error) {
      console.error('Failed to fetch listings', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const categoryResponse = await axios.get<Category>(`https://localhost:7192/api/Categories/GetByName/${categoryName}`);
        setCategory(categoryResponse.data);

        const statesResponse = await axios.get<StateOfItem[]>('https://localhost:7192/api/StateOfItem');
        setStatesOfItem(statesResponse.data);
      } catch (error) {
        console.error('Failed to fetch category data', error);
      } finally {
        // Load listings with an empty filter (initial load)
        await applyFilter(true);  // Set `initialLoad` to true for the first call
      }
    };

    if (categoryName) {
      fetchData();
    }
  }, [categoryName]);

  if (loading) {
    return <div className="container mt-5"><p>Loading...</p></div>;
  }

  return (
    <div className="container mt-5">
      <div className="row">
        {/* Filter Section */}
        <div className="col-md-3">
          <h4>Filter Listings</h4>

          {/* Price Filter */}
          <div className="mb-4">
            <h5>Price</h5>
            <div className="mb-2">
              <label htmlFor="priceMin">Min Price</label>
              <input
                type="number"
                id="priceMin"
                className="form-control"
                value={priceMin !== null ? priceMin : ''}
                onChange={handlePriceMinChange}
              />
            </div>
            <div className="mb-2">
              <label htmlFor="priceMax">Max Price</label>
              <input
                type="number"
                id="priceMax"
                className="form-control"
                value={priceMax !== null ? priceMax : ''}
                onChange={handlePriceMaxChange}
              />
            </div>
          </div>

          {/* State of Item Filter */}
          <div className="mb-4">
            <h5>State of Item</h5>
            {statesOfItem.map((state) => (
              <div key={state.id} className="form-check">
                <input
                  type="checkbox"
                  className="form-check-input"
                  id={state.id}
                  value={state.id}
                  onChange={() => handleStateOfItemChange(state.id)}
                  checked={selectedStateOfItems.includes(state.id)}
                />
                <label htmlFor={state.id} className="form-check-label">
                  {state.name}
                </label>
              </div>
            ))}
          </div>

          {/* Listing Properties Filter */}
          <div className="mb-4">
            <h5>Listing Properties</h5>
            {category?.listingProperties.map((property) => (
              <div key={property.id} className="mb-3">
                <h6>{property.name}</h6>
                {property.listingPropertyValues.map((value) => (
                  <div key={value.id} className="form-check">
                    <input
                      type="checkbox"
                      className="form-check-input"
                      id={value.id}
                      value={value.id}
                      onChange={() => handlePropertyValueChange(value.id)}
                      checked={selectedPropertyValues.includes(value.id)}
                    />
                    <label htmlFor={value.id} className="form-check-label">
                      {value.name}
                    </label>
                  </div>
                ))}
              </div>
            ))}
          </div>

          {/* Apply Filter Button */}
          <button className="btn btn-primary" onClick={() => applyFilter(false)}>
            Apply Filter
          </button>
        </div>

        {/* Listings Section */}
        <div className="col-md-9">
          <h1 className="mb-4">Listings for {category?.name}</h1>
          {listings.length === 0 ? (
            <p>No listings available in this category.</p>
          ) : (
            <ListingGrid listings={listings} />
          )}
        </div>
      </div>
    </div>
  );
}
