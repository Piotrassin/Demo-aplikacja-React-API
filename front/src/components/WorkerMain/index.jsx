import React from "react";
import Table from "../Table";

export default function WorkerMain() {

    return (
        <>
            <div className="container">
                <br/>
                <div style={{display: "flex", justifyContent: "space-between", color: 'white'}}>
                    <h1>Oczekujące zgłoszenia</h1>
                </div>
                <Table/>
            </div>
        </>
    );
}