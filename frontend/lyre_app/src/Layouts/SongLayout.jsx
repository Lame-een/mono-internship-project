import React from 'react'
import axios from 'axios'

class SongLayout extends React.Component {
    constructor(props) {
        super(props);
        this.state = { song: null }
    }

    async componentDidMount() {
        const {id} = this.props.match.params;
        const response = await axios.get(`/song/all/${id}`)
    }
    render() {
       return <h1>AAAA</h1>
    }
}


export default SongLayout