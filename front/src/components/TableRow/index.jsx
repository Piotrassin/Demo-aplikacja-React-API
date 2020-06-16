import React from "react";
import { Link } from 'react-router-dom'

export default function TableRow({ user }) {


    return (
        <tr style={{ backgroundColor: "white" }} >
            <td>{user.id}</td>
            <td>{user.name}</td>
            <td>{user.username}</td>
            <td>{user.email}</td>
            <Link to={"/user/" + user.id}><button type="button" className="btn blue darken-4" style={{ marginTop: "3%" }} >Details</button></Link>
        </tr>
    );
}