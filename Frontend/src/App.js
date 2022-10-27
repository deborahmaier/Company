import React, {
  useState,
  useMemo,
  useCallback,
  useEffect,
} from 'react';

import {
  Delete as DeleteIcon,
  Edit as EditIcon,
  Download as DownloadIcon,
} from '@mui/icons-material';

import {
  Button,
  IconButton,
  Dialog,
  DialogTitle,
  TextField,
} from '@mui/material'

import axios from 'axios';

import {
  Container,
  TableWrapper,
  TableHeader,
  StyledDatagrid,
  ActionCellContainer,
  DialogContent,
} from './styles';

const API_URL = 'https://localhost:7243/api/personnel';

const ActionsCell = ({
  onUpdate,
  onDelete,
  onDownload,
}) => (
  <ActionCellContainer>
    <IconButton onClick={onUpdate}>
      <EditIcon/>
    </IconButton>
    <IconButton onClick={onDelete}>
      <DeleteIcon/>
    </IconButton>
    <IconButton onClick={onDownload}>
      <DownloadIcon />
    </IconButton>
  </ActionCellContainer>
);

function App() {
  // Table row states
  const [rows, setRows] = useState([]);
  const [selectedEmployee, setSelectedEmployee] = useState(null);

  // Modal open states
  const [openAddModal, setOpenAddModal] = useState(false);
  const [openDeleteModal, setOpenDeleteModal] = useState(false);

  // Employee field states
  const [Name, setName] = useState('');
  const [Surname, setSurname] = useState('');
  const [Birthdate, setBirthdate] = useState('');
  const [Adress, setAdress] = useState('');
  const [Department, setDepartment] = useState('');
  const [JoinedDate, setJoinedDate] = useState('');
  const [WorkingHours, setWorkingHours] = useState('');
  const [ZipCode, setZipCode] = useState('');
  const [Salaries, setSalaries] = useState([]);

  const [inputSalary, setInputSalary] = useState('');

  const onAdd = useCallback(async () => {
    const requestBody = {
      Name,
      Surname,
      Birthdate,
      Adress,
      Department,
      JoinedDate,
      WorkHours: WorkingHours,
      ZipCode,
      Salaries: [inputSalary],
    };
    const response = await axios.post(API_URL, requestBody);
    console.log(response);
  }, [
    Name,
    Surname,
    Birthdate,
    Adress,
    Department,
    JoinedDate,
    WorkingHours,
    ZipCode,
    inputSalary,
  ]);

  const onUpdate = useCallback(() => {
    console.log('Update', selectedEmployee);
  }, [
    selectedEmployee,
  ]);

  const onDelete = useCallback(async () => {
    const response = await axios.delete(`${API_URL}/${selectedEmployee.PersonnelId}`);
    console.log(response);
  }, [
    selectedEmployee,
  ]);

  const onDownload = useCallback((id) => {
    console.log('Download', id);
  }, []);

  const columns = useMemo(() => ([
    {
      field: 'PersonnelId',
      headerName: 'ID',
      flex: 2,
    },
    {
      field: 'Name',
      headerName: 'First name',
      flex: 4,
    },
    {
      field: 'Surname',
      headerName: 'Last name',
      flex: 4,
    },
    {
      field: 'action',
      headerName: 'Actions',
      disableColumnMenu: true,
      hideSortIcons: true,
      disableReorder: true,
      flex: 4,
      renderCell: ({ row }) => (
        <ActionsCell
          row={row}
          onUpdate={() => {
            setSelectedEmployee(row);
            setOpenAddModal(true);
          }}
          onDelete={() => {
            setSelectedEmployee(row);
            setOpenDeleteModal(true);
          }}
          onDownload={() => onDownload(row.id)}
        />
      ),
    },
  ]), [
    onDownload,
  ]);

  useEffect(() => {
    const init = async () => {
      const response = await axios.get(API_URL);
      const { data } = response;
      console.log(data);
      setRows(data);
    }
    init();
  }, []);

  useEffect(() => {
    const {
      Name = '',
      Surname = '',
      Birthdate = '',
      Adress = '',
      Department = '',
      JoinedDate = '',
      Salaries = [],
      WorkingHours = '',
      ZipCode = '',
    } = selectedEmployee || {};
    setName(Name);
    setSurname(Surname);
    setBirthdate(Birthdate);
    setAdress(Adress);
    setDepartment(Department);
    setJoinedDate(JoinedDate);
    setWorkingHours(WorkingHours);
    setZipCode(ZipCode);
    setSalaries(Salaries);

    setInputSalary(Salaries[Salaries.length]);
  }, [selectedEmployee]);

  const addModalTitle = selectedEmployee ? 'Update employee' : 'Add employee';
  const addModalHandler = selectedEmployee ? onUpdate : onAdd;

  return (
    <Container>
      <TableWrapper>
        <TableHeader>
          <h3>Employees</h3>
          <Button
            variant='contained'
            onClick={() => setOpenAddModal(true)}
          >
            Add Employee
          </Button>
        </TableHeader>
        <StyledDatagrid
          rows={rows}
          columns={columns}
          rowHeight={50}
          getRowId={(row) => row.PersonnelId}
          disableSelectionOnClick
        />
      </TableWrapper>
      <Dialog
        open={openAddModal}
        onClose={() => {
          setOpenAddModal(false);
          setSelectedEmployee(null);
        }}
      >
        <DialogTitle>{addModalTitle}</DialogTitle>
        <DialogContent>
          <TextField
            value={Name}
            onChange={(e) => setName(e.target.value)}
            label='First Name'
          />
          <TextField
            value={Surname}
            onChange={(e) => setSurname(e.target.value)}
            label='Last Name'
          />
          <TextField
            value={Birthdate}
            onChange={(e) => setBirthdate(e.target.value)}
            label='Birth Date'
          />
          <TextField
            value={Adress}
            onChange={(e) => setAdress(e.target.value)}
            label='Address'
          />
          <TextField
            value={Department}
            onChange={(e) => setDepartment(e.target.value)}
            label='Department'
          />
          <TextField
            value={JoinedDate}
            onChange={(e) => setJoinedDate(e.target.value)}
            label='Joined Date'
          />
          <TextField
            value={WorkingHours}
            onChange={(e) => setWorkingHours(e.target.value)}
            label='Work Hours'
          />
          <TextField
            value={ZipCode}
            onChange={(e) => setZipCode(e.target.value)}
            label='Zip Code'
          />
          <TextField
            value={inputSalary}
            onChange={(e) => setInputSalary(e.target.value)}
            label='Gross Salary'
          />
          <Button
            variant='contained'
            onClick={addModalHandler}
          >
            Save
          </Button>
        </DialogContent>
      </Dialog>
      <Dialog
        open={openDeleteModal}
        onClose={() => {
          setOpenDeleteModal(false);
          setSelectedEmployee(null);
        }}
      >
        <DialogTitle>Delete Employee</DialogTitle>
        <DialogContent>
          <Button
            variant='contained'
            onClick={onDelete}
          >
            Confirm
          </Button>
          <Button
            variant='contained'
            onClick={() => {
              setOpenDeleteModal(false);
              setSelectedEmployee(null);
            }}
          >
            Cancel
          </Button>
        </DialogContent>
      </Dialog>
    </Container>
  );
}

export default App;
