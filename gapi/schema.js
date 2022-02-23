const MutationType = require('./mutation')
const QueryType=require('./query')

const { GraphQLSchema } = require("graphql");

const Schema = new GraphQLSchema({
    query:QueryType,
    mutation:MutationType
})


module.exports =Schema;