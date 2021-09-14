import React, { useEffect, useState } from 'react';
import QueryPaginator from '../Components/QueryPaginator';
import { ListGroup, ListGroupItem, Media } from 'reactstrap'
import axios from 'axios'
import {databaseUrl} from '../Common/ServerProvider'

export default function QueryList(props) {

    const query = props.query;
    const path = props.path;
    const table = props.table;

    const [queryResults, setResults] = useState([]);

    //TODO - add list component for more seamless integration?
    //     - fully connect query to results
    //     - link results to pages

    useEffect(() =>{
        getQuery();
    }
    , [query]);

    function formatQuery(){
        let str = '?';
        if(query.filter != ''){
            str += 'q=' + query.filter;
        }
        if(query.sortby != ''){
            if(str != '?'){
                str += '&';
            }
            str += 'sort=' + query.sortby;
        }
        if(query.orderby != ''){
            if(str != '?'){
                str += '&';
            }
            str += 'order=' + query.orderby;
        }

        if(str === '?'){
            return '';
        }
        return str;
    }

    function getQuery() {
        if(query == null) return;
        let res = null;
        axios.get(databaseUrl + path + formatQuery()).then((response) => {setResults(response.data)});
    }

    return (
        <div>
            <ListGroup>
                <ListGroupItem>
                    <Media>
                        <Media right>
                            <Media object src="https://cdn.discordapp.com/attachments/656219650753036318/887176407099248692/coeD3.gif" alt="Generic placeholder image" />
                        </Media>
                        <Media body href="#">
                            <Media heading>
                                SONG NAME HERE
                            </Media>
                            LIST OTHER SONG STUFF HERE
                        </Media>
                    </Media>
                </ListGroupItem>
                <ListGroupItem>
                    <Media left>
                        <Media left>
                            <Media object src="https://cdn.discordapp.com/attachments/656219650753036318/887176407099248692/coeD3.gif" alt="Generic placeholder image" />
                        </Media>
                        <Media body right href="#">
                            <Media heading>
                                SONG NAME HERE
                            </Media>
                            LIST OTHER SONG STUFF HERE
                        </Media>
                    </Media>
                </ListGroupItem>
            </ListGroup>


            <QueryPaginator {...props} />
        </div>
    );
}