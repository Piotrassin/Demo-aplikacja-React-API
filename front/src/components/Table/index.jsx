import React, { useEffect, useState } from "react";
import TableHeader from "../TableHeader";
import TableRow from "../TableRow";
import AddForm from "../AddForm";
import AddDriverButton from "../AddDriverButton";
import Axios from "axios";


export default function Table() {

    const [users, setUsers] = useState([]);
    const [tmpUsers, setTmpUsers] = useState([]);
    const [empty, setEmpty] = useState(true);
    const [add, setAdd] = useState(false);

    useEffect(() => {
        Axios.get('https://my-json-server.typicode.com/SimoneDiPlocki/demo/users').then(res => {setUsers(res.data)});
    });

    const addUser = (user) => {
        Axios.post('https://my-json-server.typicode.com/SimoneDiPlocki/demo/users', user)
                .then(res => {setTmpUsers([...tmpUsers, res.data]); alert("Added temporarily to database")});
    };

    const triggerState = () => {
        setEmpty(false);
        setAdd(true);
    }

    return (
        <div>
            <div>
                {empty && <AddDriverButton addDriver={ triggerState }/>}
                {add && <AddForm setAdd={ setAdd } setEmpty={ setEmpty } addUser={ addUser } users={ users } />}
            </div>
            <table>
                <TableHeader
                    columnsNames={["User ID", "Name", "Username", "Email", ""]}
                />
                <tbody>
                {[...users, ...tmpUsers].map((u) => (
                    <TableRow
                        key={u.id}
                        user={u}
                    />
                ))}
                </tbody>
            </table>
        </div>
    );
}