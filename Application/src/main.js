import Vue from 'vue';
import App from './App.vue'
import store from './store/store.js';

import Header from './components/Header/Header.vue';
import Sidebar from './components/Sidebar/Sidebar.vue'
import Maps from './components/Maps/Maps.vue';

Vue.config.productionTip = false;

Vue.component('header-bar', Header);
Vue.component('sidebar', Sidebar);
Vue.component('maps', Maps);

new Vue({
  el: '#app',
  functional: true,
  store,
  render(h) {
    return h(App);
  },
});