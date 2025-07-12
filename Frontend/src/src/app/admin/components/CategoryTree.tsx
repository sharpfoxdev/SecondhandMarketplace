'use client';

import CategoryItem from './CategoryItem';
import { CategoryHierarchy } from '@/types/api/categories';

interface CategoryTreeProps {
    categories: CategoryHierarchy[];
    onAddSubcategory: (parentId: string, name: string) => void;
    onDeleteCategory: (categoryId: string) => void;
}

export default function CategoryTree({
    categories,
    onAddSubcategory,
    onDeleteCategory,
}: CategoryTreeProps) {
    return (
        <ul className="list-unstyled mt-4">
            {categories
                .filter((category) => !category.parentCategory) // only top level categories
                .map((category) => (
                    <CategoryItem
                        key={category.id}
                        category={category}
                        onAddSubcategory={onAddSubcategory}
                        onDeleteCategory={onDeleteCategory}
                    />
                ))}
        </ul>
    );
}
