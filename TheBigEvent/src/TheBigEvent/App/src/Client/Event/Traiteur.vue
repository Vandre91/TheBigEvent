<template>
     <div class="tab-pane" role="tabpanel" id="step2">
              <h3>Traiteur</h3>
              <p>Choisissez votre traiteur</p>

                <div class="container" id="step2">
                    <div class="list-group">

    			<a href="#" class="list-group-item">
                <form>
                    <template v-for="models in model">
                        <div class="media">
                            <span class="label label-danger pull-right">Cheapest</span>
                            <div class="checkbox pull-right">
                                <label>
                                    <input type="radio" :value="models.traiteurId" v-model="id_traiteur_new">				
                                </label>
                            </div>
                            <div class="pull-left">
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading" >{{models.compagny}}</h4>
                                <p>{{models.city}}</p>
                            </div>

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