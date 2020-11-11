<template>
  <table id="tblLandmarks">
    <thead>
      <tr>
        <th>Landmark</th>
        <th>Address</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="landmark of landmarks" v-bind:key="landmark.id">
        <td class="name">{{landmark.name}}</td>
        <td class="address">{{landmark.address}}</td>
        <td class="description">{{landmark.description}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
export default {
  name: "search-results",

  data() {
    return {
      filter: {},

      landmarks: []
    };
  },
  methods: {},
  created() {
    this.landmarks = this.$store.state.searchResults;
  }
};
</script>

<style>
</style>