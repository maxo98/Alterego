import React, {useEffect, useState} from "react";
import {useAuth} from "../providers/AuthProvider";
import {ListGroup, ListGroupItem} from "react-bootstrap";

export default function Shop(props) {
    const [skins, setSkins] = useState([]);
    const [playerSkin, setPlayerSkins] = useState([]);
    const [loading, setLoading] = useState(true);
    const [activated, setActivated] = useState([]);
    const [state, setState] = useState(1);
    const {fetchAllSkins, fetchPlayerSkins, playerBuySkin} = useAuth();

    const forceUpdate = () => {
        setState(state + 1);
    }

    const fetchData = async () => {
        const skins = await fetchAllSkins();
        const playersData = await fetchPlayerSkins();
        if(playersData) {
            setPlayerSkins(playersData.skins);
        }
        setSkins(skins[0].skinId);
    }

    useEffect(() => {
        fetchData().then(r => {});
    }, []);

    useEffect(() => {
        if(skins) {
            setLoading(false);
        }
    }, [skins,activated]);

    const handleItemClick = async (index) => {
        const tmp = activated;
        if(!tmp[index]) {
            tmp[index] = true;
        }
        await playerBuySkin(skins[index]);
        setActivated(tmp);
        forceUpdate();
    }

    function CheckUnlocked() {
        let loop = [];
        for(let i = 0; i < skins.length; i++) {
            let unlocked = false;
            const currentPlayerSkin = playerSkin.find(function (e) {
                return e.skinId === skins[i];
            });
            if(currentPlayerSkin) {
                unlocked = currentPlayerSkin.unlocked
            }
            if(unlocked) {
                loop.push(
                    <ListGroupItem key={i} as="li" active>{skins[i]}</ListGroupItem>
                )
            } else {
                loop.push(
                    <ListGroupItem key={i} as="li" action onClick={() => handleItemClick(i)} active={activated[i]}>
                        {skins[i]}
                    </ListGroupItem>
                )
            }
        }
        return loop;
    }

    function Items() {
        if(loading) {
            return <h4>Chargement...</h4>
        } else {
            return (
                <ListGroup>
                    <CheckUnlocked/>
                </ListGroup>
            );
        }
    }

    return(
        <div>
            <Items/>
        </div>
    )
}
