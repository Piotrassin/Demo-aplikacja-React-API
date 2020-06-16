import React, { useEffect, useState } from "react";
import TableHeader from "../TableHeader";
import TableRow from "../TableRow";
import Axios from "axios";

export default function Table() {

    const [persons, setPersons] = useState([]);

    useEffect(() => {
        Axios.get('http://localhost:59062/api/person').then(res => {setPersons(res.data)});
    });

    const addUser = (user) => {
        Axios.post('', user);
    };

    return (
        <div>
            <table style={{ color: "white"}}>
                <TableHeader
                    columnsNames={["User ID", "Imię", "Nazwisko", "Email", ""]}
                />
                <tbody>
                {[...persons].map((p) => (
                    <TableRow
                        key={p.id}
                        person={p}
                    />
                ))}
                </tbody>
            </table>
        </div>
    );
}