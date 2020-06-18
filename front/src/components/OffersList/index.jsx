import React, { useEffect, useState } from "react";
import TableHeader from "../TableHeader";
import Axios from "axios";
import TableRowOffer from "../TableRowOffer";

export default function OffersList({userid}) {

    const [offers, setOffers] = useState([]);

    useEffect(() => {
        Axios.get('http://localhost:59062/api/Personalizedoffers/user/'+userid).then(res => {setOffers(res.data)});
    });


    return (
        <div>
            <table style={{ color: "black"}}>
                <TableHeader
                    columnsNames={["Oferta ID", "Cena", ""]}
                />
                <tbody>
                {[...offers].map((o) => (
                    <TableRowOffer
                        key={o.id}
                        offer={o}
                    />
                ))}
                </tbody>
            </table>
        </div>
    );
}