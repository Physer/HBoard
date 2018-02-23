import Vue from 'vue';
import App from './App.vue'
import store from './store/store.js';

import Home from './components/Home/Home.vue';
import Maps from './components/Maps/Maps.vue';

Vue.config.productionTip = false;

Vue.component('home', Home);
Vue.component('maps', Maps);

new Vue({
  el: '#app',
  functional: true,
  store,
  render(h) {
    return h(App);
  },
});