import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Deco";

class DecoService {
    constructor() {
    }
    async getDecoIdAsync(id) 
        {
            return await getAsync(endpoint, id, AuthService.accessToken);
        }

}

export default new DecoService()