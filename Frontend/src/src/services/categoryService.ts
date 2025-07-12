import api from './apiClient';
import {
    Category,
    CategoryDetail,
    CategoryHierarchy,
    CreateCategoryRequest,
    UpdateCategoryRequest,
    AddListingPropertiesToCategoryRequest,
    RemoveListingPropertyFromCategoryRequest,
} from '@/types/api/categories';
import { ListingFilter } from '@/types/api/categories';
import { Listing } from '@/types/api/listings';
import { Page } from '@/types/api/page';

export const fetchCategories = async (): Promise<Category[]> => {
    const { data } = await api.get<Category[]>('/api/Categories');
    return data;
};

export const fetchCategoryHierarchy = async (): Promise<
    CategoryHierarchy[]
> => {
    const { data } = await api.get<CategoryHierarchy[]>(
        '/api/Categories/Hierarchy'
    );
    return data;
};

export const fetchCategoryById = async (
    id: string
): Promise<CategoryDetail> => {
    const { data } = await api.get<CategoryDetail>(`/api/Categories/${id}`);
    return data;
};

export const fetchCategoryByName = async (
    name: string
): Promise<CategoryDetail> => {
    const { data } = await api.get<CategoryDetail>(
        `/api/Categories/GetByName/${encodeURIComponent(name)}`
    );
    return data;
};

export const fetchListingsByCategoryName = async (
    name: string,
    filter: ListingFilter,
    pageNumber = 1,
    pageSize = 12
): Promise<Page<Listing>> => {
    const { data } = await api.post<Page<Listing>>(
        `/api/Categories/${encodeURIComponent(name)}`,
        filter,
        { params: { pageNumber, pageSize } }
    );
    return data;
};

export const createCategory = async (
    payload: CreateCategoryRequest
): Promise<Category> => {
    const { data } = await api.post<Category>('/api/Categories', payload);
    return data;
};

export const updateCategory = async (
    id: string,
    payload: UpdateCategoryRequest
): Promise<Category> => {
    const { data } = await api.put<Category>(`/api/Categories/${id}`, payload);
    return data;
};

export const addListingPropertiesToCategory = async (
    id: string,
    payload: AddListingPropertiesToCategoryRequest
): Promise<Category> => {
    const { data } = await api.put<Category>(
        `/api/Categories/AddListingProperties/${id}`,
        payload
    );
    return data;
};

export const removeListingPropertyFromCategory = async (
    id: string,
    payload: RemoveListingPropertyFromCategoryRequest
): Promise<Category> => {
    const { data } = await api.put<Category>(
        `/api/Categories/RemoveListingProperty/${id}`,
        payload
    );
    return data;
};

export const deleteCategory = async (id: string): Promise<Category> => {
    const { data } = await api.delete<Category>(`/api/Categories/${id}`);
    return data;
};
