'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import CitySelector from '../app/ui/CitySelector';
import { CityDto } from '@/types/api';
import { ListingGrid } from './ListingGrid';

export interface FilterPanelProps {
  priceEnabled?: boolean;
  userEnabled?: boolean;
  cityEnabled?: boolean;
  radiusEnabled?: boolean;
  searchEnabled?: boolean;
  orderingEnabled?: boolean;
  onFilterChange: (filter: any) => void;
}

export function FilterPanel({
  priceEnabled = true,
  userEnabled = false,
  cityEnabled = false,
  radiusEnabled = false,
  searchEnabled = false,
  orderingEnabled = true,
  onFilterChange
}: FilterPanelProps) {
  const [priceMin, setPriceMin] = useState<number | null>(null);
  const [priceMax, setPriceMax] = useState<number | null>(null);
  const [sellerId, setSellerId] = useState<string | null>(null);
  const [city, setCity] = useState<CityDto | null>(null);
  const [radius, setRadius] = useState<number | null>(null);
  const [search, setSearch] = useState('');
  const [ordering, setOrdering] = useState<'CreatedAt' | 'Price'>('CreatedAt');
  const [direction, setDirection] = useState<'Ascending' | 'Descending'>('Descending');

  useEffect(() => {
    onFilterChange({ priceMin, priceMax, sellerId, cityId: city?.id || null, radius, search, ordering, orderingDirection: direction });
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
          <input type="text" placeholder="Seller ID" className="form-control" value={sellerId ?? ''} onChange={e => setSellerId(e.target.value || null)} />
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
            <button type="button" className={ordering === 'CreatedAt' ? 'btn btn-primary' : 'btn btn-outline-secondary'} onClick={() => setOrdering('CreatedAt')}>Date</button>
            <button type="button" className={ordering === 'Price' ? 'btn btn-primary' : 'btn btn-outline-secondary'} onClick={() => setOrdering('Price')}>Price</button>
          </div>
          <div className="mt-2 d-flex gap-2">
            <button type="button" className={direction === 'Ascending' ? 'btn btn-secondary' : 'btn btn-outline-secondary'} onClick={() => setDirection('Ascending')}>↑</button>
            <button type="button" className={direction === 'Descending' ? 'btn btn-secondary' : 'btn btn-outline-secondary'} onClick={() => setDirection('Descending')}>↓</button>
          </div>
        </div>
      )}
    </div>
  );
}
