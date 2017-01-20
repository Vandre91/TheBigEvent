<template>
    <div class="tab-pane" role="tabpanel" id="step3">
    <h3>Décorateur</h3>
    <p>Choisissez votre décorateur</p>
    <div class="container" id="step2">
    <div class="list-group">
                <form>
    			<a href="#" class="list-group-item">
                    <template v-for="models in model">
					<div class="media">
			        	<span class="label label-danger pull-right"></span>
						<div class="checkbox pull-right">
				    		<label>
								<input type="radio" :value="models.decoId" v-model="id_deco_new">				
							</label>
						</div>
						<div class="pull-left">
						</div>
						<div class="media-body">
							<h4 class="media-heading" ></h4>
                            FAKE PRIX
							<p>Marriage</p>
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
    props:["idDeco"],
    data(){
        return {
            model: null,
            id_deco_new: this.idDeco
        }
    },
    mounted(){
        this.loadData()
    },
    methods:{
        async loadData(){
            this.model = await EventService.selectGetAsync("Deco")
            this.model = this.model.content
        },
        nextStep(){
            this.$emit('nextStep', {method: "deco", id_deco: this.id_deco_new})
        }
    }
}
</script>