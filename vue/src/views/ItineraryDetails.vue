<template>
  <div class="theWholeThing">
    <div v-for="route of CreateList" v-bind:key="route.id">
      <landmark-card v-bind:landmarkData="route"></landmark-card>
      <div id="itinBox" class="select col-sm-9">
        <label  v-bind:for="route.id">Select Itinerary</label>
        <input type="checkbox" class="checkbox" v-bind:value="route.id" v-bind:id="route.id" v-model="toBeEdited" />
      </div>
    </div>
    <button class="btn btn-primary" v-on:click.prevent="UpdateItinerary()">Remove Selected Stops</button>
  <div>
    <append-itinerary v-bind:itinerary="this.itinerary"/>
      
  </div>
  </div>
</template>

<script>
import LandmarkCard from "../components/LandmarkCard.vue";
import AuthService from '../services/AuthService.js';
import AppendItinerary from '../components/AppendItinerary.vue';

export default {
  name: "ItineraryDetails",

  components: {
    LandmarkCard,
    AppendItinerary,
  },
  data() {
    return {
      landmarkList: [],
      itinerary: null,
      toBeEdited: []
    };
  },
  created() {
    this.landmarkList = this.$store.state.searchResults;
    const id = this.$route.params.id;

    this.itinerary = this.$store.state.itineraryList.find(l => l.id === id);
    this.itinerary.locations = this.itinerary.locations.split(",");
  },
  computed: {
    CreateList() {
      const itineraryList = [];
      this.itinerary.locations.forEach(i => {
        this.landmarkList.forEach(j => {
          if (i == j.id) {
            itineraryList.push(j);
          }
        });
      });
      return itineraryList;
    }
  },
  methods: {
    UpdateItinerary() {
      this.toBeEdited.forEach(i => {
        this.itinerary.locations.forEach(j => {
          if(i.toString() == j)
          {
            this.itinerary.locations.splice(this.itinerary.locations.indexOf(j), 1)
          } 
        })
      })
      this.$store.commit('UPDATE_ITINERARY', this.itinerary)
      AuthService.updateItinerary(this.itinerary).then( ()=> {
        this.$router.push({name: "itinerary"})
      })
    }
  }
};
</script>

<style>
.theWholeThing{
  background-color: rgba(255, 255, 255, 0.7);
  height:100%;
}
.select{
  background-color: rgb(236, 236, 236);
  margin:auto;
}
</style>
