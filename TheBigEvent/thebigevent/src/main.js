import Vue from 'vue'
import App from './App'

// Les libs / dépendances

import VueRouter from 'vue-router'

// Les pages avant-connexion
import Accueil from './before/accueil'
import Partenaire from './before/Partenaire'
import Galerie from './before/Galerie'

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  base: 'before/accueil',
  routes: [
    { path: '/', component: Accueil, name: 'home' },
    { path: '/Partner', component: Partenaire},
    { path: '/galerie', component: Galerie},
    { path: '*', redirect: '/before/accueil' }

   ]
})

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  render: h => h(App),
  components: { App }
})
