<template>

<div class="container">

  <div id="1" class="off">
    <div id="snoAlertBox" class="alert alert-success" data-alert="alert">
        <strong>Succès ! </strong> {{ message }}</div>
  </div>  
  <h1 class="page-header">Modifier son profil</h1>

  <div class="row">

      <form @submit="onSubmit($event)" class="form-horizontal" role="form">
        <div class="form-group">
          <label class="col-lg-3 control-label">Prénom:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.firstName" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Nom:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.lastName" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">City: </label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.city" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Telephone:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.tel" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label"></label>
          <div class="col-md-8">
            <input class="btn btn-primary" value="Save Changes" type="submit">
          </div>
          </form>
</div>


<h2 class="page-header">Modifier son Compte</h2>
  <div class="row">
    <form @submit="onSubmitPasse($event)" class="form-horizontal" role="form">    
        <div class="form-group">
          <label class="col-lg-3 control-label">Email:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.mail" type="email"required>
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label">Mot de passe:</label>
          <div class="col-md-8">
            <input class="form-control" v-model="newPass" type="password">
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label"> Confirmation du mot de passe:</label>
          <div class="col-md-8">
            <input class="form-control" v-model="confirmNewPass" type="password">
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label"></label>
          <div class="col-md-8">
            <input name ="Save" class="btn btn-primary" value="Save Changes" type="submit">            
            <a class="btn btn-danger" @click="deleteAccount">Supprimer le compte</a>
          </div>
        </div>
        </form>
  </div>
  </div>

</template>

<script>
import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
import EventService from '../services/EventService.js'
import ConversationService from '../services/ConversationService.js'
export default {
  	data () {
      return {
        model: {
            firstName : null,
            lastName : null,
            city : null,
            tel : null,
            mail : null
        },
        message : null,
        email: null,
        newPass: null,
        confirmNewPass: null
       }
  	},
    mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
        },
    methods: {
            loadModelUser: async function(email) {
              this.model = await UserService.getUserAsync(email);
              this.model = this.model.content;
            },
            onSubmit: async function(e) {
            e.preventDefault();
            var result = null;
              if (this.model.tel.length == 0)
                this.model.tel = 0;   
            result = await UserService.postUserAsync(this.model);
            if(result != null)
            {
              this.model = await UserService.getUserAsync(this.email);
              this.model = this.model.content;
              this.message = "Les modifications ont bien été apporté.";
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);
            }
            },
            onSubmitPasse: async function(e) {
            e.preventDefault();
            if(this.newPass !== this.confirmNewPass) return 
            this.model.Passe = this.newPass
            var result = null;
            result = await UserService.putUserAsync(this.model);
            this.model.pass = null
            if(result != null)
            {
              this.model = await UserService.getUserAsync(this.email);
              this.model = this.model.content;
              this.message = "Les modifications ont bien été apporté."
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);              
            }
            },
            async deleteAccount(){

            var model = await UserService.getUserAsync(this.email);
            model = model.content;

            model = await ConversationService.getEventIdAsync(this.model.userId);
            model = model.content;

            var confirme2 = confirm("Vous êtes sur le point de supprimer un compte. Tout vos événements vont êtres supprimer. Êtes-vous sûr ?");
              if(confirme2 != false)
              {
                  var i = 0;
                  while (i != model.length)
                  {
                      var result = await EventService.deleteEvent(model[i].eventId);
                      if(result == false)
                        return;
                        i++;
                  }
                  await UserService.deleteUserAsync(this.model.userId);
                  this.$router.replace('/');             
              }
            }
            
        }
}
</script>

<style scoped>

strong{
    color : #337ab7;    
}

ul.message-dropdown {
    padding: 0;
    max-height: 250px;
    overflow-x: hidden;
    overflow-y: auto;
}

li.message-preview {
    width: 275px;
    border-bottom: 1px solid rgba(0,0,0,.15);
}

li.message-preview>a {
    padding-top: 15px;
    padding-bottom: 15px;
}

li.message-footer {
    margin: 5px 0;
}

ul.alert-dropdown {
    width: 200px;
}
 </style>
