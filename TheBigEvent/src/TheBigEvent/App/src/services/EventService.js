import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Event";

class EventService {
    constructor() {
    }

// On crée un évènement

    async createEventAsync(model) 
    {
        return await postAsync(endpoint, 'createEvent/', AuthService.accessToken, model);
    }

// On supprime un évènement

    async deleteEvent(Id)
    {
        return await deleteAsync(endpoint, 'deleteEvent/' + Id, AuthService.accessToken);
    }

    async selectGetAsync(method){
        return await getAsyncSelect(endpoint, method, AuthService.accessToken)
    }

    async getEventbyidPD(id)
    {
        return await getAsyncSelect(endpoint, 'event/deco/' + id, AuthService.accessToken)        
    }
    async getEventbyidPT(id)
    {
        return await getAsyncSelect(endpoint, 'event/traiteur/' + id, AuthService.accessToken)        
    }
    async getEventbyidPS(id)
    {
        return await getAsyncSelect(endpoint,'event/salle/' + id, AuthService.accessToken)        
    }
    async getEventbyidPM(id)
    {
        return await getAsyncSelect(endpoint,'event/menu/' + id, AuthService.accessToken)        
    }

    async validT(model) 
    {
        return await postAsync(endpoint, 'validT', AuthService.accessToken, model);
    }

    async validD(model) 
    {
        return await postAsync(endpoint, 'validD', AuthService.accessToken, model);
    }

    async validS(model) 
    {
        return await postAsync(endpoint, 'validS', AuthService.accessToken, model);
    }


    async UpdateSalleIdbynull(eventId)
    {
        return await postAsync(endpoint, 'UpdateSalleIdbynull/' + eventId, AuthService.accessToken);
    }

    async UpdateTraiteurIdbynull(eventId)
    {
        return await postAsync(endpoint, 'UpdateTraiteurIdbynull/' + eventId, AuthService.accessToken);
    }

    async UpdateDecoIdbynull(eventId)
    {
        return await postAsync(endpoint, 'UpdateDecoIdbynull/' + eventId, AuthService.accessToken);
    }

    async UpdateMenuIdbynull(eventId)
    {
        return await postAsync(endpoint, 'UpdateMenuIdbynull/' + eventId, AuthService.accessToken);
    }


}

export default new EventService()