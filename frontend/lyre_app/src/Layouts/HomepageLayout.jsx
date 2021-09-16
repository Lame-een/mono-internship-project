import React, { useState } from 'react';
import { useHistory } from 'react-router';
import { useEffect } from 'react/cjs/react.development';
import { Button, Form, Input, InputGroup, InputGroupAddon } from "reactstrap";

const HomepageLayout = () => {
    const history = useHistory();
    const [searchString, setSearchString] = useState('');

    function submitInput(e) {
        e.preventDefault();
        history.push('/song?q=' + searchString);
        console.log(searchString);
    }

    return (
        <Form onSubmit={submitInput}>
            <InputGroup>
                <InputGroupAddon addonType="prepend"><Button onClick={submitInput}>
                    Search songs</Button></InputGroupAddon>
                <Input onChange={(e) => { setSearchString(e.target.value) }} />
            </InputGroup>
        </Form>
    )
}

export default HomepageLayout