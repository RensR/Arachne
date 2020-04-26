import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import OwnProfile from "@/components/Profile/OwnProfile";

Vue.config.productionTip = false;
Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', component: App },
    { path: '/user', component: OwnProfile },
  ]
});

new Vue({
  router,
  data: () => ({ n: 0 }),
  template: `      
      <router-view class="view"></router-view>
  `,
}).$mount('#app')
