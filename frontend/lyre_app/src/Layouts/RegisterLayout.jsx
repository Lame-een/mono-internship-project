import React, { useContext, useState } from 'react';
import axios from 'axios';
import { Redirect, useHistory } from 'react-router-dom';
import {
    Input,
    InputGroup,
    InputGroupAddon,
    InputGroupText,
    Button,
    Form,
    Modal,
    ModalBody,
    ModalHeader,
    ModalFooter
} from 'reactstrap';


export default function RegisterLayout() {
    const history = useHistory();

    const [responseMsg, setResponseMsg] = useState('');
    const [errorModal, setErrorModal] = useState(false);
    const [successModal, setSuccessModal] = useState(false);
    function toggleErrorModal() { setErrorModal(!errorModal) };

    function handleSubmit(event) {
        event.preventDefault();

        let target = event.target;
        if(target[1].value !== target[2].value){
            setErrorModal(true);
            return;
        }

        let respo = null;
        axios.post('User/register/', {
            username: (event.target[0].value),
            password: (event.target[1].value)
        }).then((response) => { respo = response; setResponseMsg(respo.data); }).catch((error) => {
            console.log(error);
            setErrorModal(true);
        }).then(()=>{setSuccessModal(true)});
    }

    return (
        <div>
            <h1>Register</h1>
            <Form onSubmit={handleSubmit}>
                <InputGroup>
                    <Input name="usernameInput" id="usernameInput0" placeholder="Username" />
                </InputGroup>
                <InputGroup>
                    <Input type="password" name="passwordInput" id="passwordInput0" placeholder="Password" />
                </InputGroup>
                <InputGroup>
                    <Input type="password" name="passwordInputVerify" id="passwordInput1" placeholder="Password again" />
                </InputGroup>

                Already a user? <a href='/register'>Sign in here</a>

                <InputGroup>
                    <Button type="submit">Sign up</Button>
                </InputGroup>
            </Form>
            <Modal isOpen={errorModal} toggle={toggleErrorModal}>
                <ModalBody>
                    Invalid username, or passwords aren't matching.
                </ModalBody>
                <ModalFooter>
                    <Button color="danger" onClick={toggleErrorModal}>Ok</Button>
                </ModalFooter>
            </Modal>
            <Modal isOpen={successModal}>
                <ModalBody>
                    {responseMsg}
                </ModalBody>
                <ModalFooter>
                    <Button color="danger" onClick={() => {history.push('/login')}}>Go to Login</Button>
                </ModalFooter>
            </Modal>
        </div>
    );
}