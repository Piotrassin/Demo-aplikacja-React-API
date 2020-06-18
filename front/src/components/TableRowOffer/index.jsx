import React from "react";
import { Link } from 'react-router-dom'

export default function TableRowOffer({ offer }) {


    return (
        <tr style={{ color: "black" }} >
            <td>{offer.id}</td>
            <td>{offer.price}</td>
            <button type="button" className="btn green darken-4" style={{ marginTop: "2%" }} >Zaakceptuj</button>
        </tr>
    );
}