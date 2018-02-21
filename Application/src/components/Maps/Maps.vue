<template>
  <div>
      <h2>Hello {{ message }} - {{count}}</h2>
  </div>
</template>

<script>
import store from '../../store/store.js';

export default {
    name: 'maps',
    data() {
        return {
            message: "maps-component",
        }
    },
    computed: {
        count() {
            return store.state.count;
        }
    }
}
</script>

<style>

</style>
