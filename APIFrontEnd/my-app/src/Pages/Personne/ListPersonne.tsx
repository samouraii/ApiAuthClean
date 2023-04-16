
import {useState} from 'react';
import { useNavigate } from 'react-router-dom';

import { useEffect } from 'react';
import { personneService } from '../../services/personne_service';
import { CSmartTable } from '@coreui/react-pro';
import '@coreui/coreui/dist/css/coreui.min.css'
type PersonneDto ={
    idPersonne : Number,
    name : string,
    firstName : string
} 
function ListPersonne () {
    let navigate = useNavigate();
    const [personnes , SetPersonnes]  = useState<PersonneDto[]>([]);
    
    useEffect(() => {
        personneService.getPersonne()
        .then(res => { 
            SetPersonnes( []);
            const Per = res.data
            console.log('avant',Per);
            SetPersonnes( [...personnes, ...Per]); 
                  
        })
        .catch(error => console.log(error))
        
        return SetPersonnes([]);
    }, []);

    const columns = [
      {
        key: 'idPersonne',
        label: '#',
        _props: { scope: 'col' },
      },
     
      {
        key: 'name',
        label: 'Nom',
        _props: { scope: 'col' },
      },
      {
        key: 'firstName',
        label: 'Prenom',
        _props: { scope: 'col' },
      },
    ]

   console.log('tot',personnes)
    if(personnes != undefined && personnes.length > 0)
    {
    return (
        
        <div className="container">
       <CSmartTable activePage={3}
    cleaner
    clickableRows columns={columns} items={personnes}  columnFilter
    columnSorter
    footer
    itemsPerPageSelect
    itemsPerPage={5}
    pagination 
    selectable
    sorterValue={{ column: 'name', state: 'asc' }}
    tableFilter
    tableHeadProps={{
      color: 'danger',
    }}
    tableProps={{
      striped: true,
      hover: true,
    }}
    
    />
   </div>
    );
    }
    else{
        return(<div>No item</div>)
    }
}
export default ListPersonne;