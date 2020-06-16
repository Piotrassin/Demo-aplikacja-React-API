import React, {useState} from "react";

export default function AddApplicationForm( { setApplication, addApp } ) {

    const triggerState = () => {
        setApplication(false);
    }

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const setUser = () => {

        addApp({
                firstName: firstName,
                lastName: lastName,
                email: email,
                login: username,
                password: password
            });

            triggerState();
    }

    const handleFirstName = (e) => {
        setFirstName(e.target.value);
    }


    const handleLastName = (e) => {
        setLastName(e.target.value);
    }

    const handleEmail = (e) => {
        setEmail(e.target.value);
    }


    const handleUsername = (e) => {
        setUsername(e.target.value);
    }


    const handlePassword = (e) => {
        setPassword(e.target.value);
    }

    return (
        <div style={{ background: "#f0f0f0", padding: "2%", marginTop: "1%", width: "50%", align: "center"}}>
            <h4>Formularz zapisu na lot kosmiczny!</h4>
            <form onSubmit={ setUser }>
                <div style={{ display: "flex", flexDirection: "column"}}>
                    <div>
                        <input type="text" placeholder="Imię" value={firstName} onChange={handleFirstName}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Nazwisko" value={lastName} onChange={handleLastName}/>
                    </div>
                    <div>
                        <input type="email" placeholder="Email" value={email} onChange={handleEmail}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Username" value={username} onChange={handleUsername}/>
                    </div>
                    <div>
                        <input type="password" placeholder="Password" value={password} onChange={handlePassword}/>
                    </div>
                </div>
                <div align="center">
                    <button type="button" style={{ marginRight: "1%" }} onClick={ setUser } className="btn">Zapisz</button>
                    <button type="button" className="btn red darken-2" onClick={ triggerState } >Anuluj</button>
                </div>
            </form>
        </div>
    );
}