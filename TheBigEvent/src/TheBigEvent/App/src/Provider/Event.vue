<template>
<div class="container">
	<div class="row">
    <div class=".col-lg-12 forms">

            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Les évènements</strong></h5>
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
                <tr v-if="event.length == 0">
                    <td colspan="4" style="text-align:center;width:100%;">Il n'y a actuellement aucun Salle.</td>
                </tr>
                <tr v-for="i in event">
                    <td>{{ i.nomEvent }}</td>
                    <td>{{ i.nbPlace }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.localisation }}</td>
<!--                    <td>{{ i.validation }}</td>-->
                    <td align="center">
                        <a @click="deleteSalle(i.salleId)" class="btn btn-danger"><em class="fa fa-trash"></em></a>
                        <a class="btn btn-default"><em class="fa fa-pencil"></em></a>
                    </td>
                </tr>
                </tbody>
                </table>            
              </div>
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
            model: null,
            event : [
                {nomEvent: null},
                {nbInvite: null},
                {prix: null},
                {localisation: null},
                {Validation: null}
            ],
            email: null           
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
            this.event = await EventService.getEventbyid(this.userId);
            this.event = this.event.content;
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