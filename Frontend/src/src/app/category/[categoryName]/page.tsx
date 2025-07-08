'use client';

import { useEffect, useState } from 'react';
import axios from 'axios';
import { ListingGrid } from '@/sharedComponents/ListingGrid';
import { FilterPanel } from '@/sharedComponents/FilterPanel';

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
  const [filterDto, setFilterDto] = useState<any>({});
  const [page, setPage] = useState(1);
  const [pageData, setPageData] = useState<{ items: any[]; totalPages: number }>({ items: [], totalPages: 1 });

  useEffect(() => {
    const fetchListings = async () => {
      const resp = await axios.post(
        `https://localhost:7192/api/Categories/${categoryName}?pageNumber=${page}&pageSize=12`,
        filterDto
      );
      setPageData(resp.data);
    };
    fetchListings();
  }, [categoryName, filterDto, page]);

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
            onFilterChange={setFilterDto}
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