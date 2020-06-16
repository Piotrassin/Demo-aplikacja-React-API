import React, {useState} from "react";
import { useHistory } from "react-router-dom";

export default function LoginWorkerForm( { setLogin, loginWorker } ) {

    const history = useHistory();
    const triggerState = () => {
        setLogin(false);
    }

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const [usernameError, setUsernameError] = useState(false);
    const [passwordError, setPasswordError] = useState(false);

    const setUser = () => {
        if(username.length > 3 && password.length > 3 && !usernameError && !passwordError) {
            history.push("/worker");
        }else{
            if(username.length < 3){
                setUsernameError(true)
            }
            if(password.length < 3){
                setPasswordError(true)
            }
        }
    }

    const handleUsername = (e) => {
        setUsername(e.target.value);
        if(e.target.value.length < 3){
            setUsernameError(true);
        }else{
            setUsernameError(false);
        }
    }


    const handlePassword = (e) => {
        setPassword(e.target.value);
        if(e.target.value.length < 3){
            setPasswordError(true);
        }else{
            setPasswordError(false);
        }
    }

    return (
        <div style={{ background: "#f0f0f0", padding: "2%", marginTop: "1%", width: "60%", }}>
            <h4 align="left">Zaloguj jako pracownik</h4>
            <form onSubmit={ setUser }>
                <div style={{ display: "flex"}}>
                    <div style={{ width: "100%"}}>
                        <input type="text" placeholder="Username" value={username} onChange={handleUsername}/>
                        {usernameError && <span style={{ color: "red" }}>Błędny format loginu</span>}
                    </div>
                    <div style={{ width: "100%"}}>
                        <input type="email" placeholder="Password" value={password} onChange={handlePassword}/>
                        {passwordError && <span style={{ color: "red" }}>Błędny format hasła!</span>}
                    </div>
                </div>
                <div align="right">
                    <button type="button" style={{ marginRight: "1%" }} onClick={ setUser } className="btn">Zaloguj</button>
                    <button type="button" className="btn red darken-2" onClick={ triggerState } >Anuluj</button>
                </div>
            </form>
        </div>
    );
}