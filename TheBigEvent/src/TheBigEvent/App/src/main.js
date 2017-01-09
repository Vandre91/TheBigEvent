import 'babel-polyfill'
import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import AuthService from './services/auth.js'

// La Base
import Home from './App.vue'
import Logout from './logout.vue'

// Les pages avant-connexion
import index from './Avco/av.vue'
import Accueil from './Avco/accueil.vue'
import Partenaire from './Avco/Partenaire.vue'
import Galerie from './Avco/Galerie.vue'

// Client
import Client from './Client/Client.vue'
import Profil from  './Client/Profil.vue'
import Events from  './Client/Event.vue'
import Conversation from './Client/Conversation.vue'
import Board from './Client/board.vue'

// Fournisseurs
import Provider from './Provider/Provider.vue'
Vue.use(VueRouter);

function requireAuth (to, from, next)  {
  console.log("require auth");
  if (!AuthService.isConnected) {
    console.log("vous n'etes pas connecter");
    next({
      path: '/',
      query: { redirect: to.fullPath }
    });
    return; 
  }
  if (AuthService.isConnected) {
    next();
  }
}

const router = new VueRouter({
  mode: 'history',
  routes: [
    { path: '/', component: Home, redirect: 'home', children:[
        { path : '/accueil', component: index, redirect: 'home' ,children :[
          { path : '/home', component: Accueil },
          { path: '/Partner', component: Partenaire},
          { path: '/galerie', component: Galerie}
        ]},
        { path: '/client', component: Client, redirect: "/Client/board", beforeEnter: requireAuth, children:[
              { path : '/Client/board', component: Board, beforeEnter: requireAuth },
              { path: '/Client/Event', component: Events, beforeEnter: requireAuth},
              { path: '/Client/Conversation', component: Conversation, beforeEnter: requireAuth},
              { path: '/Client/Profil', component: Profil, beforeEnter: requireAuth},
        ]},
   { path: '/pro', component: Provider, beforeEnter: requireAuth }
    ]},
   { path: '/logout', component: Logout, beforeEnter: requireAuth }
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

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  render: h => h(App),
  components: { App}
})

