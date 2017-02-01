<template>
<div class="container">
<div class=".col-lg-12 forms">

            <div class="panel panel-default panel-table">
              <div class="panel-heading">


                <div class="row">
                    <h5><strong>Les salles</strong></h5>
                </div>
              </div>
              <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Nombre de Places</th>
                        <th>Prix</th>
                        <th>Description</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                <tr v-if="model_salle.length == 0">
                    <td colspan="4" style="text-align:center;width:100%;">Il n'y a actuellement aucun salle.</td>
                </tr>
                <tr v-for="i in model_salle">
                    <td>{{ i.nom }}</td>
                    <td>{{ i.nbPlace }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.descriptions }}</td>
                    <td align="center">
                        <a @click="deleteSalle(i.salleId)" class="btn btn-danger"><em class="fa fa-trash"></em></a>
                    </td>
                </tr>
                </tbody>
                </table>            
              </div>
            </div>


            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Les Décorateurs</strong></h5>
                </div>
              </div>
              <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Prix</th>
                        <th>Description</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                <tr v-if="model_deco.length == 0">
                    <td colspan="4" style="text-align:center;width:100%;">Il n'y a actuellement aucun décorateur.</td>
                </tr>

                <tr v-for="i in model_deco">
                    <td>{{ i.nom }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.descriptions }}</td>
                    <td align="center">
                        <a @click="deleteDeco(i.decoId)" class="btn btn-danger"><em class="fa fa-trash"></em></a>
                    </td>
                </tr>
                </tbody>
                </table>            
              </div>
            </div>

           <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Le Traiteur</strong></h5>
                </div>
              </div>
            <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Description</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                    <tr v-if="model_traiteur == null">
                        <td colspan="4" style="text-align:center;width:100%;">Il n'y a actuellement aucun traiteur.</td>
                    </tr>
                    <tr v-else>
                        <td>{{ model_traiteur.nom }}</td>
                        <td>{{ model_traiteur.descriptions }}</td>
                        <td align="center">
                            <a @click="deleteTraiteur(model_traiteur.traiteurId)" class="btn btn-danger"><em class="fa fa-trash"></em></a>
                        </td>
                    </tr>
                </tbody>
                </table>            
              </div>
            </div>

           <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Les Menus</strong></h5>
                </div>
              </div>
            <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Entré</th>
                        <th>Plat</th>
                        <th>Dessert</th>
                        <th>Prix</th>
                        <th>Nombre de Personnes</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                    <tr v-if="model_menu.length == 0">
                        <td colspan="4" style="text-align:center;width:100%;">Il n'y a actuellement aucun menu.</td>
                    </tr>
                    <tr v-else v-for="i in model_menu">
                        <td>{{ i.nom }}</td>
                        <td>{{ i.entrer }}</td>
                        <td>{{ i.plat }}</td>
                        <td>{{ i.dessert }}</td>
                        <td>{{ i.prix }}</td>
                        <td>{{ i.nbPersonnes }}</td>
                        <td align="center">
                            <a @click="deleteMenu(i.menuId)" class="btn btn-danger"><em class="fa fa-trash"></em></a>
                        </td>
                    </tr>
                </tbody>
                </table>            
              </div>
            </div>

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
        model_salle: [
           { nom : null },
           { Prix : null },
           { NbPlace : null },
           { salleId : null },
           { Descriptions : null }
        ],
        model_deco: [
           { decoId : null },
           { nom : null },
           { Prix : null },
           { Descriptions : null }
        ],
        model_menu: [
           { menuId : null },
           { nom : null },
           { cat : null },
           { Prix : null },
           { NbPersonnes : null }
        ],
        model_traiteur: [
           { traiteurId : null },
           { nom : null },
           { descriptions : null }
        ],
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
        ],
        eventM : [
            {eventId: null},            
            {menuId: null}
        ],
        user: {},
        email: null
       }
  	},
    mounted() {
            this.email = AuthService.hisEmail();
            this.loadModel(this.email);
        },
    methods: {
            loadModel: async function(email) {
              this.user = await UserService.getUserAsync(email);
              this.user = this.user.content;
              this.model_salle = await UserService.getsallebyid(this.user.userId);
              this.model_salle = this.model_salle.content;
              this.model_deco = await UserService.getdecobyid(this.user.userId);
              this.model_deco = this.model_deco.content;
              this.model_traiteur = await UserService.getTraiteurAsync(this.user.userId);
              this.model_traiteur = this.model_traiteur.content;

                if (this.model_traiteur != null)
                {
                    this.model_menu = await UserService.getmenubyid(this.model_traiteur.traiteurId);
                    this.model_menu = this.model_menu.content;
                }
                else
                  this.model_menu.length = 0;
            },


            deleteSalle: async function(id) {
                var i;
                this.eventS = await EventService.getEventbyidPS(this.user.userId);
                this.eventS = this.eventS.content;

                for (i = 0; i < this.eventS.length; i++) {
                    if (this.eventS[i].validationS == 1) {
                        console.log("votre salle est réservé à un événement. Action refusé");
                        return;
                    }
                }

                for (i = 0; i < this.eventS.length; i++) {                 
                    if (this.eventS[i].salleId == id) {
                        var confirme = confirm("Vous êtes sur le point de supprimer une salle liée à un/des événement/s. Êtes-vous sûr ?");
                        if (confirme == true)
                            i = this.eventS.length;
                        else
                            return;
                    }
                }
                if (confirme == true)
                {
                    for (i = 0; i < this.eventS.length; i++) {                 
                        if (this.eventS[i].salleId == id) {
                            await EventService.UpdateSalleIdbynull(this.eventS[i].eventId);
                        }
                    }
                    await UserService.deleteSalle(id);
                    this.model_salle = await UserService.getsallebyid(this.user.userId);
                    this.model_salle = this.model_salle.content;
                    return;
                }

                var confirme2 = confirm("Vous êtes sur le point de supprimer une salle. Êtes-vous sûr ?");
                if(confirme2 != false)
                {
                  var result = await UserService.deleteSalle(id);
                  if(result != false)
                  {
                        this.model_salle = await UserService.getsallebyid(this.user.userId);
                        this.model_salle = this.model_salle.content;
                  }
                }
            },




            deleteDeco: async function(id) {

                var i;
                this.eventD = await EventService.getEventbyidPD(this.user.userId);
                this.eventD = this.eventD.content;
                for (i = 0; i < this.eventD.length; i++) {
                    if (this.eventD[i].validationD == 1) {                      
                        console.log("votre décorateur est réservé à un événement. Action refusé");
                        return;
                    }
                }

                for (i = 0; i < this.eventD.length; i++) {                 
                    if (this.eventD[i].decoId == id) {
                        var confirme = confirm("Vous êtes sur le point de supprimer un décorateur liée à un/des événement/s. Êtes-vous sûr ?");
                        if (confirme == true)
                            i = this.eventD.length;
                        else
                            return;
                    }
                }
                if (confirme == true)
                {
                    for (i = 0; i < this.eventD.length; i++) {                 
                        if (this.eventD[i].decoId == id) {
                            await EventService.UpdateDecoIdbynull(this.eventD[i].eventId);
                        }
                    }
                    await UserService.deleteDeco(id);
                    this.model_deco = await UserService.getdecobyid(this.user.userId);
                    this.model_deco = this.model_deco.content;
                    return;
                }

                var confirme2 = confirm("Vous êtes sur le point de supprimer un décorateur. Êtes-vous sûr ?");
                if(confirme2 != false)
                {
                  var result = await UserService.deleteDeco(id);
                  if(result != false)
                  {
                        this.model_deco = await UserService.getdecobyid(this.user.userId);
                        this.model_deco = this.model_deco.content;
                  }
                }
            },



            deleteTraiteur: async function(id) {

                var i;
                this.eventT = await EventService.getEventbyidPT(this.user.userId);
                this.eventT = this.eventT.content;
                for (i = 0; i < this.eventT.length; i++) {
                    if (this.eventT[i].validationT == 1) {
                        console.log("votre Traiteur est réservé à un événement. Action refusé")
                        return;
                    }
                }

                for (i = 0; i < this.eventT.length; i++) {                 
                    if (this.eventT[i].traiteurId == id) {
                        var confirme = confirm("Vous êtes sur le point de supprimer un traiteur et menu liée à un/des événement/s. Êtes-vous sûr ?");
                        if (confirme == true)
                            i = this.eventT.length;
                        else
                            return;
                    }
                }
                if (confirme == true)
                {
                    for (i = 0; i < this.eventT.length; i++) {                 
                        if (this.eventT[i].traiteurId == id) {
                            await EventService.UpdateTraiteurIdbynull(this.eventT[i].eventId);
                        }
                    }
                    await UserService.deleteTraiteur(id);

                    this.model_traiteur = await UserService.getTraiteurAsync(this.user.userId);
                    this.model_traiteur = this.model_traiteur.content;

                        if (this.model_traiteur != null)
                        {
                            this.model_menu = await UserService.getmenubyid(this.model_traiteur.traiteurId);
                            this.model_menu = this.model_menu.content;
                        }
                        else
                        this.model_menu.length = 0;
                    return;
                }

                var confirme2 = confirm("Vous êtes sur le point de supprimer tous les menus ainsi que le traiteur. Êtes-vous sûr ?");
                if(confirme2 != false)
                {
                  var result = await UserService.deleteTraiteur(id);
                  if(result != false)
                   {
                        this.model_traiteur = await UserService.getTraiteurAsync(this.user.userId);
                        this.model_traiteur = this.model_traiteur.content;
                        this.model_menu.length = 0;
                    }
                }
            },

            deleteMenu: async function(id) {

            var i;
                this.eventM = await EventService.getEventbyidPM(this.user.userId);
                this.eventM = this.eventM.content;            
                for (i = 0; i < this.eventM.length; i++) {                 
                    if (this.eventM[i].menuId == id) {
                        var confirme = confirm("Vous êtes sur le point de supprimer un menu liée à un/des événement/s. Êtes-vous sûr ?");
                        if (confirme == true)
                            i = this.eventM.length;
                        else
                            return;
                    }
                }

                if (confirme == true)
                {
                    for (i = 0; i < this.eventM.length; i++) {
                        if (this.eventM[i].menuId == id) {
                            await EventService.UpdateMenuIdbynull(this.eventM[i].eventId);
                        }
                    }
                    await UserService.deleteMenu(id);
                    this.model_menu = await UserService.getmenubyid(this.model_traiteur.traiteurId);
                    this.model_menu = this.model_menu.content;
                    return;
                }


                var confirme = confirm("Vous êtes sur le point de supprimer un menu. Êtes-vous sûr ?");
                if(confirme != false)
                {
                  var result = await UserService.deleteMenu(id);
                  if(result != false)
                  {
                    this.model_menu = await UserService.getmenubyid(this.model_traiteur.traiteurId);
                    this.model_menu = this.model_menu.content;
                  }
                }



            }
        }
}
</script>

