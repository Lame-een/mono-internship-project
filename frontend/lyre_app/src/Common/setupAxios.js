import axios from 'axios'
import { BASE_API_URL } from "./ServerProvider";

const setupAxios = () => {
    axios.defaults.baseURL = BASE_API_URL
}

export default setupAxios