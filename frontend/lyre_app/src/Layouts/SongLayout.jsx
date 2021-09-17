import React from 'react'
import axios from 'axios'
import {Link, withRouter} from 'react-router-dom'

import '../Assets/CSS/SongLayout.css'

import Cover from '../Components/Cover'

class SongLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            song: {
                SongId: null,
                SongName: null,
                AlbumName: null,
                ArtistName: null,
                GenreName: null,
                AlbumID: null,
                ArtistID: null,
                Cover: null
            },
            lyrics: null
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: song } = await axios.get(`/song/all/${id}`)

        const { data: lyrics } = await axios.get(`/lyrics/song/${id}`)
        const [lyricsText] = lyrics

        console.log(song);

        this.setState({ song, lyrics: lyricsText?.Text})
    }
    render() {
       return (
           <div className="song__layout">
               <div className="song__header">
                   <Cover src={this.state.song.Cover} alt="Album cover" className="song__header__cover"/>
                   <div className="song__header__info">
                       <h2 className="song__header__info__title">{this.state.song.SongName}</h2>
                       <p className="song__header__info__album">
                           <Link to={'/album/'+this.state.song.AlbumID}>
                               {this.state.song.AlbumName}
                           </Link>
                       </p>
                       <p className="song__header__info__author">
                           <Link to={'/artist/'+this.state.song.ArtistID}>
                               {this.state.song.ArtistName}
                           </Link>
                       </p>
                   </div>
               </div>
               <div className="song__lyrics">
                   {this.state.lyrics || 'Nema teksta za ovu pjesmu'}
               </div>
           </div>
       )
    }
}


export default withRouter(SongLayout)