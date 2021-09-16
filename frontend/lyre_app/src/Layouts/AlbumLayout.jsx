import React from 'react'
import axios from 'axios'
import { withRouter } from 'react-router-dom'

import '../Assets/CSS/SongLayout.css'

import DemoAlbum from '../res/demo_album_cover.png'

class AlbumLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            album: {
                AlbumName: null,
                SongID: null,
                SongName: null,
                ArtistName: null,
                ArtistID: null
            }
        }
    }

    async componentDidMount() {
        const { id } = this.props.match.params

        const { data: album } = await axios.get(`/album/all/${id}`)
        console.log(album)
        this.setState({ album })
    }
    render() {
       return (
        
        <div className="song__layout">
            
           
            <img src={DemoAlbum} alt="Album cover" className="song__header__cover"/>
            <div className="song__header__info">
                <h2 className="song__header__info__title">{this.state.album.AlbumName}</h2>
            </div>
            <div>
                <h2>{this.state.album.ArtistName}</h2>
            </div>
            <div>    
                {this.state.album.map(({AlbumName, SongID, SongName, ArtistName, ArtistID}) => {
                return (
                <tr>
                    <td> { SongName } </td> 
                </tr>
                )})}
            </div>
        </div>

       )
    }
}


export default withRouter(AlbumLayout)