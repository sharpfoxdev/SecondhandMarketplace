import { ListingPropertyDetail } from './listingProperties';

export interface AddListingPropertiesToCategoryRequest {
    listingPropertyIds: string[]; // GUIDs as strings
}

export interface Category {
    id: string;
    name: string;
}

export interface CategoryDetail {
    id: string;
    name: string;
    listingProperties: ListingPropertyDetail[];
}

export interface CategoryHierarchy {
    id: string;
    name: string;
    parentCategory?: Category | null;
    childrenCategories: CategoryHierarchy[];
}

export interface CreateCategoryRequest {
    name: string;
    parentCategoryId?: string | null;
}

export enum Ordering {
    Price = 0,
    CreatedAt = 1,
}

export enum OrderingDirection {
    Ascending = 0,
    Descending = 1,
}

export interface ListingFilter {
    priceMin?: number | null;
    priceMax?: number | null;
    stateOfItemIds: string[];
    selectedListingPropertyValueIds: string[];
    sellerId?: string | null;
    cityId?: string | null;
    radius?: number | null;
    search?: string | null;
    ordering: Ordering;
    orderingDirection: OrderingDirection;
}

export interface RemoveListingPropertyFromCategoryRequest {
    id: string;
}

export interface UpdateCategoryRequest {
    name: string;
}
