<template>
  <div>
    <div class="card" style="width: 18rem;">
      <div class="card-body">
        <h5 class="card-title">{{routeData.name}}</h5>
        <p class="card-text">{{routeData.description}}</p>
      </div>
      <ul class="list-group list-group-flush">
        <li class="list-group-item">{{routeData.distance}} miles</li>
      </ul>
      <div class="card-body">
        <a href="#" class="card-link">Edit</a>
        <a href="#" class="card-link">Delete</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "RouteCard",

  props: ["routeData"]
};
</script>

<style>
</style>