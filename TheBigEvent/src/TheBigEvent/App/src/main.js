import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import AuthService from './services/auth.js'


// La Base
import Home from './App.vue'



// Les pages avant-connexion
import index from './Avco/av.vue'
import Accueil from './Avco/accueil.vue'
import Partenaire from './Avco/Partenaire.vue'
import Galerie from './Avco/Galerie.vue'

// Client
import Client from './Client/Client.vue'

// Fournisseurs
import Provider from './Provider/Provider.vue'

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes: [
   { path: '/', component: Home, redirect: 'home', children:[
      { path : '/accueil', component: index, redirect: 'home' ,children :[
        { path : '/home', component: Accueil },
        { path: '/Partner', component: Partenaire},
        { path: '/galerie', component: Galerie}
      ]}
   ]},
   { path: '/client', component: Client },
   { path: '/pro', component: Provider },
   { path: '*', redirect:'/'}
  ]
})

AuthService.allowedOrigins = ['http://localhost:5000'];

AuthService.logoutEndpoint = '/Account/LogOff';


AuthService.providers = {
  'Base': {
    endpoint: '/Acount/Conexion' 
  },
  'Base1': {
    endpoint: '/Acount/Login' 
  }
};

AuthService.appRedirect = () => router.replace('/');



/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  render: h => h(App),
  components: { App }
})
