'use client';

import React, { useState, useEffect, useRef } from 'react';
import { City } from '@/types/api/cities';
import { fetchCities } from '@/services/cityService';

interface CitySelectorProps {
    selectedCityId?: string;
    onCitySelect: (city: City) => void;
    placeholder?: string;
}

export default function CitySelector({
    selectedCityId,
    onCitySelect,
    placeholder = ''
}: CitySelectorProps) {
    const [inputValue, setInputValue] = useState('');
    const [suggestions, setSuggestions] = useState<City[]>([]);
    const [isOpen, setIsOpen] = useState(false);
    const [loading, setLoading] = useState(false);
    const debounceRef = useRef<NodeJS.Timeout | null>(null);
    const wrapperRef = useRef<HTMLDivElement>(null);

    // Close dropdown when clicking outside
    useEffect(() => {
        const onClickOutside = (e: MouseEvent) => {
            if (wrapperRef.current && !wrapperRef.current.contains(e.target as Node)) {
                setIsOpen(false);
            }
        };
        document.addEventListener('click', onClickOutside);
        return () => document.removeEventListener('click', onClickOutside);
    }, []);

    // Debounced fetch
    const fetchSuggestions = async (term: string) => {
        if (!term.trim()) {
            setSuggestions([]);
            return;
        }

        setLoading(true);
        try {
            const cities: City[] = await fetchCities(term);
            setSuggestions(cities);
            setIsOpen(true);
        } catch (err) {
            console.error('Error fetching cities:', err);
        } finally {
            setLoading(false);
        }
    };

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const val = e.target.value;
        setInputValue(val);
        if (debounceRef.current) clearTimeout(debounceRef.current);
        debounceRef.current = setTimeout(() => {
            fetchSuggestions(val);
        }, 300);
    };

    const handleSelect = (city: City) => {
        setInputValue(city.name);
        setIsOpen(false);
        onCitySelect(city);
    };


    return (
        <div className="position-relative" ref={wrapperRef}>
            <input
                type="text"
                className="form-control"
                placeholder={placeholder}
                value={inputValue}
                onChange={handleChange}
                onFocus={() => inputValue && fetchSuggestions(inputValue)}
            />

            {isOpen && suggestions.length > 0 && (
                <ul className="list-group position-absolute w-100" style={{ zIndex: 1000 }}>
                    {suggestions.map(city => (
                        <li
                            key={city.id}
                            className="list-group-item list-group-item-action"
                            onClick={() => handleSelect(city)}
                            style={{ cursor: 'pointer' }}
                        >
                            {city.name} ({city.zipCode}), {city.district}, {city.region}
                        </li>
                    ))}
                </ul>
            )}

            {loading && (
                <div className="position-absolute mt-1 text-muted">Loading...</div>
            )}
        </div>
    );
}
