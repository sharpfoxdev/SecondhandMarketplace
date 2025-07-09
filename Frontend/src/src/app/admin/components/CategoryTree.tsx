'use client';

import CategoryItem from './CategoryItem';

interface Category {
  id: string;
  name: string;
  parentCategory?: Category;
  childrenCategories: Category[];
}

interface CategoryTreeProps {
  categories: Category[];
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
        .filter((category) => !category.parentCategory) // Only top-level categories
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
