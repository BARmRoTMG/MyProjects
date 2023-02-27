var fs = require('fs');

const folder = "./public";

fs.readdir(folder, (err, files)=>{
    files.forEach((file)=>{
        
        fs.readFile(`${folder}/${file}`,'utf-8', (error, data)=>{
            console.log(data);
        });
        
    })
})