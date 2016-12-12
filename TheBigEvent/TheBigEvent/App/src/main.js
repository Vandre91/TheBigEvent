import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import AuthService from './services/auth.js'


// Les pages avant-connexion
import Accueil from './before/accueil.vue'
import Partenaire from './before/Partenaire.vue'
import Galerie from './before/Galerie.vue'

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  base: 'before/accueil',
  routes: [
    { path: '/', component: Accueil, name: 'home' },
    { path: '/Partner', component: Partenaire},
    { path: '/galerie', component: Galerie},
    { path: '/user/board', beforeEnter: AuthService},
    { path: '*', redirect:'/'}
   ]
})

AuthService.allowedOrigins = ['http://localhost:5000'];

AuthService.logoutEndpoint = '/Account/LogOff';


AuthService.providers = {
  'Base': {
    endpoint: '/Account/Login' 
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
