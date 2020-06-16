import React from "react";
import { Link } from 'react-router-dom'

export default function TableRow({ person }) {


    return (
        <tr style={{ color: "black" }} >
            <td>{person.id}</td>
            <td>{person.firstName}</td>
            <td>{person.lastName}</td>
            <td>{person.email}</td>
            <Link to={"/person/" + person.id}><button type="button" className="btn green darken-4" style={{ marginTop: "3%" }} >Zaakceptuj</button></Link>
        </tr>
    );
}