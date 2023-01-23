import './auth.css';
import {useState} from 'react';
import axios from 'axios';
import { Console } from 'console';
import { useNavigate } from 'react-router-dom';
import {accountService } from '../../services/account_service';
import {serveurIp} from '../../services/serveurservice';

type credential ={
    UserName : string,
    Password : string
}
function Register () {
    let navigate = useNavigate();
    const [credential , SetCredential]  = useState<credential>({
        UserName : '',
        Password :''
    });
    
    const onSubmit = (e : any) =>{
        SetCredential({
            ...credential,
            [e.target.name] : e.target.value
        });

    }
    const submit = (e :any) => {
        e.preventDefault();
        console.log(credential.UserName, credential.Password);
        axios.post(serveurIp+"/api/Auth/register", credential)
        .then(res => {
            console.log(res);
            accountService.saveToken(res.data.token);            
            navigate('/auth/login');
        })
        .catch(error => console.log(error))
    }
    return (
        <form onSubmit={submit}>
           
            <div className="group">
                <label>Identifiant</label>
                <input type="text" name="UserName" value={credential.UserName} onChange={onSubmit}/>
            </div>
            <div className="group">
                <label>Mot de passe</label>
                <input type="password" name="Password" value={credential.Password} onChange={onSubmit}/>
            </div>
            <div className="group"><button>Inscription</button></div>
        
        </form>
    );
}
export default Register;