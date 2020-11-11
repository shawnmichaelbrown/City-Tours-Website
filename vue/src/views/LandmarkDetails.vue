<template>
  <div class="theWholeThing">
    <landmark-card v-bind:landmarkData="landmark"></landmark-card>
    <h1 class="details">Details</h1>
    <div class="content">
      <img class="img" v-bind:src="this.wikiImage" />
      <h2 class="description">{{ this.wikiDescription }}</h2>
    </div>
  </div>
</template>

<script>
import LandmarkCard from '../components/LandmarkCard.vue';
import AuthService from '../services/AuthService.js';

export default {
  name: 'LandmarkDetails',
  components: {
    LandmarkCard,
  },
  data() {
    return {
      landmark: null,
      wikiDescription: '',
      wikiImage: '',
    };
  },
  created() {
    console.log(this.$route.params);
    const id = this.$route.params.id;

    this.landmark = this.$store.state.searchResults.find((l) => l.id === id);

    const name = { Text: this.landmark.name };
    AuthService.getDescription(name).then((response) => {
      this.wikiDescription = response.data;
    });
    AuthService.getImage(name).then((response) => {
      this.wikiImage = response.data;
    });
  },
};
</script>

<style>
.theWholeThing{
  background-color: rgba(255, 255, 255, 0.7);
  height:100%;
}
.content {
  display: flex;
  flex-basis: auto;
}
.img {
  border-style: groove;
  border-color: grey;
  border-radius: 5px;
  max-width: 30%;
  height: fit-content;
  margin: 5px;
}
.description {
  height: fit-content;
  border-style: groove;
  border-color: grey;
  border-radius: 5px;
  margin: 5px;
  padding: 5px;
  text-align: justify;
  font-size: 150%;
  background-color: white;
}
</style>
