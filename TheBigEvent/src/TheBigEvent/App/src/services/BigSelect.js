import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/BigSelecte";

class BigSelectService {
    constructor() {
    }

    async createBigSelectAsync(model) 
    {
        return await postAsync(endpoint, 'createBigSelect/', AuthService.accessToken, model);
    }

    async addDateAsync(model) 
    {
        return await postAsync(endpoint, 'createDate/', AuthService.accessToken, model);
    }

    async addGuestAsync(model) 
    {
        return await postAsync(endpoint, 'createInvite/', AuthService.accessToken, model);
    }





}

export default new BigSelectService()