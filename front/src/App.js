import React, { useEffect, useState } from "react";
import './App.css';
import LoginWorkerButton from "./components/LoginWorkerButton";
import AddApplicationButton from "./components/AddApplicationButton";
import LoginWorkerForm from "./components/LoginWorkerForm"
import AddApplicationForm from "./components/AddApplicationForm";
import LoginClientButton from "./components/LoginUserButton";
import LoginClientForm from "./components/LoginClientForm"
import Axios from "axios";


export default function App() {


    const [login, setLogin] = useState(false);
    const [loginClient, setLoginClient] = useState(false);
    const [application, setApplication] = useState(false);

    const triggerStateLogin = () => {
        setApplication(false);
        setLoginClient(false);
        setLogin(true);
    }

    const triggerStateLoginClient = () => {
        setApplication(false);
        setLogin(false);
        setLoginClient(true);
    }

    const triggerStateApplication = () => {
        setApplication(true);
        setLoginClient(false);
        setLogin(false);
    }

    const addApp = (app) => {
        Axios.post('http://localhost:59062/api/person', app).then(r => console.log(r));
    }


  return (
    <div className="App">
        <header className="App-header">
            <h1>SpaceY</h1>
        </header>
        <div className="buttons">
            <AddApplicationButton addAplication={ triggerStateApplication }/>
            <LoginWorkerButton loginWorker={ triggerStateLogin }/>
            <LoginClientButton loginClient={ triggerStateLoginClient }/>
        </div>
        <div className="buttons">
            {login && <LoginWorkerForm setLogin={ setLogin }/>}
            {loginClient && <LoginClientForm setLoginClient={ setLoginClient }/>}
            {application && <AddApplicationForm setApplication={ setApplication } addApp={ addApp }/>}
        </div>

    </div>
  );
}

