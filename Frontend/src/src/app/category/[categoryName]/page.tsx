'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import { ListingGrid } from '@/sharedComponents/ListingGrid';
import { FilterPanel } from '@/sharedComponents/FilterPanel';
import { Listing } from '@/types/api/listings';
import { ListingFilter, Ordering, OrderingDirection } from '@/types/api/categories';

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


export default function CategoryPage({ params }: { params: { categoryName: string } }) {
  const { categoryName } = params;
  const [filter, setFilter] = useState<ListingFilter>();
  const [page, setPage] = useState(1);
  const [pageData, setPageData] = useState<{ items: any[]; totalPages: number }>({ items: [], totalPages: 1 });

  useEffect(() => { // todo here a method for on filterSubmitted


    const filter: ListingFilter = {
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
    };
    const fetchListings = async () => {
      const resp = await axios.post(
        `https://localhost:7192/api/Categories/${categoryName}?pageNumber=${page}&pageSize=12`,
        filter
      );
      setPageData(resp.data);
    };
    fetchListings();
  }, [categoryName, filter, page]);

  return (
    <div className="container mt-5">
      <div className="row">
        <div className="col-md-3">
          <FilterPanel
            priceEnabled
            userEnabled
            cityEnabled
            radiusEnabled
            searchEnabled
            orderingEnabled
            stateOfItemEnabled
            listingPropertiesEnabled
            onFilterSubmited={setFilter}
          />
        </div>
        <div className="col-md-9">
          <h1>Listings for {categoryName}</h1>
          <ListingGrid
            listings={pageData.items}
            page={page}
            totalPages={pageData.totalPages}
            onPageChange={setPage}
          />
        </div>
      </div>
    </div>
  );
}