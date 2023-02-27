let http = require('http');
let url = require('url');
let fs = require('fs');
let qs = require('querystring');

http.createServer((req, res)=>{
    if(req.method == "GET"){
        // HTML FILE
        fs.readFile('./pages/home.html', (error,data)=>{
            res.writeHead(200, {'Content-Type': 'text/html'});
            res.write(data);
            res.end();
        });
    }
    else if(req.method == "POST"){
        // SAVE DATA
        let body = "";
        req.on('data', function(chunk){
            body += chunk;
        })

        req.on('end', function(chunk){
                let params = qs.parse(body);
                let person = { 
                    name: params["name"],
                    adress: params["adress"],
                    phone: params["phone"]
                };
                res.write(JSON.stringify(params))
                console.log(params)
                res.end();
        }) 
        // THANK YOU
    }


}).listen(8080);
