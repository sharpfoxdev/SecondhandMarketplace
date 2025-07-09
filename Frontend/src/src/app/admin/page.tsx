'use client';

import CategorySection from './components/CategorySection';
import ListingPropertySection from './components/ListingPropertySection';

export default function AdminPage() {
    return (
        <div className="container mt-5">
            <h1>Admin Page</h1>
            <CategorySection />
            <ListingPropertySection />
        </div>
    );
}
