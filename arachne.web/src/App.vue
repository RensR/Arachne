<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <router-view class="view"></router-view>
  </div>
</template>

<script>
export default {
  name: 'App'
}

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
