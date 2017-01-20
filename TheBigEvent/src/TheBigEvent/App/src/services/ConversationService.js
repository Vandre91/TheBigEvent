import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Conv";

class ConversationService {
    constructor() {
    }

    async getEventIdAsync(id) 
    {
        return await getAsync(endpoint, id, AuthService.accessToken);
    }
}

export default new ConversationService()