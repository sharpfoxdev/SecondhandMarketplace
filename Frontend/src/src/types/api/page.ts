export interface Page<T> {
    items: T[];
    totalPages: number;
    pageNumber: number;
    pageSize: number;
}
