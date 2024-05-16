import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const routes = [
  {
    path: '/login',
    name: 'login',

    component: () => import(/* webpackChunkName: "about" */ '../auth/views/UserLogin.vue')
  },

  {
    path: '/',
    name: '/',
    component: () => import(/* webpackChunkName: "about" */ '../views/LayoutView.vue'),
    redicrect :'/home',
    
    children :[
      {
        path: '/home',
        name: '/home',

        component: () => import(/* webpackChunkName: "about" */ '../views/HomeView.vue')
      },

      {
        path: '/About',
        name: 'About',

        component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
      },
      {
        path: '/category',
        name: 'category',

        component: () => import(/* webpackChunkName: "about" */ '../views/CategoryView.vue')
      },
      {
        path: '/Addcategory',
        name: 'Addcategory',

        component: () => import("@/components/AddCategroy.vue")

      },
 ]
}

]




const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