<style scoped>
h5 {
    text-align: center;
    font-size: 22px;
}

.panel-table .panel-body{
  padding:0;
}

.panel-table .panel-body .table-bordered{
  border-style: none;
  margin:0;
}

.panel-table .panel-body .table-bordered > thead > tr > th {
    text-align:center;
}

.panel-table .panel-body .table-bordered > thead > tr > th:last-of-type,
.panel-table .panel-body .table-bordered > tbody > tr > td:last-of-type {
  border-right: 0px;
  width: 8%;
}

.panel-table .panel-body .table-bordered > thead > tr > th,
.panel-table .panel-body .table-bordered > tbody > tr > td {
text-align: center;
}

.panel-table .panel-body .table-bordered > thead > tr > th:first-of-type,
.panel-table .panel-body .table-bordered > tbody > tr > td:first-of-type {
  border-left: 0px;
}

.panel-table .panel-body .table-bordered > tbody > tr:first-of-type > td{
  text-align:center;
  border-bottom: 0px;
}

.panel-table .panel-body .table-bordered > thead > tr:first-of-type > th{
  text-align:center;
  border-top: 0px;
}

/*
used to vertically center elements, may need modification if you're not using default sizes.
*/
.panel-table .panel-footer .col{
 line-height: 34px;
 height: 34px;
}

.panel-table .panel-heading .col h3{
 line-height: 30px;
 height: 30px;
}

.panel-table .panel-body .table-bordered > tbody > tr > td{
  line-height: 34px;
}





 </style>