'use client';
import Link from 'next/link';
import { useEffect, useState } from 'react';
import { fetchCategoryHierarchy } from '@/services/categoryService';
import { CategoryHierarchy } from '@/types/api/categories';
import CategoryMenuItem from './CategoryMenuItem';

export default function TopMenu() {
    const [categories, setCategories] = useState<CategoryHierarchy[]>([]);
    const [navOpen, setNavOpen] = useState(false);
    const [categoriesOpen, setCategoriesOpen] = useState(false);
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

    const closeNav = () => {
        setNavOpen(false);
        setCategoriesOpen(false);
    };
    const topLevelCategories = categories.filter((c) => !c.parentCategory);

    const renderCategoryMenu = (category: CategoryHierarchy) => {
        const hasSubcategories = category.childrenCategories.length > 0;

        return (
            <li
                key={category.id}
                className={`dropdown-submenu ${hasSubcategories ? 'dropend' : ''}`}
            >
                <Link
                    href={`/category/${category.name}`}
                    className={`dropdown-item ${hasSubcategories ? 'dropdown-toggle' : ''}`}
                >
                    {category.name}
                </Link>
                {hasSubcategories && (
                    <ul className="dropdown-menu">
                        {category.childrenCategories.map((subCategory) =>
                            renderCategoryMenu(subCategory)
                        )}
                    </ul>
                )}
            </li>
        );
    };

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link
                    href="/"
                    className="navbar-brand"
                    style={{ fontSize: '24px', fontWeight: 'bold' }}
                >
                    {process.env.NEXT_PUBLIC_MARKETPLACE_NAME}
                </Link>
                <button
                    className="navbar-toggler"
                    type="button"
                    onClick={() => setNavOpen((o) => !o)}
                >
                    <span className="navbar-toggler-icon" />
                </button>

                <div
                    className={`collapse navbar-collapse ${navOpen ? 'show' : ''}`}
                    id="navbarNav"
                >
                    <ul className="navbar-nav">
                        <li className="nav-item dropdown">
                            <button
                                className="nav-link dropdown-toggle btn btn-link"
                                type="button"
                                onClick={() => {
                                    setCategoriesOpen((c) => !c);
                                }}
                                aria-expanded={categoriesOpen}
                            >
                                Categories
                            </button>
                            <ul
                                className={`dropdown-menu ${categoriesOpen ? 'show' : ''}`}
                            >
                                {topLevelCategories.map((cat) => (
                                    <CategoryMenuItem
                                        key={cat.id}
                                        category={cat}
                                        closeNavbar={closeNav}
                                    />
                                ))}
                            </ul>
                        </li>
                    </ul>

                    <ul className="navbar-nav ms-auto">
                        {[
                            ['New listing', '/listing/new'],
                            ['Login', '/auth/login'],
                            ['Register', '/auth/register'],
                            ['Admin', '/admin'],
                            ['Inbox', '/inbox'],
                            ['My Profile', '/user'],
                        ].map(([label, href]) => (
                            <li
                                className="nav-item"
                                key={href}
                            >
                                <Link
                                    href={href}
                                    className="nav-link"
                                    onClick={closeNav}
                                >
                                    {label}
                                </Link>
                            </li>
                        ))}
                    </ul>
                </div>
            </div>
        </nav>
    );
}
