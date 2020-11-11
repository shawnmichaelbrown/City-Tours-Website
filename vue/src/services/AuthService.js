import axios from 'axios';

/* const http = axios.create({
  baseURL: 'http://localhost:44315'
}); */

export default {
  login(user) {
    return axios.post('/login', user);
  },
  register(user) {
    return axios.post('/login/register', user);
  },
  getLandmarks() {
    return axios.get('/search');
  },
  searchLandmarks(pin) {
    return axios.get(`/search/${pin}`);
  },
  getDistances(address) {
    return axios.post('/search/distanceCalculator', address);
  },
  addLandmark(landmark) {
    return axios.post('/landmark/add', landmark);
  },
  getDescription(name) {
    return axios.post('/landmark/getDescription', name)
  },
  getImage(name) {
    return axios.post('/landmark/getImage', name)
  },
  getItineraries(id) {
    return axios.get(`/itinerary/fetch/${id}`)
  },
  addItinerary(itinerary){
    const payload = {...itinerary, locations: itinerary.locations.join()}
    return axios.post('/itinerary/add', payload);
  },
  deleteItinerary(id){
    return axios.delete(`/itinerary/delete/${id}`);
  },
  updateItinerary(itinerary){
    const payload = {...itinerary, locations: itinerary.locations.join()}
    return axios.put('/itinerary/edit', payload)
  }
};
