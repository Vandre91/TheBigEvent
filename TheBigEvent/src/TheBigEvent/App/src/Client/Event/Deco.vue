<template>
    <div class="tab-pane" role="tabpanel" id="step3">
    <h3>Décorateur</h3>
    <p>Choisissez votre décorateur</p>
    <div class="container" id="step2">
    <div class="list-group">

   			<a class="list-group-item" v-for="models in model">
                <form>
                    <template>
					<div class="media">
			        	<span class="label label-danger pull-right"></span>
						<div class="checkbox pull-right">
				    		<label>
								<input id="checkbox2" type="radio" v-on:click="prices(models.prix)" :value="models.decoId" v-model="id_deco_new">				
							</label>
						</div>
						<div class="pull-left">
						</div>
                            <div class="media-body">
                                <h4 class="media-heading" style="text-decoration:underline;" ><strong>{{models.nom}}</strong></h4>
                                <strong>Prix approximatif</strong> : <p>{{models.prix}}</p>
                                <strong>Description</strong> : <p>{{models.descriptions}}</p>
                            </div>

					    </div>					
                    </template>
                  </form>
    	      </a>				
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
    props:["idDeco", "prix", "deco"],
    data(){
        return {
            model: null,
            id_deco_new: this.idDeco,
            _prix: 0,
            price: this.prix,
            model2: this.deco
        }
    },
    mounted(){
        this.loadData()
    },
    updated()    
    {
        document.getElementById("checkbox2").checked = false;
    },        
    methods:{
        async loadData(){
            this.model = await EventService.selectGetAsync("Deco")
            this.model = this.model.content

        },
        prices(prix)
        {
            this._prix = prix;
        },
        nextStep(){
            this.price = this.price + this._prix;
            if (this.model[this.id_deco_new] != null)
                this.model2 = this.model[this.id_deco_new];
            else
                this.model2 = this.model;
            this.$emit('nextStep', {method: "deco", id_deco: this.id_deco_new, prix: this.price, deco: this.model2})
        }
    }
}
</script>

<style scoped>
strong{
    color : seagreen;
}

</style>