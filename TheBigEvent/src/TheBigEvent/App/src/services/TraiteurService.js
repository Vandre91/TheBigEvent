import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/Traiteur";

class TraiteurService {
    constructor() {
    }
    async getTraiteurIdAsync(id) 
        {
            return await getAsync(endpoint, id, AuthService.accessToken);
        }

}

export default new TraiteurService()