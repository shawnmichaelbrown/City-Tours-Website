<template>
  <div class="landmarkForm">
    <h2 class="titleLand">Add a Landmark</h2>
    <div class="landmarkInputs">
      <div>
        <label for="inputName">Name</label>
        <input required type="text" id="inputName" placeholder="Name" v-model="newLandmark.name" />
      </div>
      <div>
        <label for="inputAddress">Address</label>
        <input
          required
          type="text"
          id="inputAddress"
          placeholder="1234 Main St"
          v-model="newLandmark.address"
        />
      </div>
      <div>
        <label for="inputCity">City</label>
        <input required type="text" id="inputCity" v-model="newLandmark.city" />
      </div>
      <div>
        <label for="inputState">State</label>
        <select required id="inputState" v-model="newLandmark.state">
          <option selected>Choose...</option>
          <option value="OH">Ohio</option>
        </select>
      </div>
      <div>
        <label for="inputZip">Zip</label>
        <input required type="text" id="inputZip" v-model="newLandmark.zipcode" />
      </div>

      <div>
        <label for="description">Description</label>
        <input
          required
          type="text"
          id="description"
          placeholder="Please give a brief description"
          v-model="newLandmark.description"
        />
      </div>
    </div>
    <div>
      <button type="submit" class="btn btn-primary" v-on:click="addNewLandmark()">
        <i class="fas fa-landmark fa-2x"></i>
        <br />Add Landmark
      </button>
    </div>
  </div>
</template>

<script>
import AuthService from "../services/AuthService.js";

export default {
  name: "AddLandmark",
  data() {
    return {
      newLandmark: {
        name: "",
        address: "",
        description: ""
      },
      pin: { address: "" }
    };
  },

  methods: {
    addNewLandmark() {
      const toAdd = {
        name: this.newLandmark.name,
        address:
          this.newLandmark.address +
          this.newLandmark.city +
          this.newLandmark.state +
          this.newLandmark.zipcode,
        description: this.newLandmark.description
      };
      AuthService.addLandmark(toAdd).then(response => {
        console.log(response.data);
      });
      AuthService.getDistances(this.pin).then(response => {
        this.$store.commit("UPDATE_SEARCH_LANDMARKS", response.data);
        this.$router.push({ name: "search" });
      });
    }
  }
};
</script>

<style scoped>
label {
  min-width: 100px;
}
.landmarkForm {
  display: flex;
  flex-direction: column;
}
.titleLand {
  margin-top: 35px;
  margin-bottom: 35px;
    font-weight: bold;
    color: #393e46;
    font-family: 'Times New Roman', Times, serif;
    font-size: 60px;
    padding: 5px;
    margin: auto;
  background-color: rgba(206, 206, 206, 0.753);
  width: 100%;
}
.landmarkInputs {
  background-color: #eeeeee;
  display: flex;
  margin: auto;
  align-content: flex-start;
  align-items: flex-start;
  flex-direction: column;
  margin-bottom: 30px;
  border-style: groove;
  border-width: 3px;
  border-color: grey;
  margin-top: 10px;
}
.form-group {
  display: flex;
  flex-direction: row;
}
#inputState {
  margin: 10px;
}
</style>
