<template>
  <div>
      {{getTimeToWork()}}
      {{getTimeToHome()}}
      Time to work: {{timeToWork}}
      <br />
      Time to home: {{timeToHome}}
  </div>
</template>

<script>
import store from '../../store/store.js';
import MapsService from '../../services/MapsService';

export default {
    name: 'maps',
    data: function() {
        return { 
            timeToWork: "",
            timeToHome: ""
        }
    },
    methods: {
        getTimeToWork: function() {
            let service = new MapsService();
            service.getTravelTime("IJsselsteen 47, Wijk bij Duurstede", "Entrada 705, Amsterdam").then(data => {
                this.timeToWork = data;
            });
        },
        getTimeToHome: function() {
           let service = new MapsService();
            service.getTravelTime("Entrada 705, Amsterdam", "IJsselsteen 47, Wijk bij Duurstede").then(data => {
                this.timeToHome = data;
            });
        }
    }
}
</script>

<style>

</style>
