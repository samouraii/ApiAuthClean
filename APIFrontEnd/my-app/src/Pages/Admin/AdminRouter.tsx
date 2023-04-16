import Admin from './Admin';
import Error from '../../_utils/Error';
import { Routes, Route, Link } from "react-router-dom";
import GestionCaisse from '../../components/GestionCaisse/GestionCaisse';
function AdminRouter () {
    return (
        <Routes>
            <Route index element={<Admin/>}/>
            <Route path="Board" element={<Admin />}/>
            <Route path="caisse" element={<GestionCaisse />} />
            <Route path="*" element={<Error />}/>
        </Routes>
    );
}
export default AdminRouter;