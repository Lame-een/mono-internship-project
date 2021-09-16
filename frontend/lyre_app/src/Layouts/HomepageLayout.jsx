import React, { useState } from 'react';
import {Button, Form, Input, InputGroup, InputGroupAddon} from "reactstrap";

const HomepageLayout = () => {
    const [searchString, setSearchString] = useState('');
    const [searchStringBuffer, setBuffer] = useState('');

    function submitInput(e) {
        e.preventDefault();
        setSearchString(searchStringBuffer);
        console.log("searchString", searchString)
        console.log("searchStringBuffer", searchStringBuffer)
    }

    return (
        <Form onSubmit={submitInput}>
            <InputGroup>
                <InputGroupAddon addonType="prepend"><Button onClick={submitInput}>
                    Search songs</Button></InputGroupAddon>
                <Input onChange={(e) => { setBuffer(e.target.value) }} />
            </InputGroup>
        </Form>
    )
}

export default HomepageLayout