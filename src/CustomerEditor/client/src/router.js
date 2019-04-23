import Vue from 'vue'
import Router from 'vue-router'
import CustomerList from './views/CustomerList.vue'
import CustomerEditor from './views/CustomerEditor.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'customer-list',
      component: CustomerList
    },
    {
      path: '/newCustomer',
      name: 'customer',
      component: CustomerEditor
    }
  ]
})
