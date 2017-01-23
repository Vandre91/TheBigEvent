<template>
<div class="container">

<div class="col-lg-6 col-md-6">
    <h1>Vos Event</h1>
    <div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>Nom de l'Evenement</th>
                <th>Chat</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="e of event.content">
                <td>{{ e.nomEvent }}</td>
                <td>
                    <router-link :to="`/Client/Chat`"><i class="glyphicon glyphicon-comment"></i></router-link>
                </td>
            </tr>
        </tbody>
    </table>
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

