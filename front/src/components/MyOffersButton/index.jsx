import React from "react";

const MyOffersButton = props => {
    return <button onClick={ props.getList } className="waves-effect waves-light btn btn-size">Twoje oferty</button>
}

export default MyOffersButton