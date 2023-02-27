import logo from './logo.svg';
import socketIO from 'socket.io-client';
import {useEffect} from 'react';

import './App.css';

function App() {
  useEffect(()=>{
    const socket = socketIO.connect('http://localhost:8080');

    socket.on('connection', (data)=>{
      console.log("client is connected", data);
    })

    socket.on('disconnect', ()=>{
      console.log("client is disconnected");
    })

  }, [])

  return (
    <div className="App">
      
    </div>
  );
}

export default App;
