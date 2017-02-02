<template>

<div class="container">
  <div id="1" class="off">
    <div id="snoAlertBox" class="alert alert-success" data-alert="alert">
        <strong>Succès ! </strong> {{ message }}</div>
  </div>
  <div id="2" class="off">
    <div id="snoAlertBox2" class="alert alert-danger" data-alert="alert">
        <strong>Action refusé ! </strong> {{ message }}</div>
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
          <label class="col-lg-3 control-label">Ville: </label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.city" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Téléphone (+33):</label>
          <div class="col-lg-8">
            <input class="form-control" v-model="model.tel" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label"></label>
          <div class="col-md-8">
            <input class="btn btn-primary" value="Enregistrer" type="submit">
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
            <input name ="Save" class="btn btn-primary" value="Enregistrer" type="submit">
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
        email: null,
        newPass: null,
        confirmNewPass: null,
        message:null,
        eventT : [
            {eventId: null},
            {traiteurId: null},
            {validationT: null}
        ],
        eventD : [
            {eventId: null},
            {decoId: null},
            {validationD: null}
        ],
        eventS : [
            {eventId: null},
            {salleId: null},
            {validationS: null}
        ]
       }
  	},
    mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
        },
    methods: {
            loadModelUser: async function(email) {
              this.model = await UserService.getUserAsync(this.email);
              this.model = this.model.content;
              this.eventS = await EventService.getEventbyidPS(this.model.userId);
              this.eventS = this.eventS.content;
              this.eventD = await EventService.getEventbyidPD(this.model.userId);
              this.eventD = this.eventD.content;
              this.eventT = await EventService.getEventbyidPT(this.model.userId);
              this.eventT = this.eventT.content;
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
                  this.message = "Les modifications ont bien été apporté."
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
                this.model = await UserService.getUserAsync(email);
                this.model = this.model.content;
                this.message = "Les modifications ont bien été apporté."
                document.getElementById('1').className = 'on';
                window.setTimeout(function() {
                document.getElementById('1').className = 'off';
                }, 4000);
              }
            },
            async deleteAccount(){
              var i = 0;
              for (i = 0; i < this.eventT.length; i++)
              {
                    if (this.eventT[i].validationT == 1) 
                    {
                        this.message = "Votre Traiteur est réservé à un événement. "
                        document.getElementById('2').className = 'on';
                        window.setTimeout(function() {
                        document.getElementById('2').className = 'off';
                        }, 4000);
                        return;
                    }
              }
              for (i = 0; i < this.eventD.length; i++)
              {
                  if (this.eventD[i].validationD == 1)
                  {
                      this.message = "Votre décorateur est réservé à un événement."
                      document.getElementById('2').className = 'on';
                      window.setTimeout(function() {
                      document.getElementById('2').className = 'off';
                      }, 4000);
                      return;
                  }
              }
              for (i = 0; i < this.eventS.length; i++)
              {
                  if (this.eventS[i].validationS == 1)
                  {
                      this.message = "Votre salle est réservé à un événement."
                      document.getElementById('2').className = 'on';
                      window.setTimeout(function() {
                      document.getElementById('2').className = 'off'; 
                      }, 4000);
                      return;
                  }
              }
              var confirme = confirm("Vous êtes sur le point de supprimer votre compte. Êtes-vous sûr ?");
              if(confirme != false)
              {
                for (i = 0; i < this.eventS.length; i++)
                  await EventService.UpdateSalleIdbynull(this.eventS[i].eventId);
                for (i = 0; i < this.eventD.length; i++)
                  await EventService.UpdateDecoIdbynull(this.eventD[i].eventId);
                for (i = 0; i < this.eventT.length; i++)
                  await EventService.UpdateTraiteurIdbynull(this.eventT[i].eventId);
              }

              var model_salle = await UserService.getsallebyid(this.model.userId);
              model_salle = model_salle.content;


              var model_deco = await UserService.getdecobyid(this.model.userId);
              model_deco = model_deco.content;


              var model_traiteur = await UserService.getTraiteurAsync(this.model.userId);
              model_traiteur = model_traiteur.content;

                await UserService.deleteTraiteur(model_traiteur.traiteurId);
                for (i = 0; i < model_salle.length; i++)
                  await UserService.deleteSalle(model_salle[i].salleId);
                for (i = 0; i < model_deco.length; i++)
                  await UserService.deleteDeco(model_deco[i].decoId);
                await UserService.deleteUserAsync(this.model.userId);
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
