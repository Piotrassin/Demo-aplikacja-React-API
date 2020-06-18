import React, {useState} from "react";
import Axios from "axios";

export default function AddOfferForm( { setForm, userid } ) {

    const triggerState = () => {
        setForm(false);
    }

    const [where, setWhere] = useState("");
    const [money, setMoney] = useState("");
    const [direction, setDirection] = useState("");

    const randomPrice = () => {
        return money-(money*(Math.random() * (0.35 - 0.01) + 0.01))+(money*(Math.random() * (0.15 - 0.02) + 0.02));
    }

    const getOffer = () => {
        Axios.post('http://localhost:59062/api/Personalizedoffers',{UserPersonId: parseInt(userid), Price: randomPrice()}).then(res => { triggerState() });
    }

    const handleWhere = (e) => {
        setWhere(e.target.value);
    }


    const handleMoney = (e) => {
        setMoney(e.target.value);
    }

    const handleDirection = (e) => {
        setDirection(e.target.value);
    }

    return (
        <div style={{ background: "#f0f0f0", padding: "2%", marginTop: "1%", align: "center"}}>
            <h4 style={{color: "black"}}>Formularz ofertowy</h4>
            <form onSubmit={ getOffer }>
                <div style={{ display: "flex", flexDirection: "column"}}>
                    <div>
                        <input type="text" placeholder="Gdzie chcesz polecieć?" value={where} onChange={handleWhere}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Jaki masz budżet?" value={money} onChange={handleMoney}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Napisz coś o sobie..." value={direction} onChange={handleDirection}/>
                    </div>

                </div>
                <div align="center">
                    <button type="button" style={{ marginRight: "1%" }} onClick={ getOffer } className="btn">Wyślij</button>
                    <button type="button" className="btn red darken-2" onClick={ triggerState } >Anuluj</button>
                </div>
            </form>
        </div>
    );
}