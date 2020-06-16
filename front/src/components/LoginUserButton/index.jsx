import React from "react";

const LoginClientButton = props => {
    return <button onClick={ props.loginClient } className="waves-effect waves-light btn btn-size">Zaloguj jako klient</button>
}

export default LoginClientButton