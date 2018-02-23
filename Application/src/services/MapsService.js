import axios from 'axios';

export default class MapsService {
    getTravelTime(origin, destination) {
        return axios.get('http://localhost:58338/api/maps', {
            params: {
                origin: origin,
                destination: destination
            }
        })
        .then(function(response){
            return response.data.duration;
        })
        .catch(function(response){
            console.log("An error has occured while retrieving Maps data");
            console.log(response);
        });
    }
}