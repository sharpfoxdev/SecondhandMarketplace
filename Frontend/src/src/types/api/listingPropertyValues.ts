import { ListingProperty } from './listingProperties';

export interface CreateListingPropertyValueRequest {
    name: string;
    listingPropertyId: string;
}

export interface CreatePropertyValueInsidePropertyRequest {
    name: string;
}

export interface ListingPropertyValue {
    id: string;
    name: string;
}

export interface ListingPropertyValueDetail {
    id: string;
    name: string;
    listingProperty: ListingProperty;
}

export interface UpdateListingPropertyValueRequest {
    name: string;
}
