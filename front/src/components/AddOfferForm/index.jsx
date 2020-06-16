import React, {useState} from "react";

export default function AddOfferForm( { setForm, addApp } ) {

    const triggerState = () => {
        setForm(false);
    }

    const [where, setWhere] = useState("");
    const [money, setMoney] = useState("");
    const [direction, setDirection] = useState("");

    const setUser = () => {

        addApp({
                where: where,
                money: money,
                direction: direction,
            });

            triggerState();
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
            <form onSubmit={ setUser }>
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
                    <button type="button" style={{ marginRight: "1%" }} onClick={ setUser } className="btn">Wyślij</button>
                    <button type="button" className="btn red darken-2" onClick={ triggerState } >Anuluj</button>
                </div>
            </form>
        </div>
    );
}