import React from 'react';
import axios from 'axios';
import {Redirect, useHistory} from 'react-router-dom';
import {
    Input,
    InputGroup,
    InputGroupAddon,
    InputGroupText,
    Button,
    Form
} from 'reactstrap';


export default function LoginLayout() {
    const history = useHistory();

    function handleSubmit(event) {
        event.preventDefault();

        history.push('/');
    }

    return (
        <div>
            <Form onSubmit={handleSubmit}>
                <InputGroup>
                    <Input name="usernameInput" id="usernameInput0" placeholder="Username" />
                </InputGroup>
                <InputGroup>
                    <Input type="password" name="passwordInput" id="passwordInput0" placeholder="Password" />
                </InputGroup>

                <InputGroup>
                    <Button type="submit">Sign in</Button>
                </InputGroup>
            </Form>
        </div>
    );
}