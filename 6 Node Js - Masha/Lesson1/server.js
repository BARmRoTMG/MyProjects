let http = require('http');
let url = require('url');

http.createServer((req, res) => {
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write('<h1>Http server is working!</h1>');

    let link = url.parse(req.url, true);
    let params = link.query;
    console.log(link.host, link.href, link.path, link.pathname, link.port);

    let method = req.method;
    res.write()
}
)