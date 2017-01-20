<template>
<div class="container">
<div class=".col-lg-12 forms">

            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Les salles mise en location  {{ model_salle }}</strong></h5>
                </div>
              </div>
              <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Nombre de Place</th>
                        <th>Prix</th>
                        <th>Description</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                    <tr v-for="i in model_salle">

<!--                    <td>{{ i }}</td>
                   <td>{{ nbPlace }}</td>
                    <td>{{ prix }}</td>
                    <td>{{ description }}</td>-->
                    </tr>

                    <td align="center">
                        <a class="btn btn-default"><em class="fa fa-pencil"></em></a>
                        <a class="btn btn-danger"><em class="fa fa-trash"></em></a>
                    </td>

                </tbody>
                </table>            
              </div>
            </div>


            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Les Décorateurs mise en location</strong></h5>
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
                    <tr>
                    <td>John Doe</td>
                    <td>40</td>
                    <td>trop trop bien</td>
                    <td align="center">
                        <a class="btn btn-default"><em class="fa fa-pencil"></em></a>
                        <a class="btn btn-danger"><em class="fa fa-trash"></em></a>
                    </td>
                    </tr>
                </tbody>
                </table>            
              </div>
            </div>


            <div class="panel panel-default panel-table">
              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Le Traiteur et les Menus mise en location</strong></h5>
                </div>
              </div>
            <div class="panel-body">
                <table class="table table-striped table-bordered table-list">
                  <thead>
                    <tr>
                        <th>Nom</th>
                        <th>Catégorique</th>
                        <th>Prix</th>
                        <th>Nombre de Personne</th>
                        <th>Description</th>
                        <th><em class="fa fa-cog"></em></th>
                    </tr> 
                  </thead>
                  <tbody>
                    <tr>
                    <td>Pizza</td>
                    <td>Entré</td>
                    <td>5</td>
                    <td>1</td>
                    <td></td>
                    <td align="center">
                        <a class="btn btn-default"><em class="fa fa-pencil"></em></a>
                        <a class="btn btn-danger"><em class="fa fa-trash"></em></a>
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
export default {
  	data () {
      return {
        model_salle: {
            nom : null,
            Prix : null,
            NbPlace : null,
            SalleId : null,
            Description : null
        },
        model_deco: {
            nom : null,
            Prix : null,
            Description : null
        },
        model_menu: {
            nom : null,
            categorie : null,
            Prix : null,
            NbPersonne : null
        },
        model_traiteur: {
            nom : null,
            descriptions : null,
            prix : null
        },
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
              console.log(this.model_salle);
              this.model_deco = await UserService.getdecobyid(this.user.userId);
              this.model_deco = this.model_deco.content;
              console.log(this.model_deco);

              this.model_traiteur = await UserService.getTraiteurAsync(this.user.userId);
              this.model_traiteur = this.model_traiteur.content;
              console.log(this.model_traiteur);

                if (this.model_traiteur != null)
                {
                    this.model_menu = await UserService.getmenubyid(this.model_traiteur.traiteurId);
                    this.model_menu = this.model_menu.content;
                    console.log(this.model_menu);
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

.panel-table .panel-body .table-bordered > thead > tr > th:first-of-type {
    text-align:center;
}

.panel-table .panel-body .table-bordered > thead > tr > th:last-of-type,
.panel-table .panel-body .table-bordered > tbody > tr > td:last-of-type {
  text-align:center;
  border-right: 0px;
  width: 8%;
}

.panel-table .panel-body .table-bordered > thead > tr > th:first-of-type,
.panel-table .panel-body .table-bordered > tbody > tr > td:first-of-type {
  text-align:center;
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