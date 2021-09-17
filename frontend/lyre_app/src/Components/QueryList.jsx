import React, { useEffect, useState } from 'react';
import QueryPaginator from '../Components/QueryPaginator';
import { Container, Row, Col, Media } from 'reactstrap'
import { Link } from 'react-router-dom'
import axios from 'axios'
import Cover from './Cover';
import '../Assets/CSS/QueryList.css'
import 'bootstrap/dist/css/bootstrap.min.css';

export default function QueryList(props) {

    const query = props.query;
    const table = props.table;
    const [currentPage, setPage] = useState(1);

    const [queryResults, setResults] = useState([]);
    const [displayList, setDisplayList] = useState([]);

    useEffect(() => {
        genEmptyList();
    }, [table]);

    useEffect(() => {
        getQuery();
    }, [query, currentPage]);

    useEffect(() => {
        genList();
    }, [queryResults]);


    function onPageChange(pageNum) {
        setPage(pageNum);
    }

    function formatQuery() {
        let str = '';

        if (table === 'song') {
            str = 'song/all?';
        } else if (table === 'album') {
            str = 'album/artist/all?';
        } else if (table === 'artist') {
            str = 'artist?';
        }

        if (table === 'song') {
            if (query.filter !== '') {
                str += 'q=songname:' + query.filter;
            }
        }
        else if (table === 'album') {
            if (query.filter !== '') {
                str += 'q=albumname' + query.filter;
            }
        }
        else if (table === 'artist') {
            if (query.filter !== '') {
                str += 'q=artistname' + query.filter;
            }
        } else {
            if (query.filter !== '') {
                str += 'q=' + query.filter;
            }
        }

        if (query.sortby !== '') {
            if (str !== '?') str += '&';

            str += 'sort=' + query.sortby;
        }
        if (query.orderby !== '') {
            if (str !== '?') str += '&';

            str += 'order=' + query.orderby;
        }

        if (str !== '?') str += '&';
        str += 'page=' + currentPage + '&pagesize=8';

        return str;
    }

    function getQuery() {
        if (query == null) return;
        axios.get(formatQuery()).then((response) => { setResults(response.data) });
    }

    function genMedia(queryObj) {
        let media = "";

        if (table === "song") {
            media = (
                <div className="querylist__listing">
                    <Cover className="querylist__listing__cover" src={queryObj.Cover} alt="Cover" />

                    <div className="querylist__listing__body">
                        <h2>
                            <Link to={"/song/" + queryObj.SongID}>{queryObj.SongName}</Link>
                        </h2>
                        <p>
                            <Link to={"/album/" + queryObj.AlbumID}>Album: <em>{queryObj.AlbumName}</em></Link>
                            <br />
                            <Link to={"/artist/" + queryObj.ArtistID}>Artist: <em>{queryObj.ArtistName}</em></Link>
                        </p>
                    </div>
                </div>
            );
        }

        if (table === "album") {
            media = (
                <div className="querylist__listing">
                    <Cover className="querylist__listing__cover" src={queryObj.Cover} alt="Cover" />

                    <div className="querylist__listing__body">
                        <h2>
                            <Link to={"/album/" + queryObj.AlbumID}>{queryObj.AlbumName}</Link>
                        </h2>
                        <p>
                            <Link to={"/artist/" + queryObj.ArtistID}>Artist: <em>{queryObj.ArtistName}</em></Link>
                        </p>
                    </div>
                </div>
            );
        }

        if (table === "artist") {
            console.log(queryObj);
            media = (
                <div className="querylist__listing__artist">

                    <div className="querylist__listing__body">
                        <h2>
                            <Link to={"/artist/" + queryObj.ArtistID}>{queryObj.Name}</Link>
                        </h2>
                    </div>
                </div>
            );
        }

        return media;
    }

    function genEmptyList() {
        let colBuffer = [];
        let displayListBuffer = [];
        for (let i = 0; i < 4; i++) {
            for (let j = 0; j < 2; j++) {
                let media = <div />;
                colBuffer.push((<Col className="querylist__col" key={`${i}-${j}`} >{media}</Col>));
            }

            let row = (
                <Row className="querylist__row">
                    {colBuffer[(i * 2)]}
                    {colBuffer[(i * 2) + 1]}
                </Row>
            );

            displayListBuffer.push(row);
        }
        setDisplayList(displayListBuffer);
    }

    function genList() {
        let colBuffer = [];
        let displayListBuffer = [];

        let itemIndex = 0;
        while (itemIndex < 8) {
            for (let j = 0; j < 2; j++) {
                let media;
                if (itemIndex >= queryResults.length) media = <div />;
                else media = genMedia(queryResults[itemIndex]);
                colBuffer.push((<Col className="col-query" key={itemIndex} >{media}</Col>));
                itemIndex++;
            }

            let row = (
                <Row className="querylist__row">
                    {colBuffer[(itemIndex / 2) - 1]}
                    {colBuffer[(itemIndex / 2)]}
                </Row>
            );

            displayListBuffer.push(row);
        }
        setDisplayList(displayListBuffer);
    }

    return (
        <div>
            <QueryPaginator className="querylist__paginator" page={currentPage} pageChange={onPageChange} pagesExist={true} {...props} />

            <Container className="querylist__container">
                {displayList}
            </Container>
            
            <QueryPaginator className="querylist__paginator" page={currentPage} pageChange={onPageChange} pagesExist={true} {...props} />
        </div>
    );
}