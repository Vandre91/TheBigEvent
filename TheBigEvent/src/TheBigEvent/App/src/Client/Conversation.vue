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
<div class="main_section">
   <div class="container">
      <div class="chat_container">
         <div class="col-sm-3 chat_sidebar">
    	 <div class="row">
            <div class="dropdown all_conversation">
               <button class="dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               <i class="fa fa-weixin" aria-hidden="true"></i>
               Event
               <span class="caret pull-right"></span>
               </button>
               <ul class="dropdown-menu" aria-labelledby="dropdownMenu2">
                    <li v-if= "event.content != null" v-for="(e,index) of event.content"><a @click="updateData(index)"> {{ e.nomEvent }} </a>  
			        </li>  
               </ul>
            </div>

            <div class="member_list">
               <ul v-if="allcompagny.tcompagny != ''" class="list-unstyled">
                  <li class="left clearfix">
                     <div class="chat-body clearfix">
                        <div class="header_sec" @click="updateMessaget()">
                           <strong class="primary-font">{{ allcompagny.tcompagny }}  </strong> 
                        </div>
                     </div>
                  </li>
                  <li class="left clearfix">
                     <div class="chat-body clearfix" @click="updateMessaged()">
                        <div class="header_sec">
                           <strong class="primary-font">{{ allcompagny.dcompagny }}</strong> <strong class="pull-right"></strong>
                        </div>
                     </div>
                  </li>
                  <li class="left clearfix">
                     <div class="chat-body clearfix" @click="updateMessages()">
                        <div class="header_sec">
                           <strong class="primary-font">{{ allcompagny.scompagny }}</strong> <strong class="pull-right"></strong>
                        </div>
                     </div>
                  </li>
               </ul>
            </div></div>
         </div>
         <!--chat_sidebar-->
		 
		 
         <div class="col-sm-9 message_section">
		 <div class="row">
         <!--new_message_head-->
		 
		 <div class="chat_area">
		 <ul class="list-unstyled">
       <template v-if= "message.content != null" v-for="m of message.content">

            <template v-if="userId === m.userId1">
                <li class="left clearfix"><span class="chat-img pull-right">
                    <img src="http://placehold.it/50/FA6F57/fff&text=ME" alt="User Avatar" class="img-circle" />
                </span>
                    <div class="chat-body clearfix">
                        <div class="header">
                            <strong class="primary-font pull-right"></strong> <small class="pull-right text-muted">
                        </div>
                        <p class="pull-right text-muted">
                            {{ m.text }}
                        </p>
                    </div>
                </li>
            </template>

            <template v-else>
                <li class="left clearfix"><span class="chat-img pull-left">
                        <img src="http://placehold.it/50/55C1E7/fff&text=U" alt="User Avatar" class="img-circle" />
                    </span>
                        <div class="chat-body clearfix">
                            <div class="header">
                                <strong class="primary-font"></strong> <small class="pull-right text-muted">
                            </div>
                            <p class="pull-left text-muted">
                                {{ m.text }}
                            </p>
                        </div>
                    </li>
            </template>

         </template>
          </ul>
		 </div>
         <!--chat_area-->

          <div class="message_write">
		 <div class="clearfix"></div>
         </br>
         </br>
		 <div class="panel-footer">
                    <div class="input-group">
                        <input id="btn-input" type="text" class="form-control input-sm" placeholder="Type your message here..." />
                        <span class="input-group-btn">
                            <button @click="AddMessage()"class="btn btn-warning btn-sm" id="btn-chat" type="submit">
                                Send</button>
                        </span>
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
            userId : null,
            userIdt : null,
            userIdd : null,
            userIds : null,
            allcompagny: {
                tcompagny : "",
                dcompagny : "",
                scompagny : ""
            },
            infoMessage: {
                user1 : "",
                user2 : "",
                text : ""
            }
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
        },
        loadTraiteur: async function() {
            var e = await TraiteurService.getTraiteurIdAsync(this.userId);
            this.traiteur = e;
        },
        loadDeco: async function() {
            var e = await DecoService.getDecoIdAsync(this.userId);
            this.deco = e;
        },
        loadSalle: async function() {
            var e = await SalleService.getSalleIdAsync(this.userId);
            this.salle = e;
        },
        updateData(i){
            this.allcompagny.tcompagny = this.traiteur.content[i].compagny;
            this.allcompagny.dcompagny = this.deco.content[i].compagny;
            this.allcompagny.scompagny = this.salle.content[i].compagny;

            this.userIdd = this.deco.content[i].userId;
            this.userIds = this.salle.content[i].userId;
            this.userIdt = this.traiteur.content[i].userId;
        },
        updateMessaget: async function() {
            var e = await MessageService.getMessageIdAsync(this.userId,this.userIdt);
            this.message = e;
            this.infoMessage.user2 = this.userIdt;
        },
        updateMessaged: async function() {
            var e = await MessageService.getMessageIdAsync(this.userId,this.userIdd);
            this.message = e;
            this.infoMessage.user2 = this.userIdd;
        },
        updateMessages: async function() {
            var e = await MessageService.getMessageIdAsync(this.userId,this.userIds);
            this.message = e;
            this.infoMessage.user2 = this.userIds;
            
        },
        AddMessage: async function() {
            var val = document.getElementById("btn-input").value;
            this.infoMessage.user1 = this.userId; 
            this.infoMessage.text = val;
            await MessageService.addMessageAsync(this.infoMessage);
            document.getElementById("btn-input").value = "";
        }
    }
}
</script>

