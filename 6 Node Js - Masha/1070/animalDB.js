let fs = require('fs');
let readline = require('readline')

let path = "./public/animals.json";
let path2 = "./public/animals2.json";

let rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

let readStream = fs.createReadStream(path);


console.log('Enter animal name:')
rl.on('line', (animalname)=>{

    let arr = [];
    readStream.on('data', (data)=>{
        
        let writeStream = fs.createWriteStream(path);
        arr = JSON.parse(data);

        let biggestID = 1;
        // create new id
        arr.forEach(element => {
            if(element.id > biggestID){
                biggestID = element.id;
            }
        });
    
        const newAnimal = {
            id: biggestID+1,
            name: animalname
        }
    
        // push to db
        arr.push(newAnimal);
    
        // write to stream
        writeStream.write(JSON.stringify(arr));
    
    })
})