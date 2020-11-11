<template>
  <div id="register" class="text-center">
    <h1 class="regTitle">Create Account</h1>
    <form class="form-register" @submit.prevent="register">
      <div
        class="alert alert-danger"
        role="alert"
        v-if="registrationErrors"
      >{{ registrationErrorMsg }}</div>

      <div class="form-signin">
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
          <input
            type="password"
            id="confirmPassword"
            class="form-control"
            placeholder="Confirm Password"
            v-model="user.confirmPassword"
            required
          />
        </div>

        <div class="form-group2">
          <router-link class="HaveAccount" :to="{ name: 'login' }">Have an account?</router-link>
          <button class="btn btn-primary" type="submit">Create Account</button>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user"
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user."
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then(response => {
            if (response.status == 201) {
              this.$router.push({
                name: "login",
                query: { registration: "success" }
              });
            }
          })
          .catch(error => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    }
  }
};
</script>

<style>
form {
  margin-top: 30px;
}
.regTitle {
  width: 100%;
  padding-bottom: 3rem;
  margin-bottom: 0px;
  margin-left: 0px;
  background-color: rgba(228, 228, 228, 0.781);
}
.form-register {
  margin-top: 0px;
  height: 14rem;
  background-color: rgb(228, 228, 228, 0.7);
  display: flex;
  flex-direction: column;
}
.form-group2 {
  display: flex;
  width: 40rem;
  justify-content: space-between;
  align-items: baseline;
  font-size: 1.7rem;
}
.HaveAccount {
  font-size: 1.7rem;
}
</style>
