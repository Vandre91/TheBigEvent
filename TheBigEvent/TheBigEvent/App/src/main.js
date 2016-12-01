        import Vue from 'vue'
        import App from './App'

        import VueRouter from 'vue-router'
        import $ from 'jquery'
       

        import Accueil from './before/accueil'
        import Partenaire from './before/Partenaire'
        import Whoarewe from './before/Whoarewe'
        import Galerie from './before/Galerie'


        Vue.use(VueRouter);



        const router = new VueRouter({
          mode: 'history',
          base: 'before/accueil',
        routes: [
          { path: '/', component: Accueil, name: 'home'},
          { path: '/Partenaire', component: Partenaire },
          { path: '/Galerie', component: Galerie },
          { path: '/Whoarewe', component: Whoarewe }
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


// define slider component
Vue.component('img-slider', {
  template: '#img-slider-template',
  replace: true
})
// boot up demo
new Vue({
  el: '#demo'
})