var fs = require('fs');

var readStrream = fs.createReadStream("./public/db.json");
readStrream.setEncoding('utf-8');

var writeStream = fs.createWriteStream("./public/dbCopy.json");

readStrream.on ('data', (data)=> {
    writeStream.write(data);
})

readStrream.on('end', function() {
    console.log('stream ended');
})