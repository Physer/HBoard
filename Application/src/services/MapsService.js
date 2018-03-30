import axios from 'axios';
import Config from '../Config';

export default class MapsService {
    getTravelTime(origin, destination) {
        return axios.get(`${Config.apiBaseUrl}/${Config.getDirectionsUrl}`, {
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