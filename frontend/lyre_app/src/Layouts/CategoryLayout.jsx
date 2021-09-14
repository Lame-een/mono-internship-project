import React, { useState } from 'react'
import {
    Input,
    InputGroup,
    InputGroupAddon,
    InputGroupText,
    ButtonGroup,
    Button,
    Form
} from 'reactstrap';
import QueryList from '../Components/QueryList'
import getModelColumns from '../Common/ModelColumns';


//takes in category to determine which selection to return
export default function CategoryLayout(props) {
    const [radioSelection, setRadioSelection] = useState("ASC");
    const [query, setQuery] = useState(null);

    function genSelectionOptions() {
        let columns = getModelColumns(props.category);
        let list = [<option key="nullkey" value=""></option>]
        for (const col of columns) {
            for (const [colkey, colval] of Object.entries(col)) {
                list.push(
                    <option key={colkey} value={colkey}>{colval}</option>
                );
            }
        }
        return list;
    }

    function submitInput(e) {
        e.preventDefault();
        let t = e.target;

        let q = {
            "filter": t[0].value,
            "sortby": t[1].value,
            "orderby": radioSelection
        };
        setQuery(q);
    }

    return (
        <div>
            <Form onSubmit={submitInput}>
                <InputGroup>
                    <Input name="searchQuery" id="inputSearch0" placeholder="search" />
                </InputGroup>

                <InputGroup>
                    <InputGroupAddon addonType="prepend">
                        <InputGroupText>Sort By:</InputGroupText>
                    </InputGroupAddon>
                    <Input type="select" name="sortByColumn" id="inputColumn0">
                        {genSelectionOptions()}
                    </Input>

                    <ButtonGroup>
                        <Button onClick={() => setRadioSelection("ASC")} active={radioSelection === "ASC"}>Asc</Button>
                        <Button onClick={() => setRadioSelection("DESC")} active={radioSelection === "DESC"}>Desc</Button>
                    </ButtonGroup>
                </InputGroup>

                <InputGroup>
                    <Button type="submit">Search</Button>
                </InputGroup>
            </Form>

            <QueryList {...props} />
        </div>
    );

}