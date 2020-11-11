<template>
  <div class="row">
    <div class="col-sm-9">
      <div class="card">
        <img class="thumb" v-bind:src="wikiImage"/>
        <div class="card-body">
          <router-link
            class="card-title col-sm-5"
            v-bind:to="{
              name: 'landmarkDetails',
              params: { id: landmarkData.id },}"
          >{{ landmarkData.name }}</router-link>
          <p class="card-text">{{ landmarkData.description }}</p>
          <p class="card-text">{{ landmarkData.address }}</p>
          <p class="card-text" v-if="landmarkData.distance > 0">{{ landmarkData.distance }} miles</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import AuthService from '../services/AuthService.js';
export default {
  computed: {},
  props: ["landmarkData"],
  wikiImage: '',

  created () {
    const name = { Text: this.landmarkData.name };
    AuthService.getImage(name).then((response) => {
    this.wikiImage = response.data;
    });
  }
};
</script>

<style>
label,
input {
  margin: 10px;
}
.card {
  margin-top: 1rem;
  border-bottom: 0px;
  display:flex;
  flex-direction:row;
}
.row {
  justify-content: center;
}
.card-title {
  font-size: 2rem;
  color: rgb(99, 88, 255);
  font-weight: bold;
}
.card-body {
  background-color: white;
  position:center;
   /* display:flex;
  flex-direction:row;
  justify-content: space-evenly; */
}
.thumb {
  max-width:20%;
  height:auto;
  max-height:10rem;
}
</style>
