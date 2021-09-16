import React, { useEffect, useState } from 'react';
import QueryPaginator from '../Components/QueryPaginator';
import { Container, Row, Col, Media } from 'reactstrap'
import { Link } from 'react-router-dom'
import axios from 'axios'
import Cover from './Cover';

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
        console.log(queryResults);
    }, [queryResults]);


    function onPageChange(pageNum) {
        setPage(pageNum);
    }

    //disgusting
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
                <Media>
                    <Media left href={"/song/" + queryObj.SongID}>
                        <Cover src={queryObj.Cover} alt="Cover" />
                    </Media>
                    <Media body>
                        <Media heading>
                            <Link to={"/song/" + queryObj.SongID}>{queryObj.SongName}</Link>
                        </Media>
                        <Media>
                            <Link to={"/artist/" + queryObj.ArtistID}>Artist: {queryObj.ArtistName}</Link>
                        </Media>
                        <Media>
                            <Link to={"/album/" + queryObj.AlbumID}>Album: {queryObj.AlbumName}</Link>
                        </Media>
                    </Media>
                </Media>
            );
        }

        if (table === "album") {
            media = (
                <Media>
                    <Media left href={"/song/" + queryObj.AlbumID}>
                        <Media object src="https://cdn.discordapp.com/attachments/656219650753036318/887176407099248692/coeD3.gif" alt="Cover" />
                    </Media>
                    <Media body>
                        <Media heading>
                            <Link to={"/album/" + queryObj.AlbumID}>{queryObj.AlbumName}</Link>
                        </Media>
                        <Link to={"/artist/" + queryObj.ArtistID}>Artist: {queryObj.ArtistName}</Link>
                    </Media>
                </Media>
            );
        }

        if (table === "artist") {
            media = (
                <Media>
                    <Media body>
                        <Media heading>
                            <Link to={"/artist/" + queryObj.ArtistID}>{queryObj.Name}</Link>
                        </Media>
                    </Media>
                </Media>
            );
        }

        return media;
    }

    function genEmptyList() {
        let colBuffer = [];
        let displayListBuffer = [];
        for (let i = 0; i < 4; i++) {
            for (let j = 0; j < 2; j++) {
                let media = <Media className="media__empty"/>;
                colBuffer.push((<Col className="col-query" key={i, j} >{media}</Col>));
            }

            let row = (
                <Row>
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
                if (itemIndex >= queryResults.length) media = <Media className="media__empty"/>;
                else media = genMedia(queryResults[itemIndex]);
                colBuffer.push((<Col className="col-query" key={itemIndex} >{media}</Col>));
                itemIndex++;
            }

            let row = (
                <Row>
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
            <Container>
                {displayList}
            </Container>

            <QueryPaginator page={currentPage} pageChange={onPageChange} pagesExist={true} {...props} />
        </div>
    );
}