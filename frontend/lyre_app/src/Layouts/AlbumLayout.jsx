import React from 'react'
import axios from 'axios'
import { withRouter } from 'react-router-dom'
import Cover from '../Components/Cover';
import { Container, Row, Col } from 'reactstrap';

import '../Assets/CSS/SongLayout.css'

class AlbumLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            'album': {
                artistID: '',
                name: '',
                number_of_tracks: 0,
                cover: '',
                year: 0,
            },
            'songs':
                [{
                    AlbumName: null,
                    SongID: null,
                    SongName: null,
                    ArtistName: null,
                    ArtistID: null
                }]
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: album } = await axios.get(`/album/id/${id}`)
        const { data: songs } = await axios.get(`/album/all/${id}`)
        this.setState({ 'album': album })
        this.setState({ 'songs': songs })
    }

    genRows() {
        let rows = []

        for (let i of this.state.songs) {

            rows.push(
                <Row>
                    <p><a href={'/song/' + i.SongID}>{i.SongName}</a></p>
                    <p />
                </Row>
            );
        }
        return rows;
    }

    render() {
        return (

            <div className="song__layout">
                <div className="song__header">
                    <Cover className="song__header__cover" src={this.state.album.cover} alt="Album Cover" />
                    <div className="song__header__info">
                        <h2 className="song__header__info__title">{this.state.album.name}</h2>
                        {/*very, VERY messy, don't have the time or the will to fix it in the backend DAMN YOU KARLO!*/}
                        <p className="song__header__info__album"><a href={'/artist/' + this.state.album.artistID}>{this.state.songs[0].ArtistName}</a></p>
                        <p className="song__header__info__author">{this.state.album.year}</p>
                    </div>
                </div>

                <div className="song__lyrics">
                    {this.state.album.number_of_tracks} songs are on this album.
                    <Container>
                        <Col>
                            {this.genRows()}
                        </Col>
                    </Container>
                </div>

            </div>

        )
    }
}


export default withRouter(AlbumLayout)