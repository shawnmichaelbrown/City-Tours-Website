<template>
  <div class="theWholeThing">
    <div>
      <!--Route information will live here-->
    </div>
    <div>
      <iframe
        width="600"
        height="450"
        frameborder="0"
        style="border:0"
        v-bind:src="
          encodeURI(
            googleURL.concat(
              this.key,
              this.origin,
              this.startingAddress,
              this.waypoints,
              this.locations,
              this.destination,
              this.startingAddress
            )
          )
        "
        allowfullscreen
      >
      </iframe>
    </div>
  </div>
</template>

<script>
export default {
  name: 'RouteGenerator',
  created() {
    const id = this.$route.params.id;

    let itineraryNeeded = this.$store.state.itineraryList.find(
      (l) => l.id === id
    );

    this.itinerary = itineraryNeeded;
    this.startingAddress = itineraryNeeded.address;

    this.landmarks = this.$store.state.searchResults;

    const locationIds = this.itinerary.locations.split(',');

    let result = [];
    locationIds.forEach((i) => {
      this.landmarks.forEach((j) => {
        if (i == j.id) {
          result.push(j.address);
        }
      });
    });
    this.locations = result.join('|');
  },
  data() {
    return {
      key: 'AIzaSyAbc0AY2GSen7tzTlF9b3qL7nmYQtdZPhg',
      startingAddress: null,
      locations: '',
      itinerary: null,
      landmarks: [],
      googleURL: 'https://www.google.com/maps/embed/v1/directions?key=',
      origin: '&origin=',
      waypoints: '&waypoints=',
      destination: '&destination=',
    };
  },
  computed: {},
};
</script>

<style>
.theWholeThing {
  background-color: rgba(255, 255, 255, 0.7);
  height: 100%;
}
</style>
