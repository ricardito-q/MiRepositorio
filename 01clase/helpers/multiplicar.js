const { rejects } = require('assert');
const colors = require('colors');
const fs = require('fs');
const { resolve } = require('path');

const creararchivo = (base = 5) => {
//  return new promise ()

let salida = '';
salida +='======================'+ '\n';
salida +='||                   ||'+ '\n';
salida += '||    tabla del ' + base.toString().padEnd(5) + '||' + '\n';
salida +='||                   ||'+ '\n';
salida +='======================'+ '\n';

    
    for (let i = 1; i <= 10; i++) {
        // console.log(i*base);
        salida += `${base} x ${i} =${base * i} \n`.green;

    }
    fs.writeFile(`salida/salida.txt`, salida, (err) => {
        if (err) throw err;
        console.log('archivo creado exitosamente');
    });

}
module.exports={
    creararchivo
}