// const num1 = Number(process.argv[2]);
// const num2 = Number(process.argv[3]);

// console.log(num1+num2)


const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

let num1 = null;
let num2 = num1;
console.log("Please enter a number: ")

rl.on('line', (line)=>{
    if(num1 == null){
        num1 = Number(line);
    }
    else if (num2 == null){
        num2 = Number(line);
        console.log(num1+num2);
    }
    else {
        rl.close();  
    }
    //rl.close();
});