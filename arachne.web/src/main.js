import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import Profile from "@/components/Profile/Profile";

Vue.config.productionTip = false;
Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: '/', component: App },
    { path: '/user', component: Profile },
  ]
});

new Vue({
  router,
  data: () => ({ n: 0 }),
  template: `      
      <router-view class="view"></router-view>
  `,
}).$mount('#app')
