import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Message";

class MessageService {
    constructor() {
    }
    async GetMessageByEvent(id1,id2) 
    {
        return await getAsync(endpoint, id1 + id2, AuthService.accessToken);
    }
    async postMessageAsync(infoMessage)
    {
        return await postAsync(endpoint, '', AuthService.accessToken, infoMessage);
    }
}

export default new MessageService()