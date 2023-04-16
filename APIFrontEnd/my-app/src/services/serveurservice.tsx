import Axios from 'axios';
import { accountService } from './account_service';

export let serveurIp = "https://localhost:7013";

let BaseAxios = Axios.create({
        baseURL : serveurIp,
        //headers:{'Authorization': 'Bearer 111111111111111'}
    });
    


 export  let CoAxios = Axios.create({
        baseURL : serveurIp,
        
    });


export default BaseAxios;