import React, {useState} from "react";
import OfferFormButton from "../OfferFormButton";
import AddOfferForm from "../AddOfferForm";
import MyOffersButton from "../MyOffersButton";

export default function UserMain() {

    const [offerForm, setOfferForm] = useState(false);

    const triggerStateOffer = () => {
        setOfferForm(true);
    }

    return (
        <>
            <div className="container" style={{color: "white"}}>
                <br/>
                <h1>Panel klienta</h1>
                <div className="buttons">
                    <OfferFormButton loginClient={triggerStateOffer}/>
                    <MyOffersButton />
                </div>
                <br/>
                {offerForm && <AddOfferForm setForm={setOfferForm}/>}
            </div>
        </>
    );
}