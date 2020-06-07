<template>
  <div id="app">
    <page-header></page-header>
    <router-view class="container pt-5 pb-5" id="mainAppContainer"></router-view>
    <page-footer></page-footer>
  </div>
</template>

<script>
import PageHeader from "@/components/PageHeader";
export default {
  name: 'App',
  data: function () {
    return { authenticated: false }
  },
  created () { this.isAuthenticated() },
  watch: {
    // Everytime the route changes, check for auth status
    '$route': 'isAuthenticated'
  },
  methods: {
    async isAuthenticated () {
      this.authenticated = await this.$auth.isAuthenticated()
    }
  },
  components: {PageFooter, PageHeader}
}

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import PageFooter from "@/components/PageFooter";
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
  min-height: 80vh;
}

  body{
    min-height: 80vh;
    position: relative;
    background: #EEF4ED;
  }

  #mainAppContainer{
    min-height: 20vh;
    background: #FEFFFD;
  }
</style>
