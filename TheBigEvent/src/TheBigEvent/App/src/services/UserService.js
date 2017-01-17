import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/req'
import AuthService from './auth'

const endpoint = "/api/user";

class UserService {
    constructor() {
    }

//  On récupère les informations d'un utilisateur (celui qui est co)
    async getUserAsync(email)
    {
        return await getAsync(endpoint, email, AuthService.accessToken);
    }
    async postUserAsync(model)
    {
        return await postAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
    async putUserAsync(model)
    {
        return await putAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
// On récupère les informations des différents fournisseurs
    async getTraiteurAsync(Id)
    {
        return await getAsync(endpoint, Id, AuthService.accessToken);
    }

    async getDecoAsync(Id)
    {
        return await getAsync(endpoint, Id, AuthService.accessToken);
    }

    async getSalleAsync(Id)
    {
        return await getAsync(endpoint, Id, AuthService.accessToken);
    }

// On permet de modifier tout les informations des fournisseurs 
    async updateTraiteurAsync(model) {
        return await putAsync(endpoint, model.Id, AuthService.accessToken, model);
    }

    async updateDecoAsync(model) {
        return await putAsync(endpoint, model.Id, AuthService.accessToken, model);
    }

    async updateSalleAsync(model) {
        return await putAsync(endpoint, model.Id, AuthService.accessToken, model);
    }

// Permet de modifier les informations de l'utilisateur ou du compte
    async updateUserAsync(model) {
        return await putAsync(endpoint, model.userId, AuthService.accessToken, model);
    }
// Permet de supprimer le compte utilisateur
    async deleteUserAsync(Id) {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }
}

export default new UserService()