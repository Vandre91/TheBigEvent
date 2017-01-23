import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Salle";

class SalleService {
    constructor() {
    }
    async getSalleIdAsync(id) 
        {
            return await getAsync(endpoint, id, AuthService.accessToken);
        }

}

export default new SalleService()