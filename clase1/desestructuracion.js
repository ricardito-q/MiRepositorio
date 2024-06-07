const deadpool = {
    nombre: 'ricardo',
    paterno: 'quiroz',
    poder: 'guzman',
    estavivo:true,
    getNombre: function(){
        return `${this.nombre} ${this.paterno}`;
    }
}
const {nombre,paterno,poder}= deadpool;
const template  = `MI NOMBRE ES
----------======== ${nombre} ${paterno} ${poder}-------========`;
console.log('nombre:'+nombre);
console.log('paterno:'+paterno);
console.log('poder:'+poder);
console.log(template);
//const poder=deadpool.poder;
//console.log(poder);