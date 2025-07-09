'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import CitySelector from './CitySelector';
import { City } from '@/types/api/cities';
import { ListingGrid } from './ListingGrid';
import { ListingFilter } from '@/types/api/categories';
import { Ordering, OrderingDirection } from '@/types/api/categories';
import { StateOfItem } from '@/types/api/stateOfItem';

export interface FilterPanelProps {
  priceEnabled?: boolean;
  userEnabled?: boolean;
  cityEnabled?: boolean;
  radiusEnabled?: boolean;
  searchEnabled?: boolean;
  orderingEnabled?: boolean;
  stateOfItemEnabled?: boolean;
  listingPropertiesEnabled?: boolean;
  onFilterSumbited: (filter: ListingFilter) => void;
}

export function FilterPanel({
  priceEnabled = true,
  userEnabled = false,
  cityEnabled = false,
  radiusEnabled = false,
  searchEnabled = false,
  orderingEnabled = true,
  stateOfItemEnabled = true,
  listingPropertiesEnabled = true,
  onFilterSumbited
}: FilterPanelProps) {
  const [priceMin, setPriceMin] = useState<number | null>(null);
  const [priceMax, setPriceMax] = useState<number | null>(null);
  const [sellerId, setSellerId] = useState<string | null>(null);
  const [city, setCity] = useState<City | null>(null);
  const [radius, setRadius] = useState<number | null>(null);
  const [search, setSearch] = useState('');
  const [ordering, setOrdering] = useState<Ordering>(Ordering.CreatedAt);
  const [direction, setDirection] = useState<OrderingDirection>(OrderingDirection.Descending);
  const [selectedStateOfItems, setSelectedStateOfItems] = useState<string[]>([]);
  const [selectedPropertyValues, setSelectedPropertyValues] = useState<string[]>([]);
  const [statesOfItem, setStatesOfItem] = useState<StateOfItem[]>([]);

  useEffect(() => {
    onFilterSumbited({ priceMin, priceMax, sellerId, cityId: city?.id || null, radius, search, ordering, orderingDirection: direction });
  }, [priceMin, priceMax, sellerId, city, radius, search, ordering, direction]);

  return (
    <div className="filter-panel">
      {priceEnabled && (
        <div className="mb-3">
          <h5>Price</h5>
          <input type="number" placeholder="Min" className="form-control mb-1" value={priceMin ?? ''} onChange={e => setPriceMin(e.target.value === '' ? null : Number(e.target.value))} />
          <input type="number" placeholder="Max" className="form-control" value={priceMax ?? ''} onChange={e => setPriceMax(e.target.value === '' ? null : Number(e.target.value))} />
        </div>
      )}

      {userEnabled && (
        <div className="mb-3">
          <h5>Seller</h5>
          <input type="text" placeholder="Seller" className="form-control" value={sellerId ?? ''} onChange={e => setSellerId(e.target.value || null)} />
        </div>
      )}

      {cityEnabled && (
        <div className="mb-3">
          <h5>City</h5>
          <CitySelector onCitySelect={setCity} placeholder="Select city" />
        </div>
      )}

      {radiusEnabled && (
        <div className="mb-3">
          <h5>Radius (m)</h5>
          <input type="number" className="form-control" value={radius ?? ''} onChange={e => setRadius(e.target.value === '' ? null : Number(e.target.value))} />
        </div>
      )}

      {searchEnabled && (
        <div className="mb-3">
          <h5>Search</h5>
          <input type="text" className="form-control" value={search} onChange={e => setSearch(e.target.value)} />
        </div>
      )}

      {orderingEnabled && (
        <div className="mb-3">
          <h5>Order By</h5>
          <div className="d-flex gap-2">
            <button type="button" className={ordering === Ordering.CreatedAt ? 'btn btn-primary' : 'btn btn-outline-secondary'} onClick={() => setOrdering(Ordering.CreatedAt)}>Date</button>
            <button type="button" className={ordering === Ordering.Price ? 'btn btn-primary' : 'btn btn-outline-secondary'} onClick={() => setOrdering(Ordering.Price)}>Price</button>
          </div>
          <div className="mt-2 d-flex gap-2">
            <button type="button" className={direction === OrderingDirection.Ascending ? 'btn btn-secondary' : 'btn btn-outline-secondary'} onClick={() => setDirection(OrderingDirection.Ascending)}>↑</button>
            <button type="button" className={direction === OrderingDirection.Descending ? 'btn btn-secondary' : 'btn btn-outline-secondary'} onClick={() => setDirection(OrderingDirection.Descending)}>↓</button>
          </div>
        </div>
      )}

      {stateOfItemEnabled && (
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
      )}

      {listingPropertiesEnabled && (
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
      )}
      <button className="btn btn-primary" onClick={() => applyFilter(false)}>
        Apply Filter
      </button>
    </div>
  );
}
