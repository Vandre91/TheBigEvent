<template>
<div>
<div class="tab-panel" role="tabpanel" id="complete">
    <h3>Valider</h3>
    <p>Vous avez tout compléter</p>
    <br />
        <div class="panel panel-default panel-table" style="text-align: center">

            <div class="panel-heading">
            <div class="row">
                <h5><strong> Nom du BigSelect : </strong>{{model.nom}}</h5>
            </div>
            </div>

            <div class="panel-heading">
            <div class="row">
                <h5><strong>Ville : </strong>{{model.ville}}</h5>
            </div>
            </div>

            <div class="panel-heading">
            <div v-if="description != null" class="row">
                <h5><strong>Description : </strong>{{description_edit }}</h5>
            </div>
            </div>
        </div>

        <table class="table table-striped table-bordered table-list" style="text-align: center">
            <thead>
            <tr>
                <th>Les dates proposées</th>
            </tr> 
            </thead>
            <tbody>
            <tr v-for="i in date">
                <td>{{ formatDate(i.date) }}</td>
            </tr>
        </tbody>
        </table>            

        <table class="table table-striped table-bordered table-list" style="text-align: center">
            <thead>
            <tr>
                <th>Nom</th>
                <th>Email</th>
            </tr> 
            </thead>
            <tbody>
            <tr v-for="i in invite">
                <td>{{ i.nom }}</td>
                <td>{{ i.mail }}</td>
            </tr>
        </tbody>
        </table>  


    <li><button type="button" class="btn btn-primary btn-info-full next-step" @click="nextStep()">Enregistrer et continuer</button></li>
</div>

</div>
</template>

<script>
import BigSelectService from '../services/BigSelect.js'

export default {
    data() {
        return {
            model : [
            { nom: "" },
            { ville: "" },
            { description: "" }
            ],
            model2: [],
            model3: [],
            code : ""
            }
        },
        mounted: async function()
        {
           this.model =  await BigSelectService.getBigSelect(code)


        },
        methods: {
            formatDate (input)
            {
                if (input != null)
                {
                        input = new Date(input);
                        var dd = input.getDate();
                        var mm = input.getMonth()+1;
                        var yyyy = input.getFullYear(); 
                        if(dd<10){dd='0'+dd} 
                        if(mm<10){mm='0'+mm} 
                        input = dd + '/' + mm + '/' + yyyy; 
                        return (input);
                }
            }
    }
}
</script>

<style scoped>

</style>
