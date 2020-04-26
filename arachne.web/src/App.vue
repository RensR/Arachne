<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <fullList :list="overview">
    </fullList>
  </div>
</template>

<script>

import ConnectionList from "@/components/ConnectionList";

const list = [{id: 0, name: "Rens", secret: "test"}, {id: 1, name: "Peter", secret: "nothing"}, {id: 2, name: "Henk", secret: "vue"}, ];
export default {
  name: 'App',
  components: {
    "fullList": ConnectionList
  },
  data: function(){
    return {
      overview: list
    }
  }
}
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
