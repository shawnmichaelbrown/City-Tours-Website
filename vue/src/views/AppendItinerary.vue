<template>
  <div class="theWholeThing">
    <table>
      <tr  v-for="landmark of filteredLandmarks" v-bind:key="landmark.id">
        <td class="name">{{landmark.name}}</td>
        <td>
          <input type="checkbox" id="checkbox" v-bind:value="landmark.id" v-model="toBeAdded" />
        </td>
        <td></td>
      </tr>
    </table>
    <button class="btn btn-primary" v-on:click.prevent="commitItinerary">Add to Itinerary</button>
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
      AuthService.updateItinerary(this.itinerary).then(() => {
        this.$router.push({ name: "itinerary" });
      });
    }
  },
  computed: {
    filteredLandmarks() {
      let result = [];
      this.itinerary.locations.forEach(l => {
        this.landmarks.forEach(la => {
          if (l !== la.id) {
            result.push(la);
          }
        });
      });
      return result;
    }
  }
};
</script>

<style>
.theWholeThing {
  background-color: rgba(255, 255, 255, 0.7);
  height: 100%;
  padding:2rem;
}
.name {
  font-weight: bold;
  font-size:larger;
}
.nameLabel{
  font-size:1.5rem;
}
.checkbox {
  height: 25px;
  width: 25px;
}
</style>