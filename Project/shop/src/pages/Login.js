import React, {useState} from 'react';
import {useAuth} from '../providers/AuthProvider';
import '../App.css';
import {Button, Col, Container, Form,} from "react-bootstrap";

export default function Login(props) {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const {signIn} = useAuth();

    const logIn = async () => {
        try {
            if(email && password) {
                await signIn(email, password);
                props.history.push('/');
            }
        } catch (error) {
            console.log(`Failed to sign in: ${error.message}`);
        }
    }

    const registration = () => {
        props.history.push('/register');
    }

    return (
        <div className="App">
            <h1 className="Title">
                Connectez vous :
            </h1>
            <Container >
                <Form>
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
                    <Button variant="primary" type="submit" onClick={() => logIn()}>
                        <h4>Se connecter</h4>
                    </Button>
                </Col>
                <br/>
                <Col>
                    <Button variant="outline-primary" type="submit" onClick={() => registration()}>
                        <h4>Créer un compte</h4>
                    </Button>
                </Col>
            </Container>
            <br/>
        </div>
    );
}
