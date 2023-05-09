import { Link } from "react-router-dom";
import {accountService} from "../services/account_service"

import {  useNavigate } from "react-router-dom";
function Nav() {

   let navigate = useNavigate();
   const logout =() =>{
       accountService.logout();
       navigate('/');
   }
    return (
      <>
        
        <nav className="navbar navbar-expand-lg navigationcolor">
         <div className="container">
            <a className="navbar-brand" href="#">Mon Portail</a>
            <button className="navbar-toggler Togglecolor" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarNavDropdown">
               {accountService.isLoggin() ?(
                  <>
            <ul className="navbar-nav mr-auto">
               <li className="nav-item active">
                  <a className="nav-link" href="#">Home <span className="sr-only">(current)</span></a>
               </li>
               { accountService.isRole('GestionCaisse') ? (
               <li className="nav-item">
                  <a className="nav-link" href="/admin/caisse">Gestion caisse</a>
               </li>
               ):<></>}
               </ul>
               <ul className="navbar-nav">
               <li className="nav-item dropdown">
                  <a className="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                 { accountService.nameUser()}
                  </a>
                  <div className="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                 
                  <a className="dropdown-item" href="" onClick={logout}>Logout</a>
                 
                  </div>
               </li>
            </ul>
            </>
               ):(
                  <>
               <ul className="navbar-nav mr-auto">
                  
               </ul>
               <ul className="navbar-nav">
               <li className="nav-item">
                  <a className="nav-link" href="/auth/login">Login</a>
               </li>
                  </ul>
               </>
                  )
            }
               
            </div>
         </div>
       </nav>
      </>
    );
  }

  export default Nav;