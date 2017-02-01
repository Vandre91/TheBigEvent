<template>
<div class="tab-pane" role="tabpanel" id="step6">
    <h3>menu</h3>
    <p>Choisissez votre menu</p>

    <div class="row">
        <form>
        <template v-for="m in model">
            <template v-if=" m.traiteurId === data_idtraiteur">
            <div class="col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading clickable">
                        <h3 class="panel-title">{{m.nom}}</h3>
                        <span class="pull-right "></span>
                    </div>
                    <div class="panel-body">
                    <div class="col-md-6">
                    <div class="checkbox pull-right">
                        <label>
                            <input type="radio" v-on:click="prices(m.prix)" :value="m.menuId" v-model="id_menu_new">			
                        </label>
                    </div>                
                        <h4><strong> Prix approximatif : </strong></h4>{{m.prix}} €
                        <h4><strong> Entrer : </strong></h4>{{m.entrer}}
                        <h4><strong> Plat : </strong></h4>{{m.plat}}
                        <h4><strong> Dessert : </strong></h4>{{m.dessert}}
                        <h4><strong>{{m.cat }}</strong> pour <strong>{{ m.nbPersonnes }}</strong> Personnes</h4>
                        <h4><strong>Compagnie :</strong></h4> {{ m.compagny }}
            </div>
        </div>
        </template>
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
    props:["idTraiteur","idMenu", "prix"],
    data(){
        return {
            model: null,
            id_menu_new: this.idMenu,
            data_idtraiteur: this.idTraiteur,
            _prix: 0,
            price: this.prix,
        }
    },
    mounted(){
        this.loadData()
    },
    methods:{
        async loadData(){
            this.model = await EventService.selectGetAsync("Menu")
            this.model = this.model.content
            console.log(this.model)
        },
        prices(prix)
        {
            this._prix = prix;
        },
        nextStep(){
            this.price = this.price + this._prix;
            this.$emit('nextStep', {method: "menu", id_menu: this.id_menu_new, prix:this.price})
        }
    }
}
</script>

<style scoped>
strong{
    color : seagreen;
}

</style>