<template>
<div class="container">
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
import TraiteurService from '../services/TraiteurService.js'
import DecoService from '../services/DecoService.js'
import SalleService from '../services/SalleService.js'
import MessageService from '../services/MessageService.js'
import ConversationService from '../services/ConversationService.js'

export default {
data () {
      return {
            model: null,
            event : [],
            traiteur : [],
            deco : [],
            salle : [],
            message : [],
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
            await this.loadTraiteur();
            await this.loadDeco();
            await this.loadSalle();
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
            var e = await MessageService.GetMessageByEvent(this.userId,this.userIdt);
            this.message = e;
            this.infoMessage.user2 = this.userIdt;
        },
        updateMessaged: async function() {
            var e = await MessageService.GetMessageByEvent(this.userId,this.userIdd);
            this.message = e;
            this.infoMessage.user2 = this.userIdd;
        },
        updateMessages: async function() {
            var e = await MessageService.GetMessageByEvent(this.userId,this.userIds);
            this.message = e;
            this.infoMessage.user2 = this.userIds;
            
        },
        AddMessage: async function() {
            var val = document.getElementById("btn-input").value;
            this.infoMessage.user1 = this.userId; 
            this.infoMessage.text = val;
            await MessageService.postMessageAsync(this.infoMessage);
            document.getElementById("btn-input").value = "";
        }
    }
}
</script>
<style scoped>
#custom-search-input {
  background: #e8e6e7 none repeat scroll 0 0;
  margin: 0;
  padding: 10px;
}
   #custom-search-input .search-query {
   background: #fff none repeat scroll 0 0 !important;
   border-radius: 4px;
   height: 33px;
   margin-bottom: 0;
   padding-left: 7px;
   padding-right: 7px;
   }
   #custom-search-input button {
   background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
   border: 0 none;
   border-radius: 3px;
   color: #666666;
   left: auto;
   margin-bottom: 0;
   margin-top: 7px;
   padding: 2px 5px;
   position: absolute;
   right: 0;
   z-index: 9999;
   }
   .search-query:focus + button {
   z-index: 3;   
   }
   .all_conversation button {
   background: #f5f3f3 none repeat scroll 0 0;
   border: 1px solid #dddddd;
   height: 38px;
   text-align: left;
   width: 100%;
   }
   .all_conversation i {
   background: #e9e7e8 none repeat scroll 0 0;
   border-radius: 100px;
   color: #636363;
   font-size: 17px;
   height: 30px;
   line-height: 30px;
   text-align: center;
   width: 30px;
   }
   .all_conversation .caret {
   bottom: 0;
   margin: auto;
   position: absolute;
   right: 15px;
   top: 0;
   }
   .all_conversation .dropdown-menu {
   background: #f5f3f3 none repeat scroll 0 0;
   border-radius: 0;
   margin-top: 0;
   padding: 0;
   width: 100%;
   }
   .all_conversation ul li {
   border-bottom: 1px solid #dddddd;
   line-height: normal;
   width: 100%;
   }
   .all_conversation ul li a:hover {
   background: #dddddd none repeat scroll 0 0;
   color:#333;
   }
   .all_conversation ul li a {
  color: #333;
  line-height: 30px;
  padding: 3px 20px;
}
   .member_list .chat-body {
   margin-left: 47px;
   margin-top: 0;
   }
   .top_nav {
   overflow: visible;
   }
   .member_list .contact_sec {
   margin-top: 3px;
   }
   .member_list li {
   padding: 6px;
   }
   .member_list ul {
   border: 1px solid #dddddd;
   }
   .chat-img img {
   height: 34px;
   width: 34px;
   }
   .member_list li {
   border-bottom: 1px solid #dddddd;
   padding: 6px;
   }
   .member_list li:last-child {
   border-bottom:none;
   }
   .member_list {
   height: 380px;
   overflow-x: hidden;
   overflow-y: auto;
   }
   .sub_menu_ {
  background: #e8e6e7 none repeat scroll 0 0;
  left: 100%;
  max-width: 233px;
  position: absolute;
  width: 100%;
}
.sub_menu_ {
  background: #f5f3f3 none repeat scroll 0 0;
  border: 1px solid rgba(0, 0, 0, 0.15);
  display: none;
  left: 100%;
  margin-left: 0;
  max-width: 233px;
  position: absolute;
  top: 0;
  width: 100%;
}
.all_conversation ul li:hover .sub_menu_ {
  display: block;
}
.new_message_head button {
  background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
  border: medium none;
}
.new_message_head {
  background: #f5f3f3 none repeat scroll 0 0;
  float: left;
  font-size: 13px;
  font-weight: 600;
  padding: 18px 10px;
  width: 100%;
}
.message_section {
  border: 1px solid #dddddd;
}
.chat_area {
  float: left;
  height: 300px;
  overflow-x: hidden;
  overflow-y: auto;
  width: 100%;
}
.chat_area li {
  padding: 14px 14px 0;
}
.chat_area li .chat-img1 img {
  height: 40px;
  width: 40px;
}
.chat_area .chat-body1 {
  margin-right: 50px;
}
.chat-body1 p {
  background: #fbf9fa none repeat scroll 0 0;
  padding: 10px;
}
.chat_area .admin_chat .chat-body1 {
  margin-left: 0;
  margin-right: 50px;
}
.chat_area li:last-child {
  padding-bottom: 10px;
}
.message_write {
  background: #f5f3f3 none repeat scroll 0 0;
  float: left;
  padding: 15px;
  width: 100%;
}

.message_write textarea.form-control {
  height: 70px;
  padding: 10px;
}
.chat_bottom {
  float: left;
  margin-top: 13px;
  width: 100%;
}
.upload_btn {
  color: #777777;
}
.sub_menu_ > li a, .sub_menu_ > li {
  float: left;
  width:100%;
}
.member_list li:hover {
  background: #428bca none repeat scroll 0 0;
  color: #fff;
  cursor:pointer;
}
</style>
