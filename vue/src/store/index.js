import Vue from 'vue';
import Vuex from 'vuex';
import axios from 'axios';

Vue.use(Vuex);

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token');

let currentUser = null;
if (
  localStorage.getItem('user') &&
  localStorage.getItem('user') != 'undefined'
) {
  currentUser = JSON.parse(localStorage.getItem('user'));
}

if (currentToken && currentToken != 'undefined') {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    mapThing: null,
    searchResults: [],
    itineraryList: [],
    token: currentToken || '',
    user: currentUser || {}, // If a user is an admin, their user.role will be 'admin'
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    UPDATE_SEARCH_LANDMARKS(state, payload) {
      state.searchResults = payload;
    },
    UPDATE_ITINERARY(state, payload) {
      state.itineraryList.forEach((i) => {
        if (i == payload.id) {
          state.itineraryList.pop(i);
        }
      });
      state.itineraryList.push(payload);
    },
    SET_ITINERARY(state, payload) {
      state.itineraryList = payload;
    },
    SET_MAP_THING(state, payload) {
      state.mapThing = payload;
    },
  },
});
