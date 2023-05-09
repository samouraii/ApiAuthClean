import {CoAxios} from './serveurservice';
import BaseAxios from './serveurservice';
import {accountService} from './account_service';
import {CaisseDto} from '../components/GestionCaisse/GestionCaisse'

let getCaisse = ()=> {
    let token = accountService.token();
    const headers = { 'Authorization': 'Bearer '+token, 'Access-Control-Allow-Origin': '*'};
   
    return CoAxios.get('/Api/gestioncaisses',{headers});
}
let PostCaisse = (caisses : any)=> {
    let token = accountService.token();
    const headers = { 'Authorization': 'Bearer '+token, 'Access-Control-Allow-Origin': '*', 'Content-Type' : 'application/json'};
   caisses.societe = "toto"
    console.log('caisse', caisses);
    return BaseAxios.post('/Api/gestioncaisses', {caisses}, {headers} );
}


export const caisseService ={
    getCaisse,PostCaisse
    }