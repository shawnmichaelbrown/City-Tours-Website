<template>
  <div class="theWholeThing">
    <header class="itinHeader">
    <h1>Itineraries</h1>
    </header>
  <div class="cardStructure">
    <itinerary-card class="cards"
      v-for="itinerary of itineraryList"
      v-bind:key="itinerary.id"
      v-bind:ItineraryDetails="itinerary"
    >
    </itinerary-card>
    </div>
  </div>
</template>

<script>
import AuthService from "../services/AuthService.js";
import ItineraryCard from "../components/ItineraryCard.vue";


export default {
  name: "Itinerary",

  components: { ItineraryCard },

  data() {
    return {
      ItineraryId: null,
      id: this.$store.state.user.userId,
      itineraryList: [],
      landmarkList: [],
      toBeEdited: []
    };
  },
  created() {
    AuthService.getItineraries(this.id).then(response => {
      this.$store.commit("SET_ITINERARY", response.data);
      this.itineraryList = response.data;
    });
  }
};
</script>

<style>
.theWholeThing{
  background-color: rgba(255, 255, 255, 0.7);
  
}
.itinHeader{
  color:white;
  background-image: url("../assets/headerBackground.jpg");
  display: flex;
  align-items: center;
  filter: hue-rotate(345deg)
}
h1{
  font-family: "Times New Roman", Times, serif;
  font-variant: small-caps;
  font-weight: lighter;
  font-size: 60px;
  font: medium;
  /* margin-left: 130px; */
  
}
body{
  background-image: url("../assets/Berlin.png");
  min-height: 100%;
}
.cardStructure{
  display: flex;
  align-items: stretch;
  flex-wrap: wrap;
}
.itinHeader {
  justify-content: center;
}
</style>
