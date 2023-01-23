import './auth.css';
import {useState} from 'react';
import { useNavigate } from 'react-router-dom';
import {accountService } from '../../services/account_service';
import { useEffect } from 'react';

type PersonneDto ={
    UserName : string,
    Password : string
}

function Personne () {
    let navigate = useNavigate();
    const [credential , SetCredential]  = useState<PersonneDto>({
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
        accountService.login(credential)
        .then(res => {
            
            accountService.saveToken(res.data.token); 
           
            navigate('/admin');
        })
        .catch(error => console.log(error))
    }

   
 
    return (
        <div id="all">
        <div id="container">
            
        <form onSubmit={submit}>
        <div className="group">
                <h2>Connexion</h2>
               
            </div>
            <div className="group">
                <label>Identifiant</label>
                <input type="text" name="UserName" value={credential.UserName} onChange={onSubmit}/>
            </div>
            <div className="group">
                <label>Mot de passe</label>
                <input type="password" name="Password" value={credential.Password} onChange={onSubmit}/>
            </div>
            <div className="group"><button>Se connecter</button></div>
        
        </form>
        </div>
        </div>
    );
}
export default Personne;