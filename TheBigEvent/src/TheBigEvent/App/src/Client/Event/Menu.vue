<template>
<div class="tab-pane" role="tabpanel" id="step6">
    <h3>menu</h3>
    <p>Choisissez votre menu</p>

    <div class="row">
        <form>
        <template v-for="models in model">
            <div class="col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading clickable">
                        <h3 class="panel-title">{{models.nom}}</h3>
                        <span class="pull-right "></span>
                    </div>
                    <div class="panel-body">
                    <div class="col-md-6">
                    <div class="checkbox pull-right">
                        <label>
                            <input type="radio" :value="models.menuId" v-model="id_menu_new">			
                        </label>
                    </div>                
                        <h4><strong> Prix approximatif : </strong></h4>{{models.prix}} €
                        <h4><strong> Catégorie : </strong></h4>{{models.cat}}
                        <h4><strong>{{models.cat }}</strong> pour <strong>{{ models.nbPersonnes }}</strong> Personnes</h4>
                        <h4><strong>Compagnie :</strong></h4> {{ models.compagny }}
            </div>
        </div>
        </template>
        </form>
    </div>

<ul class="list-inline pull-right">
<li><button type="button" class="btn btn-primary next-step" @click="nextStep()">Enregistrer et continuer</button></li>
</ul>
</div>

</template>

<script>
import AuthService from '../../services/auth.js'
import EventService from '../../services/EventService.js'

export default {
    props:["idMenu"],
    data(){
        return {
            model: null,
            id_menu_new: this.idMenu
        }
    },
    mounted(){
        this.loadData()
    },
    methods:{
        async loadData(){
            this.model = await EventService.selectGetAsync("Menu")
            this.model = this.model.content

        },
        nextStep(){
            this.$emit('nextStep', {method: "menu", id_menu: this.id_menu_new})
        }
    }
}
</script>

<style>
strong{
    color : seagreen;
}

</style>