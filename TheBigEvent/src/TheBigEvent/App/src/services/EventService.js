import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
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

    async selectGetAsync(method){
        return await getAsyncSelect(endpoint, method, AuthService.accessToken)
    }

    async getEvent()
    {

        
    }
}

export default new EventService()