<template>
  <div class="theWholeThing" v-if="this.$store.state.searchResults.length > 0">
    <h2 class="locTitle">Locations</h2>
    <div class="rangeBar">
      <label for="search-range" class="fixed-label">Search Range</label>
      <input
        type="text"
        id="search-range"
        placeholder="How far out would you like to look?"
        v-model="distance"
      />
      <span class="suffix">Miles</span>
    </div>
    <div v-for="landmark of landmarks" v-bind:key="landmark.id">
      <landmark-card v-if="landmark.distance <= distance" v-bind:landmarkData="landmark"></landmark-card>
      <div id="itinBox" class="col-sm-9">
        <label v-if="landmark.distance <= distance" v-bind:for="landmark.id">Add to Itinerary</label>
        <input class="checkbox"
          v-if="landmark.distance <= distance"
          type="checkbox"
          v-bind:value="landmark.id"
          v-bind:id="landmark.id"
          v-model="itinerary.locations"
        />
      </div>
    </div>
    <div class="AddItinBlock">
    <button class="btn btn-primary" type="submit" v-on:click.prevent="commitItineraryToDataBase()">Add to Itinerary</button>
    <label class="label nameLabel" for="nameInput">Itinerary Name</label>
    <input
      required
      name="nameInput"
      type="text"
      placeholder="Enter Itinerary Name"
      v-model="itinerary.name"
    />
    <input
      required
      name="nameInput"
      type="text"
      placeholder="Enter Starting Address"
      v-model="itinerary.address"
    />
    </div>
  </div>
</template>

<script>
import LandmarkCard from "../components/LandmarkCard.vue";
import AuthService from "../services/AuthService.js";

export default {
  data() {
    return {
      distance: 10,
      itinerary: {
        name: "",
        locations: [],
        address: "",
        userId: this.$store.state.user.userId
      }
    };
  },
  name: "LandmarkList",
  components: {
    LandmarkCard
  },
  props: {},
  computed: {
    landmarks() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      let results = this.$store.state.searchResults
        .slice()
        .sort((a, b) => a.distance - b.distance);

      return results;
    }
  },
  methods: {
    commitItineraryToDataBase() {
      AuthService.addItinerary(this.itinerary).then(() => {
        this.$router.push({ name: "itinerary" });
      });
    }
  }
};
</script>

<style>
.theWholeThing{
  background-color: rgba(255, 255, 255, 0.7);
}
.title {
  font-weight: bold;
  color:#393e46;
  font-family:'Times New Roman', Times, serif;
  background-color: rgba(255, 255, 255, 0.7);
  font-size: 60px;
  padding:5px;
  margin: auto;
}
.checkbox {
  height: 25px;
  width: 25px;
}
label, input {
 font-size: 1.5rem;
}
.nameLabel{
  font-size:1.5rem;
}
#search-range {
  width: 260px;
}
.col-sm-6 {
  justify-content: center;
  margin: auto;
  background-color: rgba(255, 255, 255, 0.7);
}
#itinBox {
  margin:auto;
  position: relative;
  background-color: rgb(236, 236, 236);
  margin-bottom: 1rem;
  display:flex;
  align-items:center;
  justify-content: center;
}
.row {
  justify-content: center;
}
.btn-primary {
  margin-bottom: 2rem;
}
.fixed-label {
  margin-top: 1rem;
  margin-bottom: 0rem;
}
.rangeBar{
  background-color: rgba(228, 228, 228, 0.466);
}
.locTitle{
    font-weight: bold;
    color: #393e46;
    font-family: 'Times New Roman', Times, serif;
    background-color: rgba(228, 228, 228, 0.466);
    font-size: 60px;
    padding: 5px;
    margin: auto;
}
.AddItinBlock{
background-color: rgba(228, 228, 228, 0.671);
}

</style>
