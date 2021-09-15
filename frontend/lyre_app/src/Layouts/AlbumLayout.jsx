import React from 'react'
import axios from 'axios'

class AlbumLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = { album: null }
    }

    async componentDidMount() {
        const {id} = this.props.match.params;
        const response = await axios.get(`/album/all/${id}`)
    }
    render() {
       return <h1>Album Layout</h1>
    }
}


export default AlbumLayout