'use client';

import { useState } from 'react';
import { ChevronRight } from 'lucide-react';
import { CategoryHierarchy } from '@/types/api/categories';
import { useRouter } from 'next/navigation';

interface CategoryMenuItemProps {
    category: CategoryHierarchy;
    closeNavbar: () => void;
}

export default function CategoryMenuItem({
    category,
    closeNavbar: closeNav,
}: CategoryMenuItemProps) {
    const [open, setOpen] = useState(false);
    const hasChildren = category.childrenCategories.length > 0;
    const router = useRouter();

    const toggleSubmenu = (e: React.MouseEvent) => {
        e.preventDefault();
        e.stopPropagation();
        setOpen((o) => !o);
    };
    const handleCategoryClick = (e: React.MouseEvent) => {
        e.preventDefault();
        e.stopPropagation();
        setOpen((o) => !o);
        closeNav();
        router.push(`/category/${encodeURIComponent(category.name)}`);
    };
    const closeNavigation = () => {
        setOpen((o) => !o);
        closeNav();
    };
    return (
        <li className={`dropdown-submenu`}>
            <div className="d-flex align-items-center justify-content-between px-2 py-1">
                <a
                    href="#"
                    className="dropdown-item"
                    onClick={handleCategoryClick}
                >
                    {category.name}
                </a>

                {hasChildren && (
                    <button
                        type="button"
                        className="submenu-toggler btn p-0"
                        aria-expanded={open}
                        onClick={toggleSubmenu}
                    >
                        <ChevronRight
                            size={16}
                            style={{
                                transform: open
                                    ? 'rotate(90deg)'
                                    : 'rotate(0deg)',
                                transition: 'transform 150ms',
                            }}
                        />
                    </button>
                )}
            </div>

            {hasChildren && (
                <ul
                    className="dropdown-menu"
                    style={{ display: open ? 'block' : 'none' }}
                >
                    {category.childrenCategories.map((child) => (
                        <CategoryMenuItem
                            key={child.id}
                            category={child}
                            closeNavbar={closeNavigation}
                        />
                    ))}
                </ul>
            )}
        </li>
    );
}
