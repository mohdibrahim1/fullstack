const { GraphQLObjectType } = require('graphql')
const {StockList,StockById}=require('./type/stock/type.stock')

const QueryType = new GraphQLObjectType({
    name:'QueryType',
    description:'QueryType',
    fields:{
        stockList:StockList,
        stockById:StockById
    }
})

module.exports =QueryType;