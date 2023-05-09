import {accountService} from '../../services/account_service';
import {  useNavigate } from "react-router-dom";
function Admin () {
    let navigate = useNavigate();
    const logout =() =>{
        accountService.logout();
        navigate('/');
    }
    return (
        <div>
            <h1> Portail PAGE en construction </h1>
            <button onClick={logout}>Logout</button>
        </div>
    );
}
export default Admin;