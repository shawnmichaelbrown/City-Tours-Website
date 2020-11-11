<template>
  <div class="itinCard">
    <div class="card-body">
      <router-link
        class="card-title"
        v-bind:to="{
          name: 'ItineraryDetails',
          params: { id: ItineraryDetails.id },}">{{ ItineraryDetails.name }}</router-link>

      <ul class="list-group">
        <li class="list-group-item">
          Total Stops: {{ ItineraryDetails.locations.split(',').length }}
        </li>
      </ul>
      <!-- <button href="#" class="btn btn-primary"
      v-on:click="this.$router.push({name: 'ItineraryDetails', params: {id: ItineraryDetails.id}})"
     >Edit</button> -->
     <div class="actionBtns">
      <router-link
        v-bind:to="{
          name: 'RouteGenerator',
          params: { id: ItineraryDetails.id },
        }"
        class="btn btn-primary"
      >
        Generate Route
      </router-link>
      <button
        v-on:click.prevent="DeleteItinerary(ItineraryDetails.id)"
        class="btn btn-primary itinCardBtn"
      >
        Delete
      </button>
    </div>
    </div>
  </div>
</template>

<script>
import AuthService from '../services/AuthService.js';

export default {
  name: 'ItineraryCard',
  data() {
    return {
      landmarkList: [],
    };
  },
  props: ['ItineraryDetails'],

  created() {
    AuthService.getLandmarks().then((response) => {
      this.$store.commit('UPDATE_SEARCH_LANDMARKS', response.data);
      this.landmarkList = response.data;
    });
  },
  methods: {
    DeleteItinerary(id) {
      AuthService.deleteItinerary(id).then((response) => {
        console.log(response.data);
       
        window.location.reload();
      });
    },
  },
};
</script>

<style>
.card-body{
  /* background-image: url("../assets/2markerDots.png"); */
  /* background-size: contain;
  background-repeat:no-repeat;
  background-position: center; */
}
.itinCardBtn{
  font-size: 1.2rem;
}

.btn.btn-primary{
  margin-top: 2rem;
  margin-left: 0px;
  
}
.list-group-item{
  margin: 1rem;
}
.itinCard{
  margin: auto;
  font-family: "Times New Roman", Times, serif;
  margin-bottom: 2.5rem;
  min-width: 300px;
  max-width: 300px;
}
.actionBtns{
  display: flex;
  justify-items: center;
  justify-content: space-between;
}
.card-title {
  font-size: 30px;
}
</style>
