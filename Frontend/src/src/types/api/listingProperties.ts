import { ListingPropertyValue } from './listingPropertyValues';

export interface CreateListingPropertyRequest {
    name: string;
}

export interface ListingProperty {
    id: string;
    name: string;
}

export interface ListingPropertyDetail {
    id: string;
    name: string;
    listingPropertyValues: ListingPropertyValue[];
}

export interface UpdateListingPropertyRequest {
    name: string;
}
