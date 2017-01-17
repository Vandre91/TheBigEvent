<template>

<div class="container">

<div class="col-lg-6 col-md-6">
    <h1>Vos réservations</h1>
    <div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>Nom de votre réservations</th>
                <th>Lieu</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="e of event.content">
                <td>{{ e.nomEvent }}</td>
                <td>{{ e.localisation }}</td>
            </tr>
        </tbody>
    </table>
    </div>
</div>


<div class="col-lg-6 col-md-6">
    <div class="widget">
    <div class="widget-header">
        <h1>Raccourcis</h1>
    </div>
    <!-- /widget-header -->
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
        <!-- /shortcuts --> 
    </div>
    <!-- /widget-content --> 
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
            this.event = e;
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
	width: 22.50%;
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


 </style>
