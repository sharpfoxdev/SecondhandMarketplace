'use client';

import { useEffect, useState } from 'react';
import { FilterPanel } from '@/sharedComponents/FilterPanel';
import { ListingGrid } from '@/sharedComponents/ListingGrid';
import { Listing } from '@/types/api/listings';
import { ListingFilter } from '@/types/api/categories';
import { Ordering, OrderingDirection } from '@/types/api/categories';
import { Page } from '@/types/api/page';
import { fetchListingsByCategoryName } from '@/services/categoryService';

export default function CategoryPage({ params }: { params: { categoryName: string } }) {
    const { categoryName } = params;
    const [filter, setFilter] = useState<ListingFilter>({
        priceMin: null,
        priceMax: null,
        stateOfItemIds: [],
        selectedListingPropertyValueIds: [],
        sellerId: null,
        cityId: null,
        radius: null,
        search: null,
        ordering: Ordering.CreatedAt,
        orderingDirection: OrderingDirection.Descending
    });
    const [pageNumber, setPageNumber] = useState(1);
    const [pageData, setPageData] = useState<Page<Listing>>({
        items: [],
        totalPages: 1,
        pageNumber: 1,
        pageSize: 12
    });

    useEffect(() => {
        // reload on category, filter or page change
        const fetchListings = async () => {
            try {
                const res = await fetchListingsByCategoryName(categoryName, filter, pageNumber, pageData.pageSize)
                setPageData(res);
            } catch (err) {
                console.error('Failed to load listings', err);
            }
        };
        fetchListings();
    }, [categoryName, filter, pageNumber]);

    return (
        <div className="container mt-5">
            <div className="row">
                <div className="col-md-3">
                    <FilterPanel
                        categoryName={categoryName}
                        priceEnabled
                        stateOfItemEnabled
                        listingPropertiesEnabled
                        cityEnabled
                        radiusEnabled
                        searchEnabled
                        orderingEnabled
                        onFilterSubmit={(f) => {
                            setPageNumber(1); //reset to the first page
                            setFilter(f);
                        }}
                    />
                </div>
                <div className="col-md-9">
                    <h1>Listings for {decodeURIComponent(categoryName)}</h1>
                    <ListingGrid
                        page={pageData}
                        onPageChange={setPageNumber}
                    />
                </div>
            </div>
        </div>
    );
}