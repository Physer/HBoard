<template>
  <div>
      {{getTime()}}
      <h2>Hello {{ message }} - {{count}}</h2>
  </div>
</template>

<script>
import store from '../../store/store.js';
import MapsService from '../../services/MapsService';

export default {
    name: 'maps',
    data: function() {
        return {message: ""};
    },
    computed: {
        count() {
            return store.state.count;
        },
    },
    methods: {
        getTime() {
            let service = new MapsService();
            service.getTravelTime("utrecht", "amsterdam").then(data => {
                this.message = data;
            });
        }
    }
}
</script>

<style>

</style>
