<template>
 
<div class="container">
	<div class="row form-group">
		<section>
        <div class="col-xs-12">
            <div class="wizard-inner">
            <ul class="nav nav-pills nav-justified thumbnail setup-panel">
                <li role="presentation" :class="maxTypes < 0 ? 'disabled' : ''  + actualTypes == 0 ? 'active' : '' ">
                    <a  role="tab" title="Info" @click="changeTab(0)">
                    <h4 class="list-group-item-heading">Informations</h4>
                    <p class="list-group-item-text">Décrivez votre BigSelect</p>
                </a>
                </li>
                <li role="presentation" :class="maxTypes < 1 ? 'disabled' : ''  + actualTypes == 1 ? 'active' : '' ">
                    <a  role="tab" title="valid" @click="changeTab(1)">
                    <h4 class="list-group-item-heading">Validation</h4>
                    <p class="list-group-item-text">Vérifiez et validez votre BigSelect</p>
                </a>
                </li>
                
                </ul>
            </div>
</div>
<component :is="types[orderTypes[actualTypes]]" v-on:nextStep="updateData" :nom="bigselect.nom" :ville="bigselect.ville" :invite="bigselect.invite" :description="bigselect.description" :date="bigselect.date"></component>

</section>
</div>
</div>

</template>
<script>
import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
import EventService from '../services/EventService.js'
import BigSelectService from '../services/BigSelect.js'

import Info from './BigSelect/Info.vue'
import Valid from './BigSelect/Valid.vue'

export default {
    	data () {
      return {
          types: {
                'info': Info,
                'valid': Valid
            },
            actualTypes: 0,
            maxTypes: 0,
            orderTypes: ['info', 'valid'],
            models: null,
            email: null,
            bigselect:{
                nom: null,
                ville:"paris",
                invite: [],
                date: [],
                description: null
            }
        }
  	},
    mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
    },
    methods: {
        loadModelUser: async function(email) {
            this.models = await UserService.getUserAsync(email);
        },
        changeTab(newTab)
        {
            if(newTab > this.maxTypes) return
            this.actualTypes = newTab
        },
        updateData: async function(data){
            switch(data.method){
                case "info":
                    this.bigselect.nom = data.nom
                    this.bigselect.ville = data.ville 
                    this.bigselect.description = data.description 
                    this.bigselect.date = data.date
                    this.bigselect.invite = data.invite;
                    this.maxTypes = ++this.actualTypes
                break
                 case "valid":
                   this.bigselect.UserId = this.models.content.userId
                   var doodleId = await BigSelectService.createBigSelectAsync(this.bigselect);

                    var i;
                    for (i = 0; i < this.bigselect.invite.length; i++) {
                        this.bigselect.invite[i].BigSelecteId = doodleId.content.bigSelecteId;
                        await BigSelectService.addGuestAsync(this.bigselect.invite[i]);
                    }
                    for (i = 0; i < this.bigselect.date.length; i++) {
                        this.bigselect.date[i].BigSelecteId = doodleId.content.bigSelecteId;
                        await BigSelectService.addDateAsync(this.bigselect.date[i]);
                    }
                   this.$router.replace('/Client/board');
                break

            }
        }
        
    }
 

}

</script>

<style scoped>

.wizard {
    margin: 20px auto;
    background: #fff;
}

.wizard .nav-tabs {
    position: relative;
    margin: 40px auto;
    margin-bottom: 0;
    border-bottom-color: #e0e0e0;
}

.wizard > div.wizard-inner {
    position: relative;
}

.connecting-line {
    height: 2px;
    background: #e0e0e0;
    position: absolute;
    width: 90%;
    margin: 0 auto;
    left: 0;
    right: 0;
    top: 50%;
    z-index: 1;
}

.wizard .nav-tabs > li.active > a, .wizard .nav-tabs > li.active > a:hover, .wizard .nav-tabs > li.active > a:focus {
    color: #555555;
    cursor: default;
    border: 0;
    border-bottom-color: transparent;
}

span.round-tab {
    width: 70px;
    height: 70px;
    line-height: 70px;
    display: inline-block;
    border-radius: 100px;
    background: #fff;
    border: 2px solid #e0e0e0;
    z-index: 2;
    position: absolute;
    left: 0;
    text-align: center;
    font-size: 25px;
}
span.round-tab i{
    color:#555555;
}
.wizard li.active span.round-tab {
    background: #fff;
    border: 2px solid #5bc0de;
    
}
.wizard li.active span.round-tab i{
    color: #5bc0de;
}

span.round-tab:hover {
    color: #333;
    border: 2px solid #333;
}

.wizard .nav-tabs > li {
    width: 15%;
}

.wizard li:after {
    content: " ";
    position: absolute;
    left: 46%;
    opacity: 0;
    margin: 0 auto;
    bottom: 0px;
    border: 5px solid transparent;
    border-bottom-color: #5bc0de;
    transition: 0.1s ease-in-out;
}

.wizard li.active:after {
    content: " ";
    position: absolute;
    left: 46%;
    opacity: 1;
    margin: 0 auto;
    bottom: 0px;
    border: 10px solid transparent;
    border-bottom-color: #5bc0de;
}

.wizard .nav-tabs > li a {
    width: 70px;
    height: 70px;
    margin: 20px auto;
    border-radius: 100%;
    padding: 0;
}

    .wizard .nav-tabs > li a:hover {
        background: transparent;
    }

.wizard .tab-pane {
    position: relative;
    padding-top: 50px;
}

.wizard h3 {
    margin-top: 0;
}

@media( max-width : 585px ) {

    .wizard {
        width: 90%;
        height: auto !important;
    }

    span.round-tab {
        font-size: 16px;
        width: 50px;
        height: 50px;
        line-height: 50px;
    }

    .wizard .nav-tabs > li a {
        width: 50px;
        height: 50px;
        line-height: 50px;
    }

    .wizard li.active:after {
        content: " ";
        position: absolute;
        left: 35%;
    }

}
 </style>