import React, { useCallback, useMemo, useState } from 'react';
import {accountService} from '../../services/account_service';
import {  useNavigate } from "react-router-dom";
import { useEffect} from 'react';
import { caisseService } from '../../services/caisse_service';
import { CTable,CSmartTable } from '@coreui/react-pro';
import '@coreui/coreui/dist/css/coreui.min.css'
import DatePicker from "react-datepicker";

import "react-datepicker/dist/react-datepicker.css";
import MaterialReactTable, {
  type MaterialReactTableProps,
  type MRT_Cell,
  type MRT_ColumnDef,
  type MRT_Row,
} from 'material-react-table';
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  MenuItem,
  Stack,
  TextField,
  Tooltip,
} from '@mui/material';
import { Delete, Edit } from '@mui/icons-material';

export interface CaisseDto  {
  id: number,
  billet500 : number ,
  billet200 : number,
  billet100 : number,
  billet050 : number,
  billet020 : number,
  billet010 : number,
  billet005 : number,
  billet002 : number,
  billet001 : number,
  piece50 : number,
  piece20 : number,
  piece10 :number,
  piece05 :number,
  totalBancontact : number,
  totalRetrait :number,
  nbBiere : number,
  commentaire :  string,
  dateCaisse : Date,
  societe : number,
  balance : number,
  totalCash : number
}

