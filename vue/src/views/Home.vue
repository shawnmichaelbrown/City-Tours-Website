<template>
  <div class="home">
    <header>
      <img class="monogram" src="../assets/CS monogram.png" />
      <h1>CitySlickr</h1>
    </header>
    <img src="../assets/CBUS.png" title="Purple Skies of CBUS" />

    <search-bar />
    <br />
    <br />
    <section>
      <div class="icon">
        <i class="fas fa-search-location fa-10x" />
        <br />
        <h2>Search nearby locations</h2>
      </div>
      <div class="icon">
        <i class="fas fa-map-marked fa-10x" />
        <br />
        <h2>Create your own tour itineraries</h2>
      </div>
      <div class="icon">
        <i class="fas fa-route fa-10x" />
        <br />
        <h2>Plan your route</h2>
      </div>
    </section>
    <br />
    <br />
    <br />
    <br />
  </div>
</template>

<script>
import SearchBar from "../components/SearchBar.vue";
import AuthService from "../services/AuthService.js";

export default {
  name: "home",
  components: { SearchBar },
  Created() {
    AuthService.getLandmarks().then(response => {
      this.$store.commit("UPDATE_SEARCH_LANDMARKS", response.data);
    });
  }
};
</script>

<style scoped>
img {
  margin: auto;
  max-width: 1500px;
  width: 100%;
  height: auto;
  padding-bottom: 0px;
}
h1 {
  color: #222831;
  font-family: "Times New Roman", Times, serif;
  font-weight: bold;
  margin: 20px auto 10px 10px;
  max-width: 100%;
}
.home {
  background-color: rgba(245, 245, 245, 0.7);
  display: flex;
  flex-direction: column;
  justify-content: right;
  
}
.monogram {
  max-width: 70px;
  padding-top: 10px;
  border-radius: 15px;
}
header {
  display: flex;
  flex-direction: row;
  margin: 0 auto 0 10px;
}
section {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  flex-wrap:wrap;
}
.icon{
  display: flex;
  flex-direction: column;
}
h2 {
  
  font-family: Arial, Helvetica, sans-serif;
  color: #222831;
  font-weight: bold;
  font-size: 1.5rem;
}
i {
  color: rgb(146, 138, 252);
}
</style>
