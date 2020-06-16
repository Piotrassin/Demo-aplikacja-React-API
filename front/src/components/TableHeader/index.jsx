import React from "react";

export default function TableHeader({ columnsNames }) {
    return (
        <thead>
            <tr>
                {columnsNames.map((c) => (
                    <th key={c}>{c}</th>
                ))}
            </tr>
        </thead>
    );
}