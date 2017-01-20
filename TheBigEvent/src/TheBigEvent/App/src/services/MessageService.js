import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Message";

class MessageService {
    constructor() {
    }
    async getMessageIdAsync(id1,id2) 
        {
            console.log(id1);
            console.log(id2);
            return await getAsync(endpoint, id1 + id2, AuthService.accessToken);
        }

}

export default new MessageService()