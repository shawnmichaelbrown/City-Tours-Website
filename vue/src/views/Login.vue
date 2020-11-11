<template>
  <div id="login" class="text-center">
    <h1 class="SignTitle">Please Sign In</h1>
    <form class="form-signin" @submit.prevent="login">
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>

      <div class="alert alert-danger" role="alert" v-if="networkError">Network error!</div>

      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>

      <div class="form-group">
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
        />
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
      </div>

      <div class="form-group3">
        <router-link class="newAccount" :to="{ name: 'register' }">Need an account?</router-link>
        <button class="btn btn-primary" type="submit">Sign in</button>
      </div>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false,
      networkError: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({ name: "home" });
          }
        })
        .catch(error => {
          const response = error.response;

          if (response == null || response.status === 500) {
            this.networkError = true;
          } else if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
.form-group {
  color: #7971ea;
  display: flex;
  flex-wrap: wrap;
  margin-bottom: 0px;

}
.form-group3 {
  color: #7971ea;
  display: flex;
  align-items: baseline;
  justify-content: space-between;
  width: 350px;
  margin-bottom: 3rem;
}
.btn {
  background-image: linear-gradient(rgb(128, 119, 255), rgb(80, 67, 255));
}
h1,
input,
.form-group,
button {
  padding: 10px;
}
.form-signin {
  margin-top: 0px;
  height: 14rem;
  background-color: rgb(228, 228, 228, 0.7);
  display: flex;
  flex-direction: column;
}
.SignTitle {
  width: 100%;
  padding-bottom: 3rem;
  margin-bottom: 0px;
  margin-left: 0px;
  background-color: rgba(228, 228, 228, 0.781);
}
.newAccount{
  font-size: 1.7rem;
}
</style>
