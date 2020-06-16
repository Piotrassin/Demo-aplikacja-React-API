import React, { useEffect, useState } from "react";
import './App.css';
import LoginWorkerButton from "./components/LoginWorkerButton";
import AddApplicationButton from "./components/AddApplicationButton";
import LoginWorkerForm from "./components/LoginWorkerForm"
import AddApplicationForm from "./components/AddApplicationForm";


export default function App() {

    const [login, setLogin] = useState(false);
    const [application, setApplication] = useState(false);

    const triggerStateLogin = () => {
        setApplication(false);
        setLogin(true);
    }

    const triggerStateApplication = () => {
        setApplication(true);
        setLogin(false);
    }


  return (
    <div className="App">
        <header className="App-header">
            <h1>SpaceY</h1>
        </header>
        <div className="buttons">
            <AddApplicationButton addAplication={ triggerStateApplication }/>
            <LoginWorkerButton loginWorker={ triggerStateLogin }/>
        </div>
        <div className="buttons">
            {login && <LoginWorkerForm setLogin={ setLogin }/>}
            {application && <AddApplicationForm setApplication={ setApplication }/>}
        </div>

    </div>
  );
}

