<template>
<div class="container">
	<div class="row">
		<section>
        <div class="wizard">
            <div class="wizard-inner">
                <div class="connecting-line"></div>
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" :class="maxTypes < 0 ? 'disabled' : ''  + actualTypes == 0 ? 'active' : '' ">
                        <a  role="tab" title="Info" @click="changeTab(0)">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-info-sign"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" :class="maxTypes < 1 ? 'disabled' : ''  + actualTypes == 1 ? 'active' : '' ">
                        <a  role="tab" title="Traiteur" @click="changeTab(1)">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-cutlery"></i>
                            </span>
                        </a>
                    </li>
                     <li role="presentation" :class="maxTypes < 2 ? 'disabled' : '' + actualTypes == 2 ? 'active' : '' ">
                        <a  role="tab" title="Menu" @click="changeTab(2)">
                            <span class="round-tab">
                                <i class="fa fa-hand-o-up"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" :class="maxTypes < 3 ? 'disabled' : '' + actualTypes == 3 ? 'active' : '' ">
                        <a role="tab" title="Décoration" @click="changeTab(3)">
                            <span class="round-tab">
                                <i class="fa fa-star"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" :class="maxTypes < 4 ? 'disabled' : '' + actualTypes == 4 ? 'active' : '' ">
                        <a role="tab" title="Salle" @click="changeTab(4)">
                            <span class="round-tab">
                                <i class="fa fa-map"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" :class="maxTypes < 5 ? 'disabled' : '' + actualTypes == 5 ? 'active' : '' ">
                        <a role="tab" title="Complete" @click="changeTab(5)">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-ok"></i>
                            </span>
                        </a>
                    </li>
                </ul>
            </div>
</div>
<component :is="types[orderTypes[actualTypes]]" v-on:nextStep="updateData" :name="event.name" :ville="event.ville" :idTraiteur="event.id_traiteur" :idMenu="event.id_menu" :idDeco="event.id_deco" :idSalle="event.id_salle"></component>
</section>
</div>
</div>




</template>

<script>
import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
import EventService from '../services/EventService.js'

import Deco from './Event/Deco.vue'
import Info from './Event/Info.vue'
import Menu from './Event/Menu.vue'
import Salle from './Event/Salle.vue'
import Traiteur from './Event/Traiteur.vue'
import Valid from './Event/Valid.vue'

export default {
    
  	data () {
      return {
          types: {
                'deco': Deco,
                'info': Info, 
                'menu': Menu,
                'salle': Salle,
                'traiteur': Traiteur,
                'valid': Valid
            },
            actualTypes: 0,
            maxTypes: 0,
            orderTypes: ['info', 'traiteur', 'menu', 'deco', 'salle', 'valid'],
            models: null,
            email: null,
            event: {
                name: null,
                ville: "paris",
                id_traiteur: null,
                id_menu: null, 
                id_deco: null,
                id_salle: null,
                UserId: null
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
        updateData(data){
            switch(data.method){
                case "info":
                    this.event.name = data.name
                    this.event.ville = data.ville 
                    this.maxTypes = ++this.actualTypes
                break
                case "traiteur":
                    if(data.id_traiteur=== null) return
                    this.event.id_traiteur = data.id_traiteur
                    this.maxTypes = ++this.actualTypes
                break
                case "menu":
                    if(data.id_menu === null) return
                    this.event.id_menu = data.id_menu
                    this.maxTypes = ++this.actualTypes
                break
                case "deco":
                    if(data.id_deco === null) return
                    this.event.id_deco = data.id_deco
                    this.maxTypes = ++this.actualTypes
                break
                case "salle":
                    if(data.id_salle === null) return
                    this.event.id_salle = data.id_salle
                    this.maxTypes = ++this.actualTypes
                break
                case "valid":
                   this.event.UserId = this.models.content.userId
                   this.event.NomEvent = this.event.name
                   this.event.NbInvite = 5
                   this.event.Prix = "5"
                   this.event.MenuId = this.event.id_menu
                   this.event.SalleId = this.event.id_salle
                   this.event.TraiteurId = this.event.id_traiteur
                   this.event.DecoId = this.event.id_deco
                   this.event.Localisation = this.event.ville
                   EventService.createEventAsync(this.event)
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