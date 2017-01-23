<template>
     <div class="tab-pane" role="tabpanel" id="step2">
              <h3>Traiteur</h3>
              <p>Choisissez votre traiteur</p>

                <div class="container" id="step2">
                    <div class="list-group">

    			<a class="list-group-item" v-for="models in model">
                <form >
                    <template>
                        <div class="media">
                            <div class="checkbox pull-right">
                                <label>
                                    <input type="radio" :value="models.traiteurId" v-model="id_traiteur_new">				
                                </label>
                            </div>
                            <div class="pull-left">
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading" style="text-decoration:underline;" ><strong>{{models.nom}}</strong></h4>
                                <strong> Compagnie</strong> : <p>{{models.compagny}}</p>
                                <strong>Description</strong> : <p>{{models.descriptions}}</p>
                                <strong>Ville</strong> <p v-if="models.city != null">{{models.city}}</p>
                                <p v-else>Non indiqué </p>
                            </div>
                            <br>
                        </div>
                    </template>
                </form>
    			</a>			

			</div>
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
    props:["idTraiteur"],
    data(){
        return {
            model: null,
            id_traiteur_new: this.idTraiteur
        }
    },
    mounted(){
        this.loadData()
    },
    methods:{
        async loadData(){
            this.model = await EventService.selectGetAsync("Traiteur")
            this.model = this.model.content

        },
        nextStep(){
            this.$emit('nextStep', {method: "traiteur", id_traiteur: this.id_traiteur_new})
        }
    }
}
</script>

<style scoped>
strong{
    color : seagreen;
}

</style>