import { getAsync, postAsync, putAsync, deleteAsync, getAsyncSelect } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/BigSelecte";

class BigSelectService {
    constructor() {
    }

    async createDoodleAsync(model) 
    {
        return await postAsync(endpoint, 'createDoodle/', AuthService.accessToken, model);
    }

    async addDateAsync(model) 
    {
        return await postAsync(endpoint, 'addDate/', AuthService.accessToken, model);
    }

    async addGuestAsync(model) 
    {
        return await postAsync(endpoint, 'addGuest/', AuthService.accessToken, model);
    }





}

export default new BigSelectService()