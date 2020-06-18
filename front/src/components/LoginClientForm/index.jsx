import React, {useState} from "react";
import { useHistory } from "react-router-dom";
import Axios from "axios";
import Cookies from 'universal-cookie';

export default function LoginWorkerForm( { setLoginClient,  } ) {

    const cookies = new Cookies();
    const history = useHistory();
    const triggerState = () => {
        setLoginClient(false);
    }

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const [usernameError, setUsernameError] = useState(false);
    const [passwordError, setPasswordError] = useState(false);

    const setUser = () => {
                Axios.get('http://localhost:59062/api/person/credentials/'+username+'/'+password).then(res => {
                    cookies.set('id', res.data, { path: '/' });
                    history.push("/user")
                }
            ).catch(err => {setPasswordError(true)})

        }

    const handleUsername = (e) => {
        setUsername(e.target.value);
    }


    const handlePassword = (e) => {
        setPassword(e.target.value);
    }

    return (
        <div style={{ background: "#f0f0f0", padding: "2%", marginTop: "1%", width: "60%", }}>
            <h4 align="left">Zaloguj jako klient</h4>
            <form onSubmit={ setUser }>
                <div style={{ display: "flex"}}>
                    <div style={{ width: "100%"}}>
                        <input type="text" placeholder="Username" value={username} onChange={handleUsername}/>
                        {usernameError && <span style={{ color: "red" }}>Błędny format loginu</span>}
                    </div>
                    <div style={{ width: "100%"}}>
                        <input type="password" placeholder="Password" value={password} onChange={handlePassword}/>

                    </div>
                </div>
                {passwordError && <span style={{ color: "red" }}>Bład logowania! Niepoprawne dane lub Twoje konto nie zostało jeszcze aktywowane</span>}
                <div align="right">
                    <button type="button" style={{ marginRight: "1%" }} onClick={ setUser } className="btn">Zaloguj</button>
                    <button type="button" className="btn red darken-2" onClick={ triggerState } >Anuluj</button>
                </div>
            </form>
        </div>
    );
}