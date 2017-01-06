import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper'
import AuthService from './auth'

const endpoint = "/api/Event";

class EventService {
    constructor() {
    }

// On crée un évènement

    async createEventAsync(model) 
    {
        return await postAsync(endpoint, '', AuthService.accessToken, model);
    }

// On supprime un évènement

    async deleteUserAsync(Id)
    {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }
}

export default new EventService()