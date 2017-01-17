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
import Chat from './Client/Chat.vue'

// Fournisseurs
import Add from './Provider/add.vue'
import Add_s from './Provider/add_salle.vue'
import Add_d from './Provider/Add_deco.vue'
import Add_t from './Provider/Add_traiteur.vue'

import Provider from './Provider/Provider.vue'
import EventsP from  './Provider/Event.vue'
import ProfilP from  './Provider/Profil.vue'
import ConversationP from './Provider/Conversation.vue'
import BoardP from './Provider/board.vue'

Vue.use(VueRouter);

function requireAuth (to, from, next)  {
  if (!AuthService.isConnected) {
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
              { path: '/Client/Chat', component: Chat, beforeEnter: requireAuth}
        ]},
        { path: '/pro', component: Provider, redirect: "/Pro/board", beforeEnter: requireAuth, children:[
              { path : '/pro/add', component: Add, beforeEnter: requireAuth, children:[
              { path: '/pro/Add_salle', component: Add_s, beforeEnter: requireAuth},
              { path: '/pro/Add_traiteur', component: Add_t, beforeEnter: requireAuth},
              { path: '/pro/Add_deco', component: Add_d, beforeEnter: requireAuth}
              ]},
              { path : '/Pro/board', component: BoardP, beforeEnter: requireAuth },
              { path: '/Pro/Event', component: EventsP, beforeEnter: requireAuth},
              { path: '/Pro/Conversation', component: ConversationP, beforeEnter: requireAuth},
              { path: '/Pro/Profil', component: ProfilP, beforeEnter: requireAuth},
        ]},
    ]},
   { path: '/logout', component: Logout, beforeEnter: requireAuth }
  ]
})

AuthService.allowedOrigins = ['http://localhost:5000'];
AuthService.logoutEndpoint = '/Acount/LogOff';

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

