<template>
  <div class="sbar">
    <div class="searchBar">
      <input
        required
        type="text"
        class="bars"
        placeholder="Enter your current address"
        v-model="pin.address"
      />
    </div>
    <div class="searchButton">
      <button class="btn btn-primary" v-on:click.prevent="searchLandmarks(pin)">
        Search
      </button>
    </div>
    <div class="viewAllButton">
      <button
        class="btn btn-primary"
        value="viewAll"
        v-on:click.prevent="listAll()"
      >
        View All Landmarks
      </button>
    </div>
  </div>
</template>

<script>
import AuthService from '../services/AuthService.js';

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
  methods: {
    searchLandmarks(pin) {
      console.log('hello landmarks');
      AuthService.getDistances(pin).then((response) => {
        console.log('response');
        this.$store.commit('UPDATE_SEARCH_LANDMARKS', response.data);
        if (this.$router.currentRoute.name !== 'search') {
          this.$router.push({ name: 'search' });
        }
      });
    },
    listAll() {
      this.pin.address = '';
      AuthService.getLandmarks().then((response) => {
        console.log('response');
        this.$store.commit('UPDATE_SEARCH_LANDMARKS', response.data);
        if (this.$router.currentRoute.name !== 'search') {
          this.$router.push({ name: 'search' });
        }
      });
    },
  },
};
</script>
<style>
h2 {
  font-weight: 300;
  line-height: 1;
  margin-right: 1rem;
}
form {
  justify-content: space-around;
  background-color: #eeeeee;
  height: 2.5rem;
  display: flex;
  align-items: center;
}
.btn {
  background-image: linear-gradient(rgb(128, 119, 255), rgb(80, 67, 255));
  margin-left: 10px;
  font-size:1.5rem;
}
.bars {
  
  width: 350px;
}
.sbar {
  display: flex;
  background-color: rgb(228, 228, 228, 0.7);
  /* padding-top: 8px; */
  /* padding-bottom: 20px; */
  flex-direction: row;
  justify-content: center;
  align-items:center;
  flex-wrap:wrap;
}
.searchButton {
  padding: 6px 9px 9px 9px;
}
.viewAllButton {
  padding: 6px 9px 9px 9px;
}
</style>
