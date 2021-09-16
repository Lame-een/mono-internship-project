import React from 'react'
import axios from 'axios'
import { withRouter } from 'react-router-dom'

import '../Assets/CSS/SongLayout.css'

import DemoAlbum from '../res/demo_album_cover.png'

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
            },
            lyrics:
                '                   To the dark, dark seas\n' +
                '                   Comes the only whale\n' +
                '                   Watching ships go by\n' +
                '                   It\'s the day we try\n' +
                '\n' +
                '                   It doesn\'t know\n' +
                '                   It\'s a Casio on a plastic beach, it\'s a Casio on a plastic beach\n' +
                '                   It\'s a styrofoam deep sea landfill, it\'s a styrofoam deep sea landfill\n' +
                '                   It\'s automated computer speech, it\'s automated computer speech\n' +
                '                   It\'s a Casio on a plastic beach, it\'s a Casio\n' +
                '\n' +
                '                   Did they haul you out\n' +
                '                   On a really hot day?\n' +
                '                   When the call got made\n' +
                '                   You had gone away\n' +
                '                   From us\n' +
                '\n' +
                '                   It doesn\'t know\n' +
                '                   It\'s a Casio on a plastic beach, it\'s a Casio on a plastic beach\n' +
                '                   It\'s a styrofoam deep sea landfill, it\'s a styrofoam deep sea landfill\n' +
                '                   It\'s automated computer speech, it\'s automated computer speech\n' +
                '                   It\'s a Casio on a plastic beach, it\'s a Casio\n' +
                '\n' +
                '                   Casio, Casio, Casio and green, green glow\n' +
                '                   Casio, Casio, Casio, green, green glow\n' +
                '                   Casio, Casio, Casio and green, green glow\n' +
                '                   Casio, Casio, Casio\n' +
                '\n' +
                '                   [Chorus]\n' +
                '                   It\'s a Casio on a plastic beach, it\'s a Casio on a plastic beach\n' +
                '                   It\'s a styrofoam deep sea landfill, it\'s a styrofoam deep sea landfill\n' +
                '                   It\'s automated computer speech, it\'s automated computer speech\n' +
                '                   It\'s a Casio on a plastic beach, it\'s a Casio\n' +
                '\n' +
                '                   [Bridge]\n' +
                '                   Plastico, plastico, plastico where the green, green grows\n' +
                '                   Plastico, plastico, plastico\n' +
                '                   Plastico, plastico, plastico where the green, green grows\n' +
                '                   Plastico, plastico, plastico'
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: song } = await axios.get(`/song/all/${id}`)

        this.setState({ song })
    }
    render() {
       return (
           <div className="song__layout">
               <div className="song__header">
                   <img src={DemoAlbum} alt="Album cover" className="song__header__cover"/>
                   <div className="song__header__info">
                       <h2 className="song__header__info__title">{this.state.song.SongName}</h2>
                       <p className="song__header__info__album">{this.state.song.AlbumName}</p>
                       <p className="song__header__info__author">{this.state.song.ArtistName}</p>
                   </div>
               </div>
               <div className="song__lyrics">
                   {this.state.lyrics}
               </div>
           </div>
       )
    }
}


export default withRouter(SongLayout)