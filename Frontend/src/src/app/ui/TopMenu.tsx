'use client';

import Link from 'next/link';
import { useEffect, useState } from 'react';
import axios from 'axios';

interface Category {
    id: string;
    name: string;
    parentCategory?: Category | null;
    childrenCategories: Category[];
}

export default function TopMenu() {
    const [categories, setCategories] = useState<Category[]>([]);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const response = await axios.get<Category[]>('https://localhost:7192/api/Categories');
                setCategories(response.data);
            } catch (error) {
                console.error('Failed to fetch categories', error);
            }
        };

        fetchCategories();
    }, []);

    // Bootstrap JS is needed for rendering dropdown menu, but it wont let me import it in layout.tsx, 
    // so I import it here
    useEffect(() => {
        if (typeof window !== 'undefined') {
            import('bootstrap/dist/js/bootstrap.bundle.min.js');
        }
    }, []);

    // Filter top-level categories (those without a parent)
    const topLevelCategories = categories.filter(category => !category.parentCategory);
    const renderCategoryMenu = (category: Category) => {
        const hasSubcategories = category.childrenCategories.length > 0;

        return (
            <li key={category.id} className={`dropdown-submenu ${hasSubcategories ? 'dropend' : ''}`}>
                <Link href={`/category/${category.name}`} className={`dropdown-item ${hasSubcategories ? 'dropdown-toggle' : ''}`}>
                    {category.name}
                </Link>
                {hasSubcategories && (
                    <ul className="dropdown-menu">
                        {category.childrenCategories.map((subCategory) => renderCategoryMenu(subCategory))}
                    </ul>
                )}
            </li>
        );
    };

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link href="/" className="navbar-brand" style={{ fontSize: '24px', fontWeight: 'bold' }}>
                    Marketplace
                </Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        {/* Categories Dropdown */}
                        <li className="nav-item dropdown">
                            <a
                                className="nav-link dropdown-toggle"
                                href="#"
                                id="categoriesDropdown"
                                role="button"
                                data-bs-toggle="dropdown"
                                aria-expanded="false"
                            >
                                Categories
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="categoriesDropdown">
                                {topLevelCategories.map((category) => renderCategoryMenu(category))}
                            </ul>
                        </li>
                    </ul>
                    {/* Right-aligned buttons */}
                    <ul className="navbar-nav ms-auto">
                        <li className="nav-item">
                            <Link href="/listing/new" className="nav-link">
                                New listing
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link href="/auth/login" className="nav-link">
                                Login
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link href="/auth/register" className="nav-link">
                                Register
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link href="/admin" className="nav-link">
                                Admin
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link href="/user" className="nav-link">
                                My Profile
                            </Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
}
