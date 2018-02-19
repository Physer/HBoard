import Vue from 'vue';
import { sync } from 'vuex-router-sync';
//import App from './App'
import router from './router/router';
import store from './store/store';

Vue.config.productionTip = false;

sync(store, router);

new Vue({
  el: '#app',
  functional: true,
  router,
  store,
  render(h) {
    return h(App);
  },
});