let http = require('http');

http.createServer((req, res)=>{

    var message = "<h1>hey hey hey</h1>";

    // add headers
    res.writeHead(200, {
        'Content-Type': 'text/html'
    });

    // add data
    res.write(message);

    // send response
    res.end();

}).listen(8080)