import React, {useState} from "react";
import Table from "../Table";
import RequestListButton from "../RequestListButton";
import RequestOfferListButton from "../RequestOfferListButton";

export default function WorkerMain() {

    const [requestList, setRequestList] = useState(false);

    const triggerStateRequest = () => {
        setRequestList(true);
    }

    return (
        <>
            <div className="container" style={{color: "white"}}>
                <br/>
                <h1>Panel pracownika</h1>
                <div className="buttons">
                    <RequestListButton requestList={triggerStateRequest} />
                </div>
                <br/>
                {requestList &&
                    <div style={{color: 'black', padding: "10px", background: "white"}}>
                        <h4>Zgłoszenia oczekujące</h4>
                        <Table/>
                    </div>
                }
            </div>
        </>
    );
}