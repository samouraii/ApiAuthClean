import Login from './Login';
import Register from './register';
import Error from '../../_utils/Error';

import { Routes, Route, Link } from "react-router-dom";
function AuthRouter () {
    return (
        <Routes>
            <Route index element={<Login/>}/>
            <Route path="login" element={<Login />}/>
            <Route path="register" element={<Register />}/>
    
            <Route path="*" element={<Error />}/>
        </Routes>
    );
}
export default AuthRouter;