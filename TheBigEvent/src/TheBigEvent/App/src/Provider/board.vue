<template>

<div class="container">

<div class="col-lg-6 col-md-6">


            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Les événements</strong></h5>
                </div>
              </div>
              <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Nombre d'invité</th>
                        <th>Prix</th>
                        <th>Localisation</th>
                        <th>Validation</th>                        
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                <tr v-if="eventT.length == 0">
                </tr>
                <tr v-for="i in eventT">
                    <td>{{ i.nomEvent }}</td>
                    <td>{{ i.nbPlace }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.localisation }}</td>
                    <td v-if="i.validationT == 0">Non-validé</td>
                    <td v-else="i.validationT == 1">Validé</td>
                    <td v-if="i.validationT == 0" align="center">
                        <a @click="validT(i.validationT, i.eventId)" class="btn  btn-default"><em class="fa fa-check-circle"></em></a>
                    </td>
                    <td v-else="i.validationT == 1" align="center">
                        <a @click="validT(i.validationT, i.eventId)" class="btn btn-success"><em class="fa fa-check-circle"></em></a>
                    </td>

                </tr>

                <tr v-if="eventD.length == 0">
                </tr>
                <tr v-for="i in eventD">
                    <td>{{ i.nomEvent }}</td>
                    <td>{{ i.nbPlace }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.localisation }}</td>
                    <td v-if="i.validationD == 1">Validé</td>
                    <td v-else="i.validationD == 0">Non-validé</td>
                    <td v-if="i.validationD == 0" align="center">
                        <a @click="validD(i.validationD, i.eventId)" class="btn  btn-default"><em class="fa fa-check-circle"></em></a>
                    </td>
                    <td v-else="i.validationD == 1" align="center">
                        <a @click="validD(i.validationD, i.eventId)" class="btn  btn-success"><em class="fa fa-check-circle"></em></a>
                    </td>
                </tr>

                <tr v-if="eventS.length == 0">
                </tr>
                <tr v-for="i in eventS">
                    <td>{{ i.nomEvent }}</td>
                    <td>{{ i.nbPlace }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.localisation }}</td>
                    <td v-if="i.validationS == 1">Validé</td>
                    <td v-else="i.validationS == 0">Non-validé</td>
                    <td v-if="i.validationS == 0" align="center">
                        <a @click="validS(i.validationS, i.eventId)" class="btn btn-default"><em class="fa fa-check-circle"></em></a>
                    </td>
                    <td v-else="i.validationS == 1" align="center">
                        <a @click="validS(i.validationS, i.eventId)" class="btn btn-success"><em class="fa fa-check-circle"></em></a>
                    </td>
                </tr>
                </tbody>
                </table>            
              </div>
            </div>



</div>


<div class="col-lg-6 col-md-6">
    <div class="widget">
    <div class="widget-header">
        <h1>Raccourcis</h1>
    </div>
    <!-- /widget-header -->
    <div class="widget-content">
        <div class="shortcuts">

            <router-link to="/pro/add" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa fa-plus"></i><span class="shortcut-label"> Ajouter une prestation </span></a>
            </router-link>


            <router-link to="/pro/event" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-list-alt"></i><span class="shortcut-label"> Confirmer un évènement </span></a>
            </router-link>

            <router-link to="/pro/Conversation" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-comment"></i><span class="shortcut-label">Discussion avec les clients</span></a>
            </router-link>

            <router-link to="/pro/profil" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-user"></i><span class="shortcut-label">Modifier<br /> son profil</span></a>
            </router-link>

            <a href="mailto:thebigevent@intechinfo.fr" class="shortcut"><i class="shortcut-icon fa fa-tag"></i><span class="shortcut-label"> Envoyer un mail au support</span> </a>

            <router-link to="/logout" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-power-off"></i><span class="shortcut-label"> Se <br /> déconnecter</span> </a>
            </router-link>
    </div>
        <!-- /shortcuts --> 
    </div>
    <!-- /widget-content --> 
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
            model: null,
            eventT : [
                {nomEvent: null},
                {nbInvite: null},
                {prix: null},
                {localisation: null},
                {validationT: null}
            ],
            eventD : [
                {nomEvent: null},
                {nbInvite: null},
                {prix: null},
                {localisation: null},
                {validationD: null}
            ],
            eventS : [
                {nomEvent: null},
                {nbInvite: null},
                {prix: null},
                {localisation: null},
                {validationS: null}
            ],
            email: null,
            model2 : {
                value : null,
                EventId : null

            }
        }
  	},
    async mounted() {
            this.email = AuthService.hisEmail();
            await this.loadModelUser(this.email);
            await this.loadEventId();
    },
    methods: {
        loadModelUser: async function(email) {
            var model = await UserService.getUserAsync(email);
            this.model = model.content;
            this.userId = this.model.userId
        },
        loadEventId: async function() {
            this.eventT = await EventService.getEventbyidPT(this.userId);
            this.eventT = this.eventT.content;
            this.eventD = await EventService.getEventbyidPD(this.userId);
            this.eventD = this.eventD.content;
            this.eventS = await EventService.getEventbyidPS(this.userId);
            this.eventS = this.eventS.content;

        },
        validT: async function(id, eventId){
            if (id == 0)
                id = 1;            
            else
                id = 0;
            this.model2.value = id;
            this.model2.EventId = eventId;
            await EventService.validT(this.model2);
            this.eventT = await EventService.getEventbyidPT(this.userId);
            this.eventT = this.eventT.content;
        },
        validD: async function(id, eventId){
            if (id == 0)
                id = 1;            
            else
                id = 0;
            this.model2.value = id;
            this.model2.EventId = eventId;
            await EventService.validD(this.model2);
            this.eventD = await EventService.getEventbyidPD(this.userId);
            this.eventD = this.eventD.content;
        },
        validS: async function(id, eventId){
            if (id == 0)
                id = 1;            
            else
                id = 0;
            this.model2.value = id;
            this.model2.EventId = eventId;
            await EventService.validS(this.model2);
            this.eventS = await EventService.getEventbyidPS(this.userId);
            this.eventS = this.eventS.content;
        },
        
    }
}
</script>

<style scoped>

.shortcuts {
	text-align: center;	
}

.shortcuts .shortcut { 
	width: 22.50%;
	display: inline-block;
	padding: 12px 0;
	margin: 0 .9% 1em;
	vertical-align: top;	
	
	text-decoration: none;
	
	background: #f9f6f1;
	
	border-radius: 5px;
}

.shortcuts .shortcut .shortcut-icon {
	margin-top: .25em;
	margin-bottom: .25em;
	
	font-size: 32px;
	color: #545454;
}

.shortcuts .shortcut:hover {
	background: #00ba8b;
}

.shortcuts .shortcut:hover span{
	color: #fff;
}

.shortcuts .shortcut:hover .shortcut-icon {
	color: #fff;
}

.shortcuts .shortcut-label {
	display: block;
	
	font-weight: 400;
	color: #545454;
}

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
