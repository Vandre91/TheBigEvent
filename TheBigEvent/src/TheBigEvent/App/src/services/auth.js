class AuthService {
    constructor() {
        this.providers = {};
        this.allowedOrigins = []; 
        this.logoutEndpoint = null;
        this.authenticatedCallbacks = []; 
        this.signedOutCallbacks = [];
        window.addEventListener("message", this.onMessage, false);
    }

    get isConnected() {
        return this.identity != null;
    }

    get accessToken() {
        var identity = this.identity;
        return identity ? identity.bearer.access_token : null;
    }

    isProfessionnal() {
        var identity = this.identity;
        return (identity.isProfessionnal);
    }

    hisEmail() {
        var identity = this.identity;
        return (identity.email);
    }

    login (selectedProvider, authenticatedCallback)
    {
        var provider = this.providers[selectedProvider];
        var popup = window.open(provider.endpoint, "Connexion", "menubar=no, status=no, scrollbars=no, menubar=no, width=600, height=450");
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

    onMessage = (e) => {
        if(this.allowedOrigins.indexOf(e.origin) < 0) return;
        var data = typeof e.data == 'string' ? JSON.parse(e.data) : e.data;
        if(data.type == 'authenticated')
            this.onAuthenticated(data.payload);
        else if(data.type == 'signedOut') this.onSignedOut();
    }
    onAuthenticated = (i) => {
        this.identity = i;
        for(var cb of this.authenticatedCallbacks) {
            cb();
        }
    }

    onSignedOut = () => {
        this.identity = null;
        for(var cb of this.signedOutCallbacks) {
            cb();
        }
    }
    logout = () => {
        var popup = window.open(this.logoutEndpoint, "Déconnexion, à Bientôt ", "menubar=no, status=no, scrollbars=no, menubar=no, width=700, height=600");        
    }
}

export default new AuthService();