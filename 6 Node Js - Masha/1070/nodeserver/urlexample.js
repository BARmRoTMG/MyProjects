let http = require('http');
let url = require('url');
let fs = require('fs');

http.createServer((req, res)=>{

    const link = url.parse(req.url, true);
    let params = link.query;

    if(!params.name && !params.adress && !params.phone){
        res.end();
    }

    let person = { 
        name: params.name,
        adress: params.adress,
        phone: params.phone
    };
    console.log(person);

    fs.readFile('./db/db.json', (error,data)=>{
        const db = JSON.parse(data);
        db.push(person);

        fs.writeFile('./db/db.json', JSON.stringify(db), (error)=>null);

        res.writeHead(200, {'Content-Type': 'application/json'});
        res.write(JSON.stringify(db));
        res.end();
    })

}).listen(8080);



// http.createServer((req, res)=> {
//     res.writeHead(200, {'Content-Type': 'text/html'});
//     res.write('<h1>Http Server is working</h1>');
   
//     let link = url.parse(req.url, true)
//     let params = link.query;
//     console.log(link.host, link.href, link.path, link.pathname, link.port);

//     let method = req.method;
//     res.write(`<h2>url: ${url} | method: ${method} </h2>`);
//     res.write(`<h2>city: ${params.city} | weather: ${params.weather} </h2>`);


//     res.end();
// }).listen(8080)