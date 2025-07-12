'use client';

import { useEffect, useState } from 'react';
import CitySelector from './CitySelector';
import { City } from '@/types/api/cities';
import { StateOfItem } from '@/types/api/stateOfItem';
import {
    CategoryDetail,
    ListingFilter,
    Ordering,
    OrderingDirection,
} from '@/types/api/categories';
import PropertySection from './PropertySection';
import { fetchCategoryByName } from '@/services/categoryService';
import { fetchStatesOfItem } from '@/services/stateOfItemService';

interface FilterPanelProps {
    categoryName: string | null;
    priceEnabled?: boolean;
    stateOfItemEnabled?: boolean;
    listingPropertiesEnabled?: boolean;
    cityEnabled?: boolean;
    radiusEnabled?: boolean;
    searchEnabled?: boolean;
    orderingEnabled?: boolean;
    onFilterSubmit: (filter: ListingFilter) => void;
}

export function FilterPanel({
    categoryName,
    priceEnabled = true,
    stateOfItemEnabled = false,
    listingPropertiesEnabled = false,
    cityEnabled = false,
    radiusEnabled = false,
    searchEnabled = false,
    orderingEnabled = true,
    onFilterSubmit,
}: FilterPanelProps) {
    // current filter state
    const [priceMin, setPriceMin] = useState<number | null>(null);
    const [priceMax, setPriceMax] = useState<number | null>(null);
    const [selectedStates, setSelectedStates] = useState<string[]>([]);
    const [selectedPropertyValues, setSelectedPropertyValues] = useState<
        string[]
    >([]);
    const [city, setCity] = useState<City | null>(null);
    const [radius, setRadius] = useState<number | null>(null);
    const [search, setSearch] = useState<string | null>(null);
    const [ordering, setOrdering] = useState<Ordering>(Ordering.CreatedAt);
    const [orderingDirection, setOrderingDirection] =
        useState<OrderingDirection>(OrderingDirection.Descending);

    // filter options for state of item and properties of category
    const [statesOfItem, setStatesOfItem] = useState<StateOfItem[]>([]);
    const [categoryDetail, setCategoryDetail] = useState<CategoryDetail | null>(
        null
    );

    // styling of collapsible filters
    const [showStateOfItems, setShowStateOfItems] = useState(false);
    const [showProperties, setShowProperties] = useState(false);

    useEffect(() => {
        if (categoryName && listingPropertiesEnabled) {
            fetchCategoryByName(categoryName)
                .then((data) => setCategoryDetail(data))
                .catch(console.error);
        }
        if (stateOfItemEnabled) {
            fetchStatesOfItem()
                .then((data) => setStatesOfItem(data))
                .catch(console.error);
        }
    }, [categoryName, listingPropertiesEnabled, stateOfItemEnabled]);

    const apply = () => {
        onFilterSubmit({
            priceMin,
            priceMax,
            sellerId: null,
            cityId: city?.id ?? null,
            radius,
            search,
            ordering,
            orderingDirection: orderingDirection,
            stateOfItemIds: selectedStates,
            selectedListingPropertyValueIds: selectedPropertyValues,
        });
    };
    const toggleState = (id: string) =>
        setSelectedStates((s) =>
            s.includes(id) ? s.filter((x) => x !== id) : [...s, id]
        );
    const toggleProp = (id: string) =>
        setSelectedPropertyValues((p) =>
            p.includes(id) ? p.filter((x) => x !== id) : [...p, id]
        );
    return (
        <div className="filter-panel">
            {orderingEnabled && (
                <div className="mb-3">
                    <h5>Order By</h5>
                    <div className="d-flex gap-2 mb-1">
                        <button
                            className={
                                ordering === Ordering.CreatedAt
                                    ? 'btn btn-primary'
                                    : 'btn btn-outline-secondary'
                            }
                            onClick={() => setOrdering(Ordering.CreatedAt)}
                        >
                            Date
                        </button>
                        <button
                            className={
                                ordering === Ordering.Price
                                    ? 'btn btn-primary'
                                    : 'btn btn-outline-secondary'
                            }
                            onClick={() => setOrdering(Ordering.Price)}
                        >
                            Price
                        </button>
                    </div>
                    <div className="d-flex gap-2">
                        <button
                            className={
                                orderingDirection ===
                                OrderingDirection.Ascending
                                    ? 'btn btn-secondary'
                                    : 'btn btn-outline-secondary'
                            }
                            onClick={() =>
                                setOrderingDirection(
                                    OrderingDirection.Ascending
                                )
                            }
                        >
                            ↑
                        </button>
                        <button
                            className={
                                orderingDirection ===
                                OrderingDirection.Descending
                                    ? 'btn btn-secondary'
                                    : 'btn btn-outline-secondary'
                            }
                            onClick={() =>
                                setOrderingDirection(
                                    OrderingDirection.Descending
                                )
                            }
                        >
                            ↓
                        </button>
                    </div>
                </div>
            )}

            {priceEnabled && (
                <div className="mb-3">
                    <h5>Price</h5>
                    <input
                        type="number"
                        placeholder="Min"
                        className="form-control mb-1"
                        value={priceMin ?? ''}
                        onChange={(e) =>
                            setPriceMin(e.target.value ? +e.target.value : null)
                        }
                    />
                    <input
                        type="number"
                        placeholder="Max"
                        className="form-control"
                        value={priceMax ?? ''}
                        onChange={(e) =>
                            setPriceMax(e.target.value ? +e.target.value : null)
                        }
                    />
                </div>
            )}

            {searchEnabled && (
                <div className="mb-3">
                    <h5>Search</h5>
                    <input
                        type="text"
                        className="form-control"
                        value={search ?? ''}
                        onChange={(e) => setSearch(e.target.value || null)}
                    />
                </div>
            )}

            {cityEnabled && (
                <div className="mb-3">
                    <h5>City</h5>
                    <CitySelector
                        onCitySelect={setCity}
                        placeholder="Select city"
                    />
                </div>
            )}

            {radiusEnabled && (
                <div className="mb-3">
                    <h5>Radius (km)</h5>
                    <input
                        type="number"
                        className="form-control"
                        value={radius ?? ''}
                        onChange={(e) =>
                            setRadius(e.target.value ? +e.target.value : null)
                        }
                    />
                </div>
            )}

            {stateOfItemEnabled && (
                <div className="mb-3">
                    <h5
                        style={{ cursor: 'pointer' }}
                        onClick={() => setShowStateOfItems((s) => !s)}
                    >
                        State of Item{' '}
                        <span className="ms-2">
                            {showStateOfItems ? '▾' : '▸'}
                        </span>
                    </h5>
                    {showStateOfItems && (
                        <div className="ps-2">
                            {statesOfItem.map((s) => (
                                <div
                                    key={s.id}
                                    className="form-check"
                                >
                                    <input
                                        id={s.id}
                                        type="checkbox"
                                        className="form-check-input"
                                        checked={selectedStates.includes(s.id)}
                                        onChange={() => toggleState(s.id)}
                                    />
                                    <label
                                        htmlFor={s.id}
                                        className="form-check-label"
                                    >
                                        {s.name}
                                    </label>
                                </div>
                            ))}
                        </div>
                    )}
                </div>
            )}
            {listingPropertiesEnabled && categoryDetail && (
                <div className="mb-3">
                    <h5
                        style={{ cursor: 'pointer' }}
                        onClick={() => setShowProperties((p) => !p)}
                    >
                        Properties{' '}
                        <span className="ms-2">
                            {showProperties ? '▾' : '▸'}
                        </span>
                    </h5>
                    {showProperties && (
                        <div className="ps-2">
                            {categoryDetail.listingProperties.map((prop) => (
                                <PropertySection
                                    key={prop.id}
                                    name={prop.name}
                                    values={prop.listingPropertyValues.map(
                                        (v) => ({ id: v.id, name: v.name })
                                    )}
                                    selected={selectedPropertyValues}
                                    onToggle={toggleProp}
                                />
                            ))}
                        </div>
                    )}
                </div>
            )}
            <button
                className="btn btn-primary mt-3"
                onClick={apply}
            >
                Apply Filter
            </button>
        </div>
    );
}
