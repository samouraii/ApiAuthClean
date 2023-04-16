import './auth.css';
import {FormEventHandler, FormEvent, useState, ChangeEventHandler, ChangeEvent} from 'react';
import { useNavigate } from 'react-router-dom';
import {accountService } from '../../services/account_service';
import { useEffect } from 'react';
import bg from "./texture-mur-stuc-bleu-marine-relief-decoratif-abstrait-grunge-fond-colore-rugueux-grand-angle_1258-28311.jpg";

type credential ={
    UserName : string,
    Password : string
}

function Login () {
    let navigate = useNavigate();
    const [credential , SetCredential]  = useState<credential>({
        UserName : '',
        Password :''
    });
    
    const onChange: ChangeEventHandler<HTMLInputElement> = (e) =>{
        SetCredential({
            ...credential,
            [e.target.name] : e.target.value
        });

    }
    const submit: FormEventHandler<HTMLFormElement>  = (e: FormEvent) => {
        e.preventDefault();
        console.log(credential.UserName, credential.Password);
        accountService.login(credential)
        .then(res => {
            
            accountService.saveToken(res.data.token); 
           
            navigate('/admin');
        })
        .catch(error => console.log(error))
    }

   
        useEffect(() => {
            document.body.style.backgroundImage = 'url('+bg+')';
            document.body.style.backgroundRepeat = "no-repeat"
            document.body.style.backgroundColor = '#0000ff';
            document.body.style.backgroundSize = 'cover';
            return () => {
                document.body.style.backgroundImage ="";
                document.body.style.backgroundColor = "";
                document.body.style.backgroundSize = '';
                document.body.style.backgroundRepeat = "";

            }
        }, [])
    return (
        <div id="all">
        <div id="container">
            
        <form onSubmit={submit}>
        <div className="group">
                <h2>Connexion</h2>
               
            </div>
            <div className="group">
                <label>Identifiant</label>
                <input type="text" name="UserName" value={credential.UserName} onChange={onChange}/>
            </div>
            <div className="group">
                <label>Mot de passe</label>
                <input type="password" name="Password" value={credential.Password} onChange={onChange}/>
            </div>
            <div className="group"><button>Se connecter</button></div>
        
        </form>
        </div>
        </div>
    );
}
export default Login;