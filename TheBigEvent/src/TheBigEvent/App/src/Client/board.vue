<template>
<div class="container" style="margin:0;width:100%;">

<div class="col-lg-7">
    <h1>Vos réservations</h1>
    <div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>                
                <th>Nom de vos réservations</th>
                <th>Lieu</th>
                <th>Prix approximatif</th>
                <th>Validation du décorateur</th>
                <th>Validation de la salle</th>
                <th>Validation du traiteur</th>
                <th>Supprimer</th>

            </tr>
        </thead>
        <tbody>
            <tr v-for="e of event">
                <td> {{ formatDate(e.dates) }} </td>
                <td>{{ e.nomEvent }}</td>
                <td>{{ e.localisation }}</td>
                <td>{{ e.prix }}</td>

                <td v-if="e.existPD == -1"><a class="btn btn-default"><em class="fa fa-user-times"></em></a></td>
                <td v-else-if="e.validationD == 0"><a class="btn btn-default"><em class="fa fa-check-circle"></em></a></td>
                <td v-else-if="e.validationD == 1"><a class="btn btn-success"><em class="fa fa-check-circle"></em></a></td>

                <td v-if="e.existPS == -1"><a class="btn btn-default"><em class="fa fa-user-times"></em></a></td>
                <td v-else-if="e.validationS == 0"><a class="btn btn-default"><em class="fa fa-check-circle"></em></a></td>
                <td v-else-if="e.validationS == 1"><a class="btn btn-success"><em class="fa fa-check-circle"></em></a></td>

                <td v-if="e.existPT == -1"><a class="btn btn-default"><em class="fa fa-user-times"></em></a></td>
                <td v-else-if="e.validationT == 0"><a class="btn btn-default"><em class="fa fa-check-circle"></em></a></td>
                <td v-else-if="e.validationT == 1"><a class="btn btn-success"><em class="fa fa-check-circle"></em></a></td>
                <td align="center">
                    <a  @click="deleteEvent(e.eventId)" class="btn btn-danger"><em class="fa fa-trash"></em></a>
                </td>
            </tr>
        </tbody>
    </table>
    </div>
</div>


    <div class="col-lg-5" style="background-color:#cecece; border-radius:25px">
        <div class="widget">
            <div class="widget-header"><h1>Raccourcis</h1></div>
            <div class="widget-content">
                <div class="shortcuts">

                    <router-link to="/client/event" class="router">
                    <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-list-alt"></i><span class="shortcut-label"> Créer un évènement </span></a>
                    </router-link>

                    <router-link to="/client/Conversation" class="router">
                    <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-comment"></i><span class="shortcut-label">Discussion avec les fournisseurs</span></a>
                    </router-link>

                    <router-link to="/client/profil" class="router">
                    <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-user"></i><span class="shortcut-label">Modifier<br /> son profil</span></a>
                    </router-link>

                    <a href="mailto:thebigevent@intechinfo.fr" class="shortcut"><i class="shortcut-icon fa fa-tag"></i><span class="shortcut-label"> Envoyer un mail au support</span> </a>

                    <router-link to="/logout" class="router">
                    <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-power-off"></i><span class="shortcut-label"> Se <br /> déconnecter</span> </a>
                    </router-link>
                </div>
            </div>
        </div>
    </div>

</div>
</template>

<script>

import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
import EventService from '../services/EventService.js'
import ConversationService from '../services/ConversationService.js'

export default {
    data () {
      return {
            model: null,
            event : [],
            email: null,
            userId : null
        }
  	},
    async mounted() {
            this.email = AuthService.hisEmail();
            await this.loadModelUser(this.email);
            await this.loadEventId();
    },
    methods: {
        loadModelUser: async function(email) {
            var model = await UserService.getUserAsync(email);
            this.model = model;
            this.userId = this.model.content.userId
        },
        loadEventId: async function() {
            var e = await ConversationService.getEventIdAsync(this.userId);
            this.event = e.content;
        },
        deleteEvent: async function(id) {

            var confirme2 = confirm("Vous êtes sur le point de supprimer un événement. Êtes-vous sûr ?");
            if(confirme2 != false)
            {
                var result = await EventService.deleteEvent(id);
                if(result != false)
                {
                    var e = await ConversationService.getEventIdAsync(this.userId);
                    this.event = e.content;
                }
            }
        },
     formatDate (input) {
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

@import "~bootstrap/dist/css/bootstrap.min.css";
@import "~font-awesome/css/font-awesome.css";

.shortcuts {
	text-align: center;	
}

.shortcuts .shortcut { 
	width: 25.5%;
	display: inline-block;
	padding: 12px 0;
	margin: 0 .9% 1em;
	vertical-align: top;	
	
	text-decoration: none;
	
	background: #f9f6f1;
	
	border-radius: 5px;
}

.shortcuts .shortcut .shortcut-icon {
	margin-top: .25em;
	margin-bottom: .25em;
	
	font-size: 32px;
	color: #545454;
}

.shortcuts .shortcut:hover {
	background: #00ba8b;
}

.shortcuts .shortcut:hover span{
	color: #fff;
}

.shortcuts .shortcut:hover .shortcut-icon {
	color: #fff;
}

.shortcuts .shortcut-label {
	display: block;
	
	font-weight: 400;
	color: #545454;
}

th, td, a {
    text-align:center;
    vertical-align:middle;    
}

.btn {
    float: none;
}

 </style>
