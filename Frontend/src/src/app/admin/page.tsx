'use client';

import CategorySection from './components/CategorySection';
import ListingPropertySection from './components/ListingPropertySection';

export default function AdminPage() {
    return (
        <div className="container mt-5">
            <h1 className="text-center text-md-left mb-4">Admin Page</h1>

            <div className="row">
                <div className="col-12 mb-4">
                    <CategorySection />
                </div>
                <div className="col-12">
                    <ListingPropertySection />
                </div>
            </div>
        </div>
    );
}
