const { GraphQLObjectType } = require('graphql');
const {CreatStock,UpdateStock,DeleteStock}=require('./type/stock/type.stock');

const MutationType = new GraphQLObjectType({
    name:'MutationType',
    description:'MutationType',
    fields:{
        createdStock:CreatStock,
        updatedStock:UpdateStock,
        deleteStock:DeleteStock
    }
})

module.exports=MutationType;