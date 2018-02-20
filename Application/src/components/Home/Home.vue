<template>
  <div id="home">
      <h1>HBoard</h1>
      <h2>Count: {{ count }}</h2>
      <input type="button" @click="increment"/>
  </div>
</template>

<script>
import store from '../../store/store.js'
export default {
    name: 'home',
    computed: {
        count() {
            return store.state.count
        }
    },
    methods: {
        increment() {
            store.commit('increment')
        }
    }
}
</script>

<style>

</style>
