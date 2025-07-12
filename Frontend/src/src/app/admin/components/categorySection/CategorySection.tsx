'use client';

import { useEffect, useState } from 'react';
import CategoryForm from './CategoryForm';
import CategoryTree from './CategoryTree';
import {
    CategoryHierarchy,
    CreateCategoryRequest,
} from '@/types/api/categories';
import {
    fetchCategoryHierarchy,
    createCategory,
    deleteCategory,
} from '@/services/categoryService';

export default function CategorySection() {
    const [categories, setCategories] = useState<CategoryHierarchy[]>([]);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const res = await fetchCategoryHierarchy();
                setCategories(res);
            } catch (error) {
                console.error('Failed to fetch categories', error);
            }
        };

        fetchCategories();
    }, []);

    const handleAddCategory = async (
        name: string,
        parentId: string | null = null
    ) => {
        try {
            const request: CreateCategoryRequest = {
                name: name,
                parentCategoryId: parentId,
            };
            await createCategory(request);
            const res = await fetchCategoryHierarchy();
            setCategories(res);
        } catch (error) {
            console.error('Failed to add category', error);
        }
    };

    const handleDeleteCategory = async (categoryId: string) => {
        try {
            await deleteCategory(categoryId);
            const res = await fetchCategoryHierarchy();
            setCategories(res);
        } catch (error) {
            console.error('Failed to delete category', error);
        }
    };

    return (
        <div className="container mt-5 mb-5">
            <h1 className="text-center text-md-left">
                Admin Page – Manage Categories
            </h1>

            <div className="row mt-4 gx-4 gy-4">
                <div className="col-12 col-md-4">
                    <div className="card h-100">
                        <div className="card-body d-flex flex-column">
                            <h2 className="card-title">
                                Create a Top-Level Category
                            </h2>
                            <CategoryForm
                                onSubmit={(name: string) =>
                                    handleAddCategory(name, null)
                                }
                            />
                        </div>
                    </div>
                </div>

                <div className="col-12 col-md-8">
                    <div className="card h-100">
                        <div className="card-body">
                            <h2 className="card-title d-md-none">Categories</h2>
                            <CategoryTree
                                categories={categories}
                                onAddSubcategory={handleAddCategory}
                                onDeleteCategory={handleDeleteCategory}
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}
