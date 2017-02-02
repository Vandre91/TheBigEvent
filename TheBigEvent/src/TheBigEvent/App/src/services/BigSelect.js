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

    async getInvitecode(code)
    {
        return await getAsync(endpoint, 'getInvitecode/' + code, AuthService.accessToken);
    }
    
    async getInvitebycode(code)
    {
        return await getAsync(endpoint, 'getInviteSelect/' + code, AuthService.accessToken);
    }

    async getBigSelect(id)
    {
        return await getAsync(endpoint, 'getBigSelect/' + id, AuthService.accessToken);
    }

    async getDatebyid(id)
    {
        return await getAsync(endpoint, 'getDate/' + id, AuthService.accessToken);
    }
    
    async getallbyinviteid(id)
    {
        return await getAsync(endpoint, 'getAllInvite/' + id, AuthService.accessToken);
    }

    async confirmBigSelect(model)
    {
        return await postAsync(endpoint, 'confirmBigSelect/', AuthService.accessToken, model);
    }
}

export default new BigSelectService()