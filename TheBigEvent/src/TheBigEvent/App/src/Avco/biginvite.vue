<template>
<div class="tab-panel" role="tabpanel" id="complete">
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
            <div v-if="model.description != null" class="row">
                <h5><strong>Description : </strong>{{model.description }}</h5>
            </div>
            </div>
        </div>
            <table class="table table-striped table-bordered table-list" style="text-align: center;">
                <thead>
                <tr>
                    <th>Nom</th>
                    <th>Email</th>
                    <th>Dates proposées</th>
                </tr> 
                </thead>
                <tbody>
                    <tr v-for="i in all">
                        <td>{{ i.name }}</td>
                        <td>{{ i.email }}</td>


                        <p v-for="e in i.answers" style="margin:0;">
                       <label @click="confirm(e.dateid, i.guestId, e.state)" v-if="e.state == 1"  class="btn btn-danger" style="float:left;margin:0;">{{ formatDate(e.date) }}</label>
                        <label @click="confirm(e.dateid, i.guestId, e.state)" v-else-if="e.state == 2"  class="btn btn-success" style="float:left;margin:0;">{{ formatDate(e.date) }}</label>
                        <label @click="confirm(e.dateid, i.guestId, e.state)" v-else  class="btn btn-warning" style="float:left;margin:0;">{{ formatDate(e.date) }}</label>
                        </p>
                    </tr>
                </tbody>
            </table>  
</div>
</template>

<script>
import BigSelectService from '../services/BigSelect.js'

export default {
    data() {
        return {
            model : [
            { BigSelecteId: null },
            { nom: "" },
            { ville: "" },
            { description: "" }
            ],
            all: [],
            invite:[],
            code : "",
            }
        },
        mounted: async function()
        {
            this.code = this.$route.params.code;
            this.invite =  await BigSelectService.getInvitebycode(this.code)
            this.invite = this.invite.content;
            if (this.invite != null && this.invite[0] != null)
            {
                this.all = await BigSelectService.getallbyinviteid(this.invite[0].bigSelecteId)
                this.all = this.all.content;
                this.model = await BigSelectService.getBigSelect(this.invite[0].bigSelecteId)
                this.model = this.model.content[0];
            }
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
            },
            confirm: async function(dateid, guestId, state)
            {

                if (state == 1)
                    state = 2;
                else if (state == 2)
                    state = 1;
                else
                    state = 2;
                let tmp = {dateid : dateid, inviteId : guestId, Etat : state};
                await BigSelectService.confirmBigSelect(tmp)
                this.all = await BigSelectService.getallbyinviteid(this.invite[0].bigSelecteId)
                this.all = this.all.content;
                this.model = await BigSelectService.getBigSelect(this.invite[0].bigSelecteId)
                this.model = this.model.content[0];
            }

    }
}
</script>

<style scoped>

</style>
