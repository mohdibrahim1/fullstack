const express = require('express')
const {port}= require('./env')
const {ApolloServer}=require('apollo-server-express')
const Schema=require('./schema');
const app = express();

const server = new ApolloServer({
    schema:Schema
})

server.start().then(res=>{
    server.applyMiddleware({app});
    app.listen(port,()=>{
        console.log("server runing at this port",port);
    })
})


app.get('/home',(req,res)=>{

    res.send("welcome to gapi world");
}
)