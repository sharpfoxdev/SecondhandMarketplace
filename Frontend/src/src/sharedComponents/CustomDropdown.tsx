import { useEffect, useRef, useState } from 'react';
import { ChevronDown } from 'lucide-react';

interface CustomDropdownProps {
    options: { id: string; name: string }[];
    selectedId: string;
    onSelect: (id: string) => void;
    placeholder?: string;
}

export default function CustomDropdown({
    options,
    selectedId,
    onSelect,
    placeholder,
}: CustomDropdownProps) {
    const [isOpen, setIsOpen] = useState(false);
    const wrapperRef = useRef<HTMLDivElement>(null);

    const selected = options.find((o) => o.id === selectedId);

    useEffect(() => {
        const handleClickOutside = (event: MouseEvent) => {
            if (
                wrapperRef.current &&
                !wrapperRef.current.contains(event.target as Node)
            ) {
                setIsOpen(false);
            }
        };
        document.addEventListener('mousedown', handleClickOutside);
        return () => {
            document.removeEventListener('mousedown', handleClickOutside);
        };
    }, []);

    return (
        <div
            className="position-relative"
            ref={wrapperRef}
        >
            <div
                className="form-control d-flex justify-content-between align-items-center"
                style={{ cursor: 'pointer' }}
                onClick={() => setIsOpen((prev) => !prev)}
            >
                <span className={selected ? '' : 'text-muted'}>
                    {selected?.name || placeholder || 'Select...'}
                </span>
                <ChevronDown size={18} />
            </div>

            {isOpen && (
                <ul
                    className="list-group position-absolute w-100 mt-1 shadow-sm"
                    style={{
                        zIndex: 1000,
                        borderRadius: '0.375rem',
                        overflow: 'hidden',
                    }}
                >
                    {options.map((option) => (
                        <li
                            key={option.id}
                            className="list-group-item list-group-item-action"
                            style={{ cursor: 'pointer' }}
                            onClick={() => {
                                onSelect(option.id);
                                setIsOpen(false);
                            }}
                        >
                            {option.name}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}
