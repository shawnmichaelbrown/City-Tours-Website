<template>
  <div>
    <h2>Feel like adding more?</h2>
    <table>
      <tr v-for="landmark of filteredLandmarks" v-bind:key="landmark.id">
        <td class="nameLabel">{{landmark.name}}</td>
        <td>
          <input class="checkbox" type="checkbox" v-bind:value="landmark.id" v-model="toBeAdded" />
        </td>
        <td></td>
      </tr>
    </table>
    <button class="btn btn-primary" v-on:click.prevent="commitItinerary()">Add to Itinerary</button>
  </div>
</template>

<script>
import AuthService from "../services/AuthService.js";
export default {
  data() {
    return {
      landmarks: [],
      toBeAdded: [],
      payload: this.itinerary
    };
  },
  props: ["itinerary"],
  created() {
    this.landmarks = this.$store.state.searchResults;
  },
  methods: {
    commitItinerary() {
      this.$store.commit("UPDATE_ITINERARY", this.itinerary);

      this.toBeAdded.forEach(i => {
        this.itinerary.locations.push(i.toString());
      });

      AuthService.updateItinerary(this.itinerary).then(() => {
        this.$router.push({ name: "itinerary" });
      });
    }
  },
  computed: {
    filteredLandmarks() {
      let result = [];
      this.landmarks.forEach(j => {
        if (!this.itinerary.locations.includes(j.id.toString())) {
          result.push(j);
        }
      });
      return result;
    }
  }
};
</script>

<style>

h2 {
  font-family: Arial, Helvetica, sans-serif;
  font-weight:bold;
}
table {
  margin: auto;
  background-color: rgba(255, 255, 255, 0.3);
  padding:15px;
}
.checkbox {
  height: 25px;
  width: 25px;
}
</style>