function GestionCaisse () {
  const [createModalOpen, setCreateModalOpen] = useState(false);
  const [caisses , SetCaisses]  = useState<CaisseDto[]>([]);
  const [validationErrors, setValidationErrors] = useState<{
    [cellId: string]: string;
  }>({});

  const handleCreateNewRow = (values: CaisseDto) => {
    caisses.push(values);

    caisseService.PostCaisse(values).then(res => {
            
          
      navigate('/admin');
  })
  .catch(error => console.log(error))
  
    
    SetCaisses([...caisses]);
    
  };

  const handleSaveRowEdits: MaterialReactTableProps<CaisseDto>['onEditingRowSave'] =
    async ({ exitEditingMode, row, values }) => {
      if (!Object.keys(validationErrors).length) {
        caisses[row.index] = values;
        //send/receive api updates here, then refetch or update local table data for re-render
        SetCaisses([...caisses]);
        exitEditingMode(); //required to exit editing mode and close modal
      }
    };
    const handleCancelRowEdits = () => {
      setValidationErrors({});
    };

    const handleDeleteRow = useCallback(
      (row: MRT_Row<CaisseDto>) => {
        if (
         !window.confirm(`Are you sure you want to delete `)         
        ) {
          return;
        }
        //send api delete request here, then refetch or update local table data for re-render
        caisses.splice(row.index, 1);
        SetCaisses([...caisses]);
      },
      [caisses],
    );
  
    const getCommonEditTextFieldProps = useCallback(
      (
        cell: MRT_Cell<CaisseDto>,
      ): MRT_ColumnDef<CaisseDto>['muiTableBodyCellEditTextFieldProps'] => {
        return {
          error: !!validationErrors[cell.id],
          helperText: validationErrors[cell.id],
          onBlur: (event) => {
            const isValid =
              cell.column.id === 'email'
                ? validateEmail(event.target.value)
                : cell.column.id === 'age'
                ? validateAge(+event.target.value)
                : validateRequired(event.target.value);
            if (!isValid) {
              //set validation error for cell if invalid
              setValidationErrors({
                ...validationErrors,
                [cell.id]: `${cell.column.columnDef.header} is required`,
              });
            } else {
              //remove validation error for cell if valid
              delete validationErrors[cell.id];
              setValidationErrors({
                ...validationErrors,
              });
            }
          },
        };
      },
      [validationErrors],
    );

    let navigate = useNavigate();
    
    const columns = useMemo<MRT_ColumnDef<CaisseDto>[]>(
      () => [
        {
          header: 'Date',
          Cell: ({ cell }) => cell.getValue<Date>().toLocaleDateString(), //transform data to readable format for cell render
          accessorFn: (row) => new Date(row.dateCaisse), //transform data before processing so sorting works
          accessorKey: 'dateCaisse',
          
          muiTableHeadCellFilterTextFieldProps: {
            type: 'date',
          },
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: 'balance',
          accessorKey: 'balance',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: 'Total cash',
          accessorKey: 'totalCash',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: 'Nombre de bière',
          accessorKey: 'nbBiere',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: 'Total Bancontact',
          accessorKey: 'totalBancontact',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: 'Total Retrait',
          accessorKey: 'totalRetrait',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: '500€',
          accessorKey: 'billet500', //using accessorKey dot notation to access nested data
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        
        {
          header: '200€',
          accessorKey: 'billet200',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 80,
        },
        {
          header: '100€',
          accessorKey: 'billet100',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '50€',
          accessorKey: 'billet050',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '20€',
          accessorKey: 'billet020',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),    
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '10€',
          accessorKey: 'billet010',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '5€',
          accessorKey: 'billet005',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '2€',
          accessorKey: 'billet002',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '1€',
          accessorKey: 'billet001',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '0,5€',
          accessorKey: 'piece50',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '0,2€',
          accessorKey: 'piece20',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '0,1€',
          accessorKey: 'piece10',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: '0,05€',
          accessorKey: 'piece05',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        {
          header: 'commentaire',
          accessorKey: 'commentaire',
          muiTableBodyCellEditTextFieldProps: ({ cell }) => ({
            ...getCommonEditTextFieldProps(cell),
          }),
          enableColumnActions :false,
          enableColumnFilters :false,
          enablePagination :false,
          enableSorting :false,
          enableBottomToolbar :false,
          enableTopToolbar :false,
          enableColumnOrdering: false,
          size: 30,
        },
        
      ],
      [],
    );

    useEffect(() => {
        caisseService.getCaisse()
        .then(res => { 
            SetCaisses( []);
            
            //SetCaisses( [...caisses, ...res.data]);
            SetCaisses( [...res.data]); 
            console.log('apres',caisses);
                  
        })
        .catch(error => console.log(error))
        
        return SetCaisses([]);
    }, []);
    console.log('toto',caisses);
    return (
      <>
      <MaterialReactTable
        displayColumnDefOptions={{
          'mrt-row-actions': {
            muiTableHeadCellProps: {
              align: 'center',
            },
            size: 120,
          },
          
        }}
        columns={columns}
        data={caisses}
        initialState={{ columnVisibility: { billet500: false, billet005: false, billet002: false, billet001: false, piece05 :false, piece20 : false, piece10 :false, piece50: false} }}
       //default
        renderTopToolbarCustomActions={() => (
          <Button
            color="secondary"
            onClick={() => setCreateModalOpen(true)}
            variant="contained"
          >
            Create New Account
          </Button>
        )}
      />
      <CreateNewAccountModal
        columns={columns}
        open={createModalOpen}
        onClose={() => setCreateModalOpen(false)}
        onSubmit={handleCreateNewRow}
        
      />
    </>
    );
}
export default GestionCaisse;
interface CreateModalProps {
  columns: MRT_ColumnDef<CaisseDto>[];
  onClose: () => void;
  onSubmit: (values: CaisseDto) => void;
  open: boolean;
}

export const CreateNewAccountModal = ({
  open,
  columns,
  onClose,
  onSubmit,
}: CreateModalProps) => {
  const [values, setValues] = useState<any>(() =>
    columns.reduce((acc, column) => {
      if(column.accessorKey =='commentaire')
        acc[column.accessorKey ?? ''] = '';
      else acc[column.accessorKey ?? ''] = 0;
      return acc;
    }, {} as any),
  );
  const handleSubmit = () => {
    //put your validation logic here
    onSubmit(values);
    onClose();
  };
  return (
    <Dialog open={open}>
      <DialogTitle textAlign="center">Create New Account</DialogTitle>
      <DialogContent>
        <form onSubmit={(e) => e.preventDefault()}>
          <Stack
            sx={{
              width: '100%',
              minWidth: { xs: '300px', sm: '360px', md: '400px' },
              gap: '1.5rem',
            }}
          >
            {columns.map((column) => {
              
              if( column.accessorKey == 'dateCaisse')
              {
                return <DatePicker selected={values['dateCaisse']?values['dateCaisse']:new Date()}  key={column.accessorKey} 
               
                name={column.accessorKey}
                dateFormat="dd-MM-yyyy"
                onChange={(e) =>{
                  console.log(values);
                  setValues({ ...values, ['dateCaisse']: e })}} />
              }
             return <TextField
                key={column.accessorKey}
                label={column.header}
                name={column.accessorKey}
                onChange={(e) =>
                  setValues({ ...values, [e.target.name]: e.target.value })
                }             
              />
              
               } )}
          </Stack>
        </form>
      </DialogContent>
      <DialogActions sx={{ p: '1.25rem' }}>
        <Button onClick={onClose}>Cancel</Button>
        <Button color="secondary" onClick={handleSubmit} variant="contained">
          Create New Account
        </Button>
      </DialogActions>
    </Dialog>
  );
};



const validateRequired = (value: string) => !!value.length;
const validateEmail = (email: string) =>
  !!email.length &&
  email
    .toLowerCase()
    .match(
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    );
const validateAge = (age: number) => age >= 18 && age <= 50;