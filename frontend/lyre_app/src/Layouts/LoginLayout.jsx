import React, { useContext, useState } from 'react';
import axios from 'axios';
import {Link, useHistory} from 'react-router-dom';
import {
    Input,
    InputGroup,
    Button,
    Form,
    Modal,
    ModalBody,
    ModalFooter
} from 'reactstrap';

import { LoginContext } from '../Stores/LoginContext';


export default function LoginLayout() {
    const history = useHistory();
    const context = useContext(LoginContext);

    const [modal, setModal] = useState(false);
    function toggleModal() { setModal(!modal) }


    function handleSubmit(event) {
        event.preventDefault();

        let respo = null;

        axios.post('User/login/', {
            username: (event.target[0].value),
            password: (event.target[1].value)
        }).then((response) => { respo = response }).then(() => {

            context.setLoggedIn(true);
            let toekn = respo.headers.authorization.split(' ')[1];
            context.setToken(toekn);

            sessionStorage.setItem('loggedIn', true);
            sessionStorage.setItem('token', toekn);

            history.push('/');
        }).catch(() => {
            setModal(true);
        });
        //context.setLoggedIn(true);

    }

    return (
        <div>
            <h1>Login</h1>
            <Form onSubmit={handleSubmit}>
                <InputGroup>
                    <Input name="usernameInput" id="usernameInput0" placeholder="Username" />
                </InputGroup>
                <InputGroup>
                    <Input type="password" name="passwordInput" id="passwordInput0" placeholder="Password" />
                </InputGroup>

                Not a user? <Link to='/register'>Sign up here</Link>

                <InputGroup>
                    <Button type="submit">Sign in</Button>
                </InputGroup>

            </Form>
            {/*<Modal isOpen={modal} toggle={toggleModal} className="login__modal__error">*/}
            <Modal isOpen={modal} toggle={toggleModal}>
                <ModalBody>
                    Wrong username or password.
                </ModalBody>
                <ModalFooter>
                    <Button color="danger" onClick={toggleModal}>Ok</Button>
                </ModalFooter>
            </Modal>
        </div>
    );
}