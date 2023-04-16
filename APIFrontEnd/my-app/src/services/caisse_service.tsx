import {CoAxios} from './serveurservice';
import {accountService} from './account_service';
let getCaisse = ()=> {
    let token = accountService.token();
    const headers = { 'Authorization': 'Bearer '+token, 'Access-Control-Allow-Origin': '*'};
   
    return CoAxios.get('/Api/gestioncaisses',{headers});
}


export const caisseService ={
    getCaisse
    }