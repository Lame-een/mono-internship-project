import React, { useState } from 'react'
import { useLocation } from 'react-router';
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
import { useEffect } from 'react/cjs/react.development';


//takes in category to determine which selection to return
export default function CategoryLayout(props) {
    const table = props.table;
    const location = useLocation();
    const inQuery = (new URLSearchParams(location.search)).get('q');
    const [radioSelection, setRadioSelection] = useState("ASC");
    const [query, setQuery] = useState(null);

    useEffect(()=>{
        if(inQuery != null){
            setQuery({
                "filter": inQuery,
                "sortby": '',
                "orderby": 'ASC'
            });
        }
    }, []);

    function genSelectionOptions() {
        let columns = getModelColumns(table);
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
            <h2>Searching {table + 's'}</h2>
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

            <QueryList query={query} table={table} />
        </div>
    );

}