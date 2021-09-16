import React from 'react'
import axios from 'axios'
import { withRouter } from 'react-router-dom'
import { Container, Row, Col } from 'reactstrap';

import '../Assets/CSS/SongLayout.css'

class ArtistLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            'artist': {
            },
            'songs':
                [{
                    ArtistName: null,
                    SongID: null,
                    SongName: null,
                    ArtistID: null
                }]
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: artist } = await axios.get(`/artist/${id}`)
        //const { data: songs } = await axios.get(`/artist/all/${id}`)

        this.setState({ 'artist': artist })
        //this.setState({ 'songs': songs })
    }

    genRowsAlbums() {
        let rows = []

        //for (let i of this.state.albums) {
        for (let i = 0; i < 5; i++) {

            rows.push(
                <Row>
                    <p><a href={'/album/' + i}>{'Album numero ' + i}</a></p>
                    <p />
                </Row>
            );
        }
        return rows;
    }

    genRowsSongs() {
        let rows = []

        //for (let i of this.state.songs) {
        for (let i = 0; i < 5; i++) {

            rows.push(
                <Row>
                    <p><a href={'/song/' + i}>{'Song numero ' + i}</a></p>
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
                    <div className="song__header__info">
                        <h2 className="song__header__info__title">{this.state.artist.name}</h2>
                    </div>
                </div>

                <div className="artist__body__list">
                    {/*lemme know if you need a proper table with 2 columns or if 2 seperate are okay!*/}
                    <Container>
                        <Col>
                            <Row>Albums:</Row>
                            {this.genRowsAlbums()}
                        </Col>
                    </Container>
                    <Container>
                        <Col>
                            <Row>Songs:</Row>
                            {this.genRowsSongs()}
                        </Col>
                    </Container>
                </div>

            </div>

        )
    }
}


export default withRouter(ArtistLayout)