import React from 'react'
import axios from 'axios'
import { withRouter } from 'react-router-dom'

class SongLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            song: {
                SongId: null,
                SongName: null,
                AlbumName: null,
                ArtistName: null,
                GenreName: null
            }
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: song } = await axios.get(`/song/all/${id}`)

        this.setState({ song })
    }
    render() {
       return <h1>{this.state.song.SongName}</h1>
    }
}


export default withRouter(SongLayout)