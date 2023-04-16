import BaseAxios from './serveurservice';

let getPersonne = ()=> {
   
    return BaseAxios.get('/Api/personne' );
}


export const personneService ={
    getPersonne
    }