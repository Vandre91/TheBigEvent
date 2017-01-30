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
// Permet de supprimer le compte utilisateur
    async deleteUserAsync(Id)
    {
        return await deleteAsync(endpoint, Id, AuthService.accessToken);
    }

// Ajouter une prestation    
   async addSalleAsync(model)
    {
        return await postAsync(endpoint, 'salle/' + model.userId, AuthService.accessToken, model);
    }

    async adddecoAsync(model)
    {
        return await postAsync(endpoint, 'deco/' + model.userId, AuthService.accessToken, model);
    }
// Pour le traiteur, on a besoin de savoir si c'est un traiteur ou non, si c'est le cas il peut  crée un Menu
    async getTraiteurAsync(Id)
    {
        return await getAsync(endpoint, 'getTraiteur/' + Id, AuthService.accessToken);        
    }
    async addTraiteurAsync(model)
    {
        return await postAsync(endpoint, 'traiteur/' + model.userId, AuthService.accessToken, model);
    }
    async addMenuAsync(model)
    {
        return await postAsync(endpoint, 'menu/' + model.userId, AuthService.accessToken, model);
    }

// Ici on veut récupèrer toute les informations de tout les prestations pour le fournisseur en question

    async getsallebyid(Id)
    {
        return await getAsync(endpoint, 'getSalle/' + Id, AuthService.accessToken);
    }

    async getdecobyid(Id)
    {
        return await getAsync(endpoint, 'getDeco/' + Id, AuthService.accessToken);
    }

    async getmenubyid(Id)
    {
        return await getAsync(endpoint, 'getMenu/' + Id, AuthService.accessToken);
    }



// Ici on permet la suppression d'une prestation

    async deleteSalle(Id)
    {
        return await deleteAsync(endpoint, 'deleteSalle/' + Id, AuthService.accessToken);
    }

    async deleteDeco(Id)
    {
        return await deleteAsync(endpoint, 'deleteDeco/' + Id, AuthService.accessToken);
    }

    async deleteTraiteur(Id)
    {
        return await deleteAsync(endpoint, 'deleteTraiteur/' + Id, AuthService.accessToken);
    }

    async deleteMenu(Id)
    {
        return await deleteAsync(endpoint, 'deleteMenu/' + Id, AuthService.accessToken);
    }
}

export default new UserService()