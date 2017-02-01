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

/*    async codeinvite(code)
    {
        return await postAsync(endpoint, 'codeinvite/', AuthService.accessToken, model);
    }
*/
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

}

export default new BigSelectService()