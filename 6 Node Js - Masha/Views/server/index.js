const express = require('express');
const http = require('http');
const cors = require('cors');
const util = require('util');
const fs = require('fs');

const app = express();
app.use(cors());

const server = http.createServer(app);

const io = require('socket.io')(server, {
    cors: {
        origin: "http://localhost:3000"
    }
});

const dbFile = "./db/db.json";
const readFile = util.promisify(fs.readFile);

io.on('connection', async (socket)=>{
    console.log("new connection established");

    let data = JSON.parse(await fs.readFile(dbFile));
    
    socket.emit('getData', data)
    //socket.broadcast('connection', "api connected")

    socket.on('getData', (data)=>{
        console.log("getData");
    })

    socket.on('disconnect', ()=>{
        console.log("client is disconnected");
    })
    
})


server.listen(8080, ()=>{
    console.log("listening on port 8080")
})