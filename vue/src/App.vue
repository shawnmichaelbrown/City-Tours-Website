<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.0/components/alerts/ for reference on bootstrap -->
<template>
  <div id="app" class="container">
    <div id="nav">
      <div class="miniContainer">
        <router-link class="icon" v-bind:to="{ name: 'home' }"
          ><img class="monogram" src="./assets/CS monogram.png"
        /></router-link>
        <router-link class="nav-item" v-bind:to="{ name: 'home' }">
          <i class="fas fa-city buildingIcon"></i>
          <!-- This is a font awesome icon -->
          Home
        </router-link>
        
        <router-link
          class="nav-item"
          v-bind:to="{ name: 'addLandmark' }"
          v-if="$store.state.user.role === 'admin'"
        >
          &nbsp;Add Landmark
        </router-link>
         <router-link
          class="nav-item"
          v-bind:to="{ name: 'itinerary' }"
          v-if="$store.state.token"
        >
          &nbsp;Itinerary
        </router-link>
         <router-link
          class="nav-item"
          v-bind:to="{ name: 'search' }"
        >
          &nbsp;Search Landmarks
        </router-link>
      </div>
      <div class="log-items">
       <div class="logReg"> 
        <router-link
          class="log-item"
          v-bind:to="{ name: 'register' }"
          v-if="!$store.state.token">&nbsp;Register</router-link>
        <router-link
          class="log-item"
          v-bind:to="{ name: 'login' }"
          v-if="!$store.state.token"
        >&nbsp;Login</router-link>
        </div>
        <router-link
          class="log-item"
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token"
        >
          &nbsp;Logout
        </router-link>
      </div>
    </div>
    <router-view />
  </div>
</template>

<script>
export default {};
</script>

<!-- Application-Wide Styles go here -->
<style>
html {
  background-color: #a6a8b3;
  min-width: 100%;
  min-height: 100%;
  height: 100%;
}
#nav {
  background-color: #222831;
  display: flex;
  flex-direction:row;
  justify-content: space-between;
  align-items:center;
  flex-wrap:wrap;
  height: 4.5rem;
}
.nav-item, .log-item {
  display: flex;
  color: rgb(169, 163, 255);
  padding: 10px;
  border-radius: 5px;
  margin: 10px;
  font-weight: bold;
  font-family: Arial, Helvetica, sans-serif;
  align-items: center;
  font-size: 20px;
  
}
.nav-item:hover, .log-item:hover {
  color: #e0e5ff;
  text-decoration: none;
  background-color: rgb(61, 61, 61);
}
.container {
  max-width: 100%;
  padding: 0;
}
body {
  background-color: transparent;
  text-align: center;
}
.monogram {
  max-width: 50px;
  border-radius: 10px;
  margin:15px;
}
.log-items {
  justify-self: flex-end;
  
}
.miniContainer {
  display: flex;
}
.buildingIcon{
  padding-right: 5px;
}

::-webkit-scrollbar {
    width: 15px;
}
::-webkit-scrollbar-thumb {
    background-color: rgb(86, 77, 202);
}
.logReg{
  display: flex;
}
</style>
