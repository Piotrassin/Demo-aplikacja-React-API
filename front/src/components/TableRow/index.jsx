import React from "react";
import Axios from "axios";

export default function TableRow({ person }) {

    const accept = () => {
        Axios.get('http://localhost:59062/api/person/accept/'+person.id).then(res => console.log(res));
    }

    return (
        <tr style={{ color: "black" }} >
            <td>{person.id}</td>
            <td>{person.firstName}</td>
            <td>{person.lastName}</td>
            <td>{person.email}</td>
            <button type="button" className="btn green darken-4" style={{ marginTop: "3%" }} onClick={accept} >Zaakceptuj</button>
        </tr>
    );
}