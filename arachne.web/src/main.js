import Vue from 'vue'
import App from './App.vue'
import store from "./store";
import VueRouter from 'vue-router'
import Auth from '@okta/okta-vue'
import ApiService from "@/common/api.service";
import Home from "@/views/Home";
import OwnProfile from "@/components/Profile/OwnProfile";
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

Vue.config.productionTip = false;

const OKTA_DOMAIN = "dev-782847.okta.com";
const CLIENT_ID = "0oadg7fpbltxMOZsh4x6";
const CALLBACK_PATH = '/implicit/callback';

const ISSUER = `https://${OKTA_DOMAIN}/oauth2/default`;
const HOST = window.location.host;
const REDIRECT_URI = `http://${HOST}${CALLBACK_PATH}`;
const SCOPES = 'openid profile email';

const config = {
  issuer: ISSUER,
  clientId: CLIENT_ID,
  redirectUri: REDIRECT_URI,
  scope: SCOPES.split(/\s+/),
};

Vue.use(Auth, {...config});

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes: [
    { path: CALLBACK_PATH, component: Auth.handleCallback()},
    { path: '/', component: Home },
    { path: '/user', component: OwnProfile, meta: { requiresAuth: true }},
  ]
});

router.beforeEach(Vue.prototype.$auth.authRedirectGuard());
Vue.use(VueRouter);

ApiService.init();

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
