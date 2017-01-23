<template>
<div class="tab-pane" role="tabpanel" id="step4">
    <h3>Salle</h3>
    <p>Choisissez votre salle</p>

 <div class="container" id="step2">
    <div class="list-group">
        <form>

    			<a v-for="models in model" class="list-group-item">
                    <template>
					<div class="media">
						<div class="checkbox pull-right">
				    		<label>
								<input type="radio" :value="models.salleId" v-model="id_salle_new">				
							</label>
						</div>
						<div class="pull-left">
						</div>
                            <div class="media-body">
                                <h4 class="media-heading" style="text-decoration:underline;" ><strong>{{models.nom}}</strong></h4>
                                <strong>Prix</strong> : <p>{{models.prix}}</p>
                                <strong>Nombre de place</strong> : <p>{{models.nbPlace}}</p>
                                <strong>Description</strong> : <p>{{models.descriptions}}</p>
                            </div>

					</div>					
                    </template>
    			</a>
        </form>
			</div>
    </div>

    <ul class="list-inline pull-right">
        <li><button type="button" class="btn btn-primary btn-info-full next-step" @click="nextStep()">Enregistrer et continuer</button></li>
    </ul>
</div>
</template>

<script>
import AuthService from '../../services/auth.js'
import EventService from '../../services/EventService.js'

export default {
    props:["idSalle"],
    data(){
        return {
            model: null,
            id_salle_new: this.idSalle
        }
    },
    mounted(){
        this.loadData()
    },
    methods:{
        async loadData(){
            this.model = await EventService.selectGetAsync("Salle")
            this.model = this.model.content

        },
        nextStep(){
            this.$emit('nextStep', {method: "salle", id_salle: this.id_salle_new})
        }
    }
}
</script>

<style scoped>
strong{
    color : seagreen;
}

</style>