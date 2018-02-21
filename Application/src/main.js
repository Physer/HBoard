import Vue from 'vue';
import { sync } from 'vuex-router-sync';
import App from './App.vue'
import router from './router/router';
import store from './store/store.js';

Vue.config.productionTip = false;

sync(store, router);
console.log("Hi");
new Vue({
  el: '#app',
  functional: true,
  router,
  store,
  render(h) {
    return h(App);
  },
});