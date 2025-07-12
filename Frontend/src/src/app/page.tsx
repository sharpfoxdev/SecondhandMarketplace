'use client';

import { useEffect, useState } from 'react';
import { ListingGrid } from '../sharedComponents/ListingGrid';
import { Page } from '@/types/api/page';
import { Listing } from '@/types/api/listings';
import { fetchListings } from '@/services/listingService';
import { ListingFilter } from '@/types/api/categories';
import { Ordering, OrderingDirection } from '@/types/api/categories';
import { FilterPanel } from '@/sharedComponents/FilterPanel';

export default function Home() {
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
        orderingDirection: OrderingDirection.Descending,
    });
    const [pageNumber, setPageNumber] = useState(1);
    const [pageData, setPageData] = useState<Page<Listing>>({
        items: [],
        totalPages: 1,
        pageNumber: 1,
        pageSize: 30,
    });

    useEffect(() => {
        // reload on filter or page change
        const getListings = async () => {
            try {
                var res = await fetchListings(
                    filter,
                    pageNumber,
                    pageData.pageSize
                );
                setPageData(res);
            } catch (error) {
                console.error('Failed to fetch listings', error);
            }
        };
        getListings();
    }, [filter, pageNumber, pageData.pageSize]);

    return (
        <div className="container mt-5">
            <div className="row">
                <div className="col-md-3 mb-2">
                    <FilterPanel
                        categoryName={null}
                        priceEnabled
                        stateOfItemEnabled
                        listingPropertiesEnabled={false}
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
                    <h1>All listings</h1>
                    <ListingGrid
                        page={pageData}
                        onPageChange={setPageNumber}
                    />
                </div>
            </div>
        </div>
    );
}
