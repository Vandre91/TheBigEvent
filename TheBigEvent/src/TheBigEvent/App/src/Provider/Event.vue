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
                        <th>Nombre de Places</th>
                        <th>Prix</th>
                        <th>Description</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                <tr v-if="model_salle.length == 0">
                    <td colspan="4" style="text-align:center;width:100%;">Il n'y a actuellement aucun Salle.</td>
                </tr>
                <tr v-for="i in model_salle">
                    <td>{{ i.nom }}</td>
                    <td>{{ i.nbPlace }}</td>
                    <td>{{ i.prix }}</td>
                    <td>{{ i.descriptions }}</td>
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
            email: null
        }
  	},
    mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
    },
    methods: {
        loadModelUser: async function(email) {
            this.models = await UserService.getUserAsync(email);
        } 
    }
}
</script>

<style scoped>


 </style>