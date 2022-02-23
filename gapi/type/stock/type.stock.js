const axios = require('axios');
const { ApiUrl } = require('../../env')
const { GraphQLObjectType, GraphQLInt, GraphQLString, GraphQLInputObjectType, GraphQLList, GraphQLNonNull, graphql } = require('graphql')

const Stock = new GraphQLObjectType({
    name: 'Stock',
    description: 'Stock',
    fields: {
        id: { type: GraphQLInt },
        name: { type: GraphQLString },
        start: { type: GraphQLInt },
        end: { type: GraphQLInt },
        yearHigh: { type: GraphQLInt },
        yearLow: { type: GraphQLInt }
    }
})

const StockCreate = new GraphQLInputObjectType({
    name: 'StockCreate',
    description: 'StockCreate',
    fields: {
        id: { type: GraphQLInt },
        name: { type: GraphQLString },
        start: { type: GraphQLInt },
        end: { type: GraphQLInt },
        yearHigh: { type: GraphQLInt },
        yearLow: { type: GraphQLInt }
    }
})

const Query = {
    type: new GraphQLList(Stock),
    resolve: async () => {
        console.log("Hit")
        let data = await axios.get(ApiUrl).then(res => {
            console.log(res.data);
            return res.data;
        });
        return data;
    }
}

const QueryById = {
    type: Stock,
    args: {
        id: { type: GraphQLInt }
    },
    resolve: (parents, args) => {
        return axios.get(`${ApiUrl}/${args.id}`).then(res => res.data)
            .catch(err => err);
    }
}

const Mutation = {
    type: Stock,
    args: {
        input: { type: new GraphQLNonNull(StockCreate) }

    },
    resolve: (parents, args) => {
        console.log("hit post")
        let store = axios.post(ApiUrl, args.input).then(res => {
            store = res.data;
        })
            .catch(err => err)
        return { id: store.id }
    }
}

const MutationUpdate = {
    type: Stock,
    args: {
        input: { type: new GraphQLNonNull(StockCreate) }
    },
    resolve: (parents, args) => {
        console.log("updated hit")
        let store = axios.put(ApiUrl, args.input).then(res => {
            store = res.data;
        })
            .catch(err => err)
        return { id: args.input.id }
    }
}

const MutationDelete = {
    type: Stock,
    args: {
        id: { type: new GraphQLNonNull(GraphQLInt) }
    },
    resolve: (parents, args) => {
        console.log(args.id);
        let store = axios.delete(`${ApiUrl}/${args.id}`)
            .then(res => {
              return  store = res.data;
            }).catch(err => err)
        return { id: args.id }
    }
}

module.exports = {
    StockList: Query,
    StockById: QueryById,
    CreatStock: Mutation,
    UpdateStock: MutationUpdate,
    DeleteStock: MutationDelete
}