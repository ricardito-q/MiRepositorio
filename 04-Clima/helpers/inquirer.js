const inquirer = require('inquirer');
require('colors');

const preguntas = [
    {
        type: 'list',
        name: 'opcion',
        message: 'Que desea hacer?',
        choices: [
            { value: 1, name: `${'1.'.green} Buscar ciudad` },
            { value: 2, name: `${'2.'.green} Historial` },
            { value: 0, name: `${'0.'.green} Salir` },
        ]
    }
];

const inquirerMenu = async () => {
    console.clear();
    console.log('=====================\n'.green);
    console.log('Seleccione una opcion\n'.white);
    console.log('=====================\n'.green);

    const { opcion } = await inquirer.prompt(preguntas);
    return opcion;
}

const pausa = async () => {
    const question = [
        {
            type: 'input',
            name: 'enter',
            message: 'Presione enter para continuar'
        }
    ];
    console.log('\n');
    await inquirer.prompt(question);
}

const leerInput = async (message)=>{
    const question = [
        {
            type: 'input',
            name: 'desc',
            message,
            validate(value){
                if(value.leerInput ===0){
                    return 'Por favor ingrese una ciudad';
                }
                return true;
            }
        }
    ];
    const {desc} = await inquirer.prompt(question);
    return desc;
}

const listarLugares = async (lugares = []) => {
    const choices = lugares.map((lugar, i) => {
        const idx = `${i+1}.`.green;
        return {
            value: lugar.id,
            name: `${idx} ${lugar.nombre + lugar.lng + lugar.lat}`
        }
    });
    choices.unshift({
        value: '0',
        name: '0.'.green + ' Cancelar'
    });
    const preguntas = [
    {
        type: 'list',
        name: 'id',
        message: 'Seleccione lugar:',
        choices
    }
    ]
    const { id } = await inquirer.prompt(preguntas);
    return id;
}

module.exports = {
    inquirerMenu, pausa
    ,leerInput,listarLugares
}