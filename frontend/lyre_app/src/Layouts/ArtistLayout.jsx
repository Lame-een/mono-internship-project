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
                Name: ''
            },
            'albums':
                [{
                    AlbumName: null,
                    AlbumID: null,
                }]
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: artist } = await axios.get(`/artist/${id}`)
        const { data: albums } = await axios.get(`/artist/all/${id}`)

        console.log(artist);
        console.log(albums);

        this.setState({ 'artist': artist })
        this.setState({ 'albums': albums })
    }

    genRows() {
        let rows = []

        for (let i of this.state.albums) {
            rows.push(
                <Row>
                    <p><a href={'/album/' + i.AlbumID}>{i.AlbumName}</a></p>
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
                        <h2 className="song__header__info__title">{this.state.artist.Name}</h2>
                    </div>
                </div>

                <div className="artist__body__list">
                    <Container>
                        <Col>
                            <Row>Albums:</Row>
                            {this.genRows()}
                        </Col>
                    </Container>
                </div>

            </div>

        )
    }
}


export default withRouter(ArtistLayout)