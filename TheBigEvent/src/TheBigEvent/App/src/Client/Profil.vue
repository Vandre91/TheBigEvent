<template>

<div class="container">
  <h1 class="page-header">Modifier son profil</h1>
<!--  <h1 class="page-header">le profil {{ item }}</h1>-->

  <div class="row">

      <form @submit="onSubmit($event)" class="form-horizontal" role="form">
        <div class="form-group">
          <label class="col-lg-3 control-label">Prénom:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.content.firstName" type="text" required>
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Nom:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.content.lastName" type="text" required>
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">City: </label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.content.city" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Telephone:</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.content.tel" type="text">
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
            <input class="form-control" v-model="model.content.mail" type="email"required>
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
export default {
  	data () {
      return {
        model: {
          content:{
            firstName : null,
            lastName : null,
            city : null,
            tel : null,
            mail : null
          }
        },
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
              console.log(this.model.content.mail);
            },
            onSubmit: async function(e) {
            e.preventDefault();
            var result = null;
            result = await UserService.postUserAsync(this.model);
            if(result != null) this.$router.replace('/Client/board');
            },
            onSubmitPasse: async function(e) {
            e.preventDefault();
            if(this.newPass !== this.confirmNewPass) return 
            this.model.content.Passe = this.newPass
            var result = null;
            result = await UserService.putUserAsync(this.model);
            this.model.content.pass = null
            if(result != null) this.$router.replace('/Client/board');
            },
            async deleteAccount(){
              await UserService.deleteUserAsync(this.model.content.userId);
              this.$router.replace('/');
            }
            
        }
}
</script>

<style>

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
