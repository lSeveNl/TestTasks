import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import LoginComponent from '../components/LoginComponent.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: LoginComponent
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
