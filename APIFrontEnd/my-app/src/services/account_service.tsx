import BaseAxios from './serveurservice';
import jwt_decode from "jwt-decode";
import * as moment from 'moment';
import { type } from '@testing-library/user-event/dist/type';
import { getRoles } from '@testing-library/react';
import { decode } from 'punycode';
import { date } from 'yup';

let login = (credential : any)=> {
    return BaseAxios.post('/Api/Auth/login',credential);
}
 let saveToken = (token :string) => {
    localStorage.setItem('Token', token);
} 

 let logout = () => {
    localStorage.removeItem('Token');    
}

let isLoggin = () => {
    let token = localStorage.getItem('Token');
    if(token){
             
        const jwtToken = JSON.parse(atob(token.split('.')[1]));
        const expires = jwtToken.exp * 1000 < Date.now()
       
    
        if( expires ) logout();
    }
   
    return !!token;
}

let getRole = () => {
    var token = localStorage.getItem('Token') ?? "";    
    //if (!!token) return [];
    var decoded = jwt_decode<token>(token);
    var role = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'].split(',');
    return role;    
}
let isRole =(role :any) =>{
    
    var roles = getRole() ;

    var t = roles.find(x => role?.includes(x));
    console.log("tt",role);
    return !!roles.find(x => role?.includes(x))
}
type token = {
    'http:\/\/schemas.microsoft.com/ws/2008/06/identity/claims/role':string,
    'http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration':string
}

export const accountService ={
login,saveToken, logout, isLoggin, isRole
}