import Vue from 'vue'
import Vuex from 'vuex'
import axios from "axios";

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    customers: []
  },
  mutations: {
    setCustomers(state, customers) {
      state.customers = customers;
    },
    appendCustomer(state, customer) {
      state.customers.push(customer);
    }
  },
  actions: {
    load(context) {
      return new Promise(( res, rej ) => {
        axios.get("/api/customers")
          .then(result => {
            context.commit("setCustomers", result.data);
            res();
          })
          .catch(() => rej());
      });
    },
    addCustomer(context, customer) {
      return new Promise((res, rej) => {
        axios.post("/api/customers", customer)
          .then(result => {
            context.commit("appendCustomer", result.data);
            res();
          })
          .catch(() => rej());
      });
    }
  }
})
