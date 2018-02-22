import axios from 'axios';

export default class MapsService {
    getTravelTime(origin, destination) {
        return axios.get('http://localhost:58338/api/maps', {
            params: {
                origin: 'utrecht',
                destination: 'amsterdam'
            }
        })
        .then(function(response){
            console.log(response.data.duration);
            return response.data.duration;
        })
        .catch(function(response){
            console.log(response);
        });
    }
}