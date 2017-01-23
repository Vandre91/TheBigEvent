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
}

export default new EventProService()