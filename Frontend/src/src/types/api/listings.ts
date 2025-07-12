import { Image } from './images';
import { City } from './cities';
import { Category } from './categories';
import { ListingPropertyValueDetail } from './listingPropertyValues';
import { StateOfItem } from './stateOfItem';

export interface CreateListingRequest {
    price: number;
    stateOfItemId: string;
    title: string;
    description: string;
    reasonOfSale: string;
    categoryId: string;
    cityId: string;
    propertyValueSelection: ListingPropertyValueSelection[];
}

export interface Listing {
    id: string;
    price: number;
    sellerId: string;
    title: string;
    description: string;
    reasonOfSale: string;
    isSold: boolean;
    createdAt: string;
    images: Image[];
}

export interface ListingDetail {
    id: string;
    price: number;
    sellerId: string;
    stateOfItem: StateOfItem;
    title: string;
    description: string;
    reasonOfSale: string;
    isSold: boolean;
    category: Category;
    city: City;
    selectedListingPropertyValues: ListingPropertyValueDetail[];
    images: Image[];
}

export interface ListingPropertyValueSelection {
    listingPropertyId: string;
    selectedListingPropertyValueId: string;
}

export interface UpdateListingRequest {
    price: number;
    stateOfItemId: string;
    title: string;
    description: string;
    reasonOfSale: string;
    isSold: boolean;
}
