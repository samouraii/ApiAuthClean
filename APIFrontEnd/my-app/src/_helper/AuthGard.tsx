import { Navigate } from "react-router-dom";
import {accountService} from "../services/account_service";

type gward ={
    children : any,
    roles : string[]
}

function AuthGard ({children, roles }  :gward) {
    let connecter = accountService.isLoggin();
    console.log('getrole',roles );
    if (!connecter ) return <Navigate to="/auth/login"></Navigate>
    if (roles.length >0 && !accountService.isRole( roles)) return <Navigate to="/auth/login"></Navigate>
    return children;
    
}
export default AuthGard;