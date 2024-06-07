const getUsuarioByID = (id, callback)=> {
    const user={
        id,
        nombre: 'ricardo'
    }
    setTimeout(()=>{
        callback(user)
    }, 3000)
}
getUsuarioByID(10, (usuario)=>{
    console.log(usuario.id);
    console.log(usuario.nombre.toUpperCase());
});