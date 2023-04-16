import {accountService} from '../../services/account_service';
import {  useNavigate } from "react-router-dom";
import {useState, useEffect} from 'react';
import { caisseService } from '../../services/caisse_service';
import { CTable,CSmartTable } from '@coreui/react-pro';
import '@coreui/coreui/dist/css/coreui.min.css'

 type CaisseDto = {
    billet500 : number,
    billet200 : number,
    billet100 : number,
    billet050 : number,
    billet020 : number,
    billet010 : number,
    billet005 : number,
    billet002 : number,
    billet001 : number,
    
   
    
}
const columns = [
    {
      key: 'id',
      label: '#',
      _props: { scope: 'col' },
    },
   
    {
      key: 'billet500',
      label: '500',
      _props: { scope: 'col' },
    },
    {
      key: 'billet200',
      label: '200',
      _props: { scope: 'col' },
    },
    {key: 'billet100',
    label: '100',
    _props: { scope: 'col' },
  },
  {key: 'billet050',
    label: '50',
    _props: { scope: 'col' },
  },
  {key: 'billet020',
    label: '20',
    _props: { scope: 'col' },
  },
  {key: 'billet010',
    label: '10',
    _props: { scope: 'col' },
  },
  {key: 'billet005',
    label: '5',
    _props: { scope: 'col' },
  },
  {key: 'billet002',
    label: '2',
    _props: { scope: 'col' },
  },
  {key: 'billet001',
    label: '1',
    _props: { scope: 'col' },
  },
  ]

function GestionCaisse () {
    let navigate = useNavigate();
    const [caisses , SetCaisses]  = useState<CaisseDto[]>([]);

    useEffect(() => {
        caisseService.getCaisse()
        .then(res => { 
            SetCaisses( []);
            
            SetCaisses( [...caisses, ...res.data]); 
            console.log('apres',caisses);
                  
        })
        .catch(error => console.log(error))
        
        return SetCaisses([]);
    }, []);
    console.log('toto',caisses);
    return (
        <div>
            <h1> Gestion de caisse </h1>
            <h2> Caisse Précédente</h2>
            <CTable columns={columns} items={caisses} />
        </div>
    );
}
export default GestionCaisse;