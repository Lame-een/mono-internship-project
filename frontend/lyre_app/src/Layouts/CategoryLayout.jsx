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
import '../Assets/CSS/SongSearchLayout.css'

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
        let list = [<option key="nullkey" value="" />]
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
            <Form
                onSubmit={submitInput}
                className="song__search"
            >
                <input
                    id="song-search"
                    type="text"
                    className="song__search__input"
                    placeholder={`Search ${table}s`}
                />

                <InputGroup  className="song__search__sort">
                    <InputGroupAddon addonType="prepend" >
                        <InputGroupText className="song__search__radius-left">Sort By:</InputGroupText>
                    </InputGroupAddon>
                    <Input type="select" name="sortByColumn">
                        {genSelectionOptions()}
                    </Input>
                    <ButtonGroup>
                        <Button onClick={() => setRadioSelection("ASC")} active={radioSelection === "ASC"}>Asc</Button>
                        <Button className="song__search__radius-right" onClick={() => setRadioSelection("DESC")} active={radioSelection === "DESC"}>Desc</Button>
                    </ButtonGroup>
                </InputGroup>

                <button
                    className="song__search__button"
                    type="submit"
                >
                    Search
                </button>
            </Form>


            <QueryList query={query} table={table} />
        </div>
    );

}