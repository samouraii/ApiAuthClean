import Admin from './Admin';
import Error from '../../_utils/Error';
import { Routes, Route, Link } from "react-router-dom";
function AdminRouter () {
    return (
        <Routes>
            <Route index element={<Admin/>}/>
            <Route path="Board" element={<Admin />}/>
            <Route path="*" element={<Error />}/>
        </Routes>
    );
}
export default AdminRouter;