var fs = require('fs');

var readStream = fs.createReadStream("./public/db.json");
readStream.setEncoding('utf-8');

var writeStram = fs.createWriteStream("./public/dbcopy.json");

readStream.on('data', (data)=>{
    // create new obj
    const db = JSON.parse(data);
    db.projects.push({id: 3, name: "Node"});

    writeStram.write(JSON.stringify(db));
})

readStream.on('end', function(){
    console.log('stream ended');
})