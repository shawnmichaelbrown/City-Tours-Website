<template>
  <div class="search">
    <search-bar></search-bar>
    <landmark-list class="list"></landmark-list>
  </div>
</template>

<script>
import SearchBar from '../components/SearchBar.vue';
import LandmarkList from '../components/LandmarkList.vue';

export default {
  data() {
    return {
      landmarks: [],
      pin: {
        address: '',
      },
      distance: 0,
    };
  },
  components: {
    SearchBar,
    LandmarkList,
  },
  methods: {},
};
</script>

<style>
html {
  background-color: rgb(228, 228, 228);
}
.search {
  display: flex;
  flex-direction: column;
  justify-content: center;
}
</style>
