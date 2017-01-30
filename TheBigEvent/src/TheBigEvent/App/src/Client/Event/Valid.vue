<template>
<div class="tab-pane" role="tabpanel" id="complete">
    <h3>Valider</h3>
    <p>Vous avez tout compléter</p>


            <div class="panel panel-default panel-table">

              <div class="panel-heading">
                <div class="row">
                    <h5><strong>La date de l'événement : </strong>{{date }}</h5>
                </div>
              </div>
              <div class="panel-heading">
                <div class="row">
                    <h5><strong> Nom de l'événement : </strong>{{model.name}}</h5>
                </div>
              </div>

              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Ville : </strong>{{model.ville}}</h5>
                </div>
              </div>

              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Nombre d'invités : </strong>{{model.NbInvite}}</h5>
                </div>
              </div>


              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Le prix approximatif : </strong>{{model.Prix}} €</h5>
                </div>
              </div>

              <div class="panel-heading">
                <div class="row">
                    <h5><strong>La salle : </strong>{{salle_tmp.nom}}</h5>
                </div>
              </div>
                <div class="media-body">
                    <strong>Prix</strong> : <p>{{salle_tmp.prix}}</p>
                    <strong>Nombre de place</strong> : <p>{{salle_tmp.nbPlace}}</p>
                    <strong>Description</strong> : <p>{{salle_tmp.descriptions}}</p>
                </div>

              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Le traiteur : </strong>{{traiteur_tmp.nom}}</h5>
                </div>
              </div>

                <div class="media-body">
                    <strong> Compagnie</strong> : <p>{{traiteur_tmp.compagny}}</p>
                    <strong>Description</strong> : <p>{{traiteur_tmp.descriptions}}</p>
                    <strong>Ville</strong> <p v-if="traiteur.city != null">{{traiteur_tmp.city}}</p>
                    <p v-else>Non indiqué </p>
                </div>

              <div class="panel-heading">
                <div class="row">
                    <h5><strong>Le deco : </strong>{{deco_tmp.nom}}</h5>
                </div>
              </div>
                <div class="media-body">
                    <strong>Prix approximatif</strong> : <p>{{deco_tmp.prix}}</p>
                    <strong>Description</strong> : <p>{{deco_tmp.descriptions}}</p>
                </div>
            </div>
    <li><button type="button" class="btn btn-primary btn-info-full next-step" @click="nextStep()">Enregistrer et continuer</button></li>
</div>
</template>

<script>
export default {
    props:["all", "traiteur", "deco", "salle"],
    data(){
        return {
            model: this.all,
            traiteur_tmp : this.traiteur,
            deco_tmp : this.deco,
            salle_tmp : this.salle,
            date : ""

        }
    },
    mounted(){
        this.date = this.formatDate(this.model.Dates)
    },
    methods:{
     formatDate (input) {
            if (input != null)
            {
                    var dd = input.getDate();
                    var mm = input.getMonth()+1;
                    var yyyy = input.getFullYear(); 
                    if(dd<10){dd='0'+dd} 
                    if(mm<10){mm='0'+mm} 
                    input = dd + '/' + mm + '/' + yyyy; 
                    return (input);
            }
        },
        nextStep(){
             this.$emit('nextStep', {method: "valid"})

             
        }
    }
}
</script>


<style scoped>
h5 {
    text-align: center;
    font-size: 22px;
}

.media-body{

    text-align: center;
}

</style>