'use client';
import { useRouter } from 'next/navigation';
import CategoryForm from './CategoryForm';
import { useState } from 'react';
import { CategoryHierarchy } from '@/types/api/categories';

interface CategoryItemProps {
    category: CategoryHierarchy;
    onAddSubcategory: (name: string, parentId: string) => void;
    onDeleteCategory: (categoryId: string) => void;
}

export default function CategoryItem({
    category,
    onAddSubcategory,
    onDeleteCategory,
}: CategoryItemProps) {
    const router = useRouter();
    const [showAddForm, setShowAddForm] = useState(false);

    return (
        <li className="mb-3">
            <div
                className="
              d-flex 
              flex-column flex-md-row 
              justify-content-between 
              align-items-start align-items-md-center 
              gap-2
            "
            >
                <span className="fw-semibold">{category.name}</span>

                <div className="d-flex flex-wrap gap-2">
                    <button
                        className="btn btn-sm btn-secondary"
                        onClick={() => setShowAddForm((v) => !v)}
                    >
                        {showAddForm ? 'Cancel' : 'Add Subcategory'}
                    </button>
                    <button
                        className="btn btn-sm btn-danger"
                        onClick={() => onDeleteCategory(category.id)}
                    >
                        Delete
                    </button>
                    <button
                        className="btn btn-sm btn-primary"
                        onClick={() =>
                            router.push(`/admin/category/${category.id}`)
                        }
                    >
                        Edit
                    </button>
                </div>
            </div>

            {showAddForm && (
                <div className="mt-2">
                    <CategoryForm
                        onSubmit={(name) => {
                            onAddSubcategory(name, category.id);
                            setShowAddForm(false);
                        }}
                        placeholder="Subcategory name"
                    />
                </div>
            )}

            {category.childrenCategories.length > 0 && (
                <ul className="ps-4 ms-2 border-start border-2 border-secondary mt-2">
                    {category.childrenCategories.map((child) => (
                        <CategoryItem
                            key={child.id}
                            category={child}
                            onAddSubcategory={onAddSubcategory}
                            onDeleteCategory={onDeleteCategory}
                        />
                    ))}
                </ul>
            )}
        </li>
    );
}
