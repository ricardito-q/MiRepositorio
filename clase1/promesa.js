const empleados = [
    {
        id:1,
        nombre: 'ricardo'
    },
    {
        id:2,
        nombre: 'grabriel'
    },
    {
        id:3,
        nombre: 'luisa'
    },
];

const getEmpleado=(id)=> {
    return new Promise((resolve, reject)=>{
        const empleado = empleados.find(e=>e.id === id)?.nombre;
            (empleado)
            ?resolve(empleado)
            :reject(`no existe empleado con id ${id}`)
        
    });
}
const id=3;
getEmpleado(id)
.then(empleado => console.log(empleado));
// .catch(err => console.log(err));


