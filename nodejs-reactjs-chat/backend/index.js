const express = require("express"); //runs http server
const cors = require("cors"); //call server from any other origin
const axios = require("axios");

const app = express();
app.use(express.json());
app.use(cors({ origin: true }));

app.post("/authenticate", async (req, res) => {
    const { username } = req.body;

    try {
        const r = await axios.put(
            'https://api.chatengine.io/users/',
            { username: username, secret: username, first_name: username},
            { headers: {"private-key": "c6623b83-d897-476c-b4cb-9330ff928268"}}
        )
        return res.status(r.status).json(r.data); //return the call response and the data
    } catch (e) {
        return res.status(e.response.status).json(e.response.data);
    }
});

// vvv On port 3001!
app.listen(3001);