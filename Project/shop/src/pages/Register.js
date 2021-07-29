import React, {useEffect, useState} from 'react';
import {useAuth} from '../providers/AuthProvider';
import '../App.css';
import {Button, Col, Container, Form,} from "react-bootstrap";

export default function Register(props) {
    const [email, setEmail] = useState('');
    const [tag, setTag] = useState('');
    const [password, setPassword] = useState('');
    const [registered, setRegistered] = useState(false);
    const {signUp, signIn, addPlayer} = useAuth();

    const sendData = async() => {
        await addPlayer(tag, email);
    }

    useEffect(() => {
        if(registered) {
            sendData().then(() => {
                props.history.push('/');
            });
        }
    }, [registered]);

    const register = async () => {
        try {
            if(email && password && tag) {
                await signUp(email, password);
                await signIn(email, password);
                setRegistered(true);
            }
        } catch (error) {
            console.log(`Failed to sign in: ${error.message}`);
        }
    }

    const login = () => {
        props.history.push('/Login');
    }

    return (
        <div className="App">
            <h1 className="Title">
                Créer un compte :
            </h1>
            <Container>
                <Form>
                    <Form.Group controlId="formBasicText">
                        <Form.Label>Pseudo</Form.Label>
                        <Col md={{span:6, offset: 3}}>
                            <Form.Control type="text" placeholder="Pseudo"
                                          onChange={(e) => setTag(e.target.value)} value={tag} />
                        </Col>
                    </Form.Group>

                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email</Form.Label>
                        <Col md={{span:6, offset: 3}}>
                            <Form.Control type="email" placeholder="Email"
                                          onChange={(e) => setEmail(e.target.value)} value={email} />
                        </Col>
                    </Form.Group>

                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Mot de passe</Form.Label>
                        <Col md={{span:6, offset: 3}}>
                            <Form.Control type="password" placeholder="Mot de passe"
                                          onChange={(e) => setPassword(e.target.value)} value={password} />
                        </Col>
                    </Form.Group>
                </Form>
            </Container>
            <br/>
            <Container>
                <Col>
                    <Button  variant="primary" type="submit" onClick={() => register()}>
                        <h4>Créer un compte</h4>
                    </Button>
                </Col>
                <br/>
                <Col>
                    <Button variant="outline-primary" type="submit" onClick={() => login()}>
                        <h4>Se connecter</h4>
                    </Button>
                </Col>
            </Container>
            <br/>
        </div>
    );
}
