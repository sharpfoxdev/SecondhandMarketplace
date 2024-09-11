'use client';

import CategorySection from '../ui/admin/CategorySection';
import ListingPropertySection from '../ui/admin/ListingPropertySection';

export default function AdminPage() {
  return (
    <div className="container mt-5">
      <h1>Admin Page</h1>
      <CategorySection />
      <ListingPropertySection />
    </div>
  );
}
