const colors = require('colors');
const fs = require('fs');

const creararchivo = (base = 5) => {
//  return new promise ()
let salida = '';
salida +=('======================'.red);
salida +=('||                   ||'.red);
salida +=('||    tabla del  '.red, colors.blue(base), colors.red("||"));
salida +=('||                   ||'.red);
salida +=('======================'.red);

    
    for (let i = 1; i <= 10; i++) {
        // console.log(i*base);
        salida += `${base} x ${i} =${base * i} \n`.green;

    }
    fs.writeFile(`\salida.txt`, salida, (err) => {
        if (err) throw err;
        console.log('archivo creado exitosamente');
    });
}
module.exports={
    creararchivo
}