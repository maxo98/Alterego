import React, {useEffect} from "react";
import {useAuth} from "../providers/AuthProvider";
import {Button} from "react-bootstrap";
import Shop from "../Component/Shop";

export default function Home(props) {
    const {user, signOut} = useAuth();

    useEffect(() => {
        if(!user) {
            props.history.push("/login");
        }
    })

    return(
        <div className="App">
            <h1 className="Title">AlterEgo</h1>
            <h3 >Bienvenu sur la boutique en ligne</h3>
            <br/>
            <Shop />
            <br/>
            <Button  color="primary" type="submit" onClick={() => signOut()}>
                <h4>Se déconnecter</h4>
            </Button>
        </div>
    )
}
