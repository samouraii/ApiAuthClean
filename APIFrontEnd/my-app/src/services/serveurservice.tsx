import Axios from 'axios';

export let serveurIp = "https://localhost:7013";

let BaseAxios = Axios.create({
        baseURL : serveurIp
    });


export default BaseAxios;