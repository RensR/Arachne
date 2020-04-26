import Vue from 'vue'
import App from './App.vue'
import store from "./store";
import VueRouter from 'vue-router'
import OwnProfile from "@/components/Profile/OwnProfile";
import ApiService from "@/common/api.service";
import ConnectionList from "@/components/ConnectionList";

Vue.config.productionTip = false;
Vue.use(VueRouter);

ApiService.init();

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', component: ConnectionList },
    { path: '/user', component: OwnProfile },
  ]
});

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
