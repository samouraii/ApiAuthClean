
import {useState} from 'react';
import { useNavigate } from 'react-router-dom';

import { useEffect } from 'react';
import { personneService } from '../../services/personne_service';

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


   console.log('tot',personnes)
    if(personnes != undefined && personnes.length > 0)
    {
    return (
        
        <div id="all">
        <div className="container">
            <h1> List des personnes</h1>
        <table className='events-table'>
        <thead>
        <tr >
            <th className='event-date'>Prénom</th>
            <th className='event-time'>Nom</th>
            <th className='event-description'>Action</th>
        </tr>
        </thead>
        <tbody>
       {
       
        personnes.map(item =>
        {
            ;
            return(
                <tr key={item.idPersonne.toString()} >
                    
                   <td  data-title="Nom">  {item.firstName}</td>
                   <td data-title="Nationalité"> {item.name}</td>
                   <td  data-title="Date création">{item.idPersonne.toString()}</td>
                </tr>
            )
        } )
        
       }
       </tbody>
       </table>
        </div>
        </div>
    );
    }
    else{
        return(<div>No item</div>)
    }
}
export default ListPersonne;