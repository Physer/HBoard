import Vue from 'vue';
import Router from 'vue-router';
//import Maps from '@/.././components/Maps/maps';

Vue.use(Router);

const router = new Router({
    mode: 'history',
    base: process.env.ROUTER_PREFIX,
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/maps',
            name: 'maps',
            component: Maps,
        },
        {
            path: '*',
            component: {
                functional: true,
                render(h) {
                    return h('h1', 'Page not found!');
                },
            },
        },
    ],
});

export default router;