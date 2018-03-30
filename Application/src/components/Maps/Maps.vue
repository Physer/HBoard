<template>
    <div class="maps">
        <div>
          <h2>Travel time by car</h2>
            <div>
                <p>Time from home to work: {{ timeToWork }}</p>
            </div>
            <div>
                <p>Time from work to home: {{ timeToHome }}</p>
            </div>
        </div>
    </div>
</template>

<script>
import store from "../../store/store.js";
import MapsService from "../../services/MapsService";

let mapsService = new MapsService();
let home = "IJsselsteen 47, Wijk bij Duurstede";
let work = "Entrada 705, Amsterdam";

function getTravelTime(origin, destination) {
  return mapsService.getTravelTime(origin, destination).then(data => {return data});
}

export default {
  name: "maps",
  data: function() {
    return {
      timeToWork: "",
      timeToHome: ""
    }
  },
  mounted: function() {
    getTravelTime(home, work).then(data =>{
      this.timeToWork = data;
    })
    getTravelTime(work, home).then(data =>{
      this.timeToHome = data;
    })
  }
}
</script>

<style>
.maps {
  background-color:blue;
}
</style>
