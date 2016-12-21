class AuthService {
    constructor() {
        this.providers = {}; //méthode de Connexion
        this.allowedOrigins = []; //lien pour la connexion niveau serveur

        this.logoutEndpoint = null;

        this.appRedirect = () => null; //en cas de déconnexion redirection

        this.authenticatedCallbacks = []; //liste des gens  connecté
        this.signedOutCallbacks = []; //les gens inscrit

        window.addEventListener("message", this.onMessage, false);
    }



    login (selectedProvider, authenticatedCallback)
    {
        var provider = this.providers[selectedProvider];
<<<<<<< HEAD
        var popup = window.open(provider.endpoint, "Connexion", "menubar=no, status=no, scrollbars=no, menubar=no, width=700, height=700");
=======
        var popup = window.open(provider.endpoint, "Connexion", "menubar=no, status=no, scrollbars=no, menubar=no, width=600, height=450");
>>>>>>> master
    }
    registerAuthenticatedCallback(cb) {
        this.authenticatedCallbacks.push(cb);
    }

    removeAuthenticatedCallback(cb) {
        this.authenticatedCallbacks.splice(this.authenticatedCallbacks.indexOf(cb), 1);
    }


    registerSignedOutCallback(cb) {
        this.signedOutCallbacks.push(cb);
    }

    removeSignedOutCallback(cb) {
        this.signedOutCallbacks.splice(this.signedOutCallbacks.indexOf(cb), 1);
    }

<<<<<<< HEAD
=======
    onMessage(e) {
        console.log(e);
    }

>>>>>>> master

}
export default new AuthService();