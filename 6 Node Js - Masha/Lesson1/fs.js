var fs = require('fs');

const folder = './public';

fs.readdir(folder, (err, files) => {
    files.forEach(`${folder}/${file}`, 'utf-8'(error))
})