import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/EventPro";

class EventProService {
    constructor() {
    }

    async getEventAsync(id) 
    {
        return await getAsync(endpoint, id, AuthService.accessToken);
    }
    async getSalleAsync(id) 
    {
        return await getAsync(endpoint, "Salle/"+id, AuthService.accessToken);
    }
    async getDecoAsync(id) 
    {
        return await getAsync(endpoint, "Deco/"+id, AuthService.accessToken);
    }
    async getTraiteurAsync(id) 
    {
        return await getAsync(endpoint, "Traiteur/"+id, AuthService.accessToken);
    }

    async getEventBySalleIdAsync(id) 
    {
        return await getAsync(endpoint, "SalleId/"+id, AuthService.accessToken);
    }

    async getEventByDecoIdAsync(id) 
    {
        return await getAsync(endpoint, "DecoId/"+id, AuthService.accessToken);
    }

    async getEventByTraiteurIdAsync(id) 
    {
        return await getAsync(endpoint, "TraiteurId/"+id, AuthService.accessToken);
    }
}

export default new EventProService()