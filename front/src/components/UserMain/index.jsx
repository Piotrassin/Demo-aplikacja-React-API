import React, {useEffect, useState} from "react";
import Cookies from 'universal-cookie';
import OfferFormButton from "../OfferFormButton";
import AddOfferForm from "../AddOfferForm";
import MyOffersButton from "../MyOffersButton";
import Axios from "axios";
import OffersList from "../OffersList";


export default function UserMain() {

    const cookies = new Cookies();
    const [offerForm, setOfferForm] = useState(false);
    const [myOfferList, setMyOfferList] = useState(false);
    const [user, setUser] = useState({id: "", firstName: "", lastName: "", email: "", login: "", password: "", consultant: "", user: ""});

    useEffect(() => {
        Axios.get('http://localhost:59062/api/person/'+cookies.get('id')).then(res => {setUser(res.data)});
    });

    const triggerStateOffer = () => {
        setMyOfferList(false);
        setOfferForm(true);
    }

    const triggerStateOfferList = () => {
        setOfferForm(false);
        setMyOfferList(true);
    }

    return (
        <>
            <div className="container" style={{color: "white"}}>
                <br/>
                <h1>Panel klienta</h1>
                <h4>Zalogowano jako: <b> {user.firstName} {user.lastName}</b></h4>
                <div className="buttons">
                    <OfferFormButton loginClient={triggerStateOffer}/>
                    <MyOffersButton getList={triggerStateOfferList}/>
                </div>
                <br/>
                {offerForm && <AddOfferForm setForm={setOfferForm}/>}
                {myOfferList &&
                <div style={{color: 'black', padding: "10px", background: "white"}}>
                    <h4>Oferty</h4>
                    <OffersList userid={cookies.get('id')}/>
                </div>
                }
            </div>
        </>
    );
}