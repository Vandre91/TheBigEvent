<template>
  <div class="accueil">
    <div id="wrapper">
        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <router-link to="/pro">
                <img src="../../img/logo1.gif" style="width:62px"></img>
                <a style="color:#1E90FF;"><strong> THE BIG EVENT Pro</strong></a>
                </router-link>
            </div>
            <ul class="nav navbar-right top-nav">
                <li class="dropdown">
                    <a href="javascript:void(0)" class="dropbtn" style="color:#228B22;"><i class="fa fa-user"></i> {{ email }}</a>
                    <div class="dropdown-content">
                    <router-link to="/pro/profil" >
                        <a style="color:black;"><i class="fa fa-fw fa-user"></i> Profile</a>
                    </router-link>
                    <router-link to="/logout" >
                        <a style="color:black;"><i class="fa fa-fw fa-power-off"></i> Déconnexion</a>
                    </router-link>
                    </div>
                </li>
            </ul>
            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul  class="nav navbar-nav side-nav">
                    <li v-bind:class="{ active: tab === 1}" v-on:click="tab = 1">
                      <router-link to="/pro">
                        <a ><i class="fa fa-fw fa-dashboard"></i> DashBoard</a>
                      </router-link>
                    </li>
                    <li v-bind:class="{ active: tab === 2}" v-on:click="tab = 2">
                      <router-link to="/pro/add">
                        <a><i class="fa fa-fw fa fa-plus"></i> Ajouter une prestation</a>
                      </router-link>
                    </li>
                    <li v-bind:class="{ active: tab === 3}" v-on:click="tab = 3">
                      <router-link to="/pro/event">
                        <a><i class="fa fa-fw fa-table"></i> Confirmer un évènement</a>
                      </router-link>
                    </li>
                    <li v-bind:class="{ active: tab === 4}" v-on:click="tab = 4">
                      <router-link to="/pro/Conversation">
                        <a><i class="fa fa-fw fa-edit"></i> Conversation</a>
                      </router-link>
                    </li>
                </ul>
            </div>
        </nav>
</div>
<div class="nav1"><router-view></router-view></div>
</div>
</template>

<script>
import AuthService from '../services/auth.js'
export default {
  	data () {
      return {
		tab: 1,
        email: null
       }
	},
     mounted() {
            this.email = AuthService.hisEmail();
        }
}


</script>

<style>

strong{
    color : #337ab7;    
}

.on {
    display: block;
}

.off {
    display: none;
}

/* Top Navigation */

.nav1 {
    margin-left: 5%;
    margin-top: 10%;
}

a {
  color: #9d9d9d;
  text-decoration:none
}

.top-nav {
    padding: 0 15px;
}

.top-nav>li {
    display: inline-block;
}

.top-nav>li>a {
    padding-top: 15px;
    padding-bottom: 15px;
    line-height: 20px;
    color: #999;
}

.top-nav>li>a:hover,
.top-nav>li>a:focus,
.top-nav>.open>a,
.top-nav>.open>a:hover,
.top-nav>.open>a:focus {
    color: #fff;
    background-color: #000;
}

.top-nav>.open>.dropdown-menu {
    float: left;
    position: absolute;
    margin-top: 0;
    border: 1px solid rgba(0,0,0,.15);
    border-top-left-radius: 0;
    border-top-right-radius: 0;
    background-color: #fff;
    -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);
    box-shadow: 0 6px 12px rgba(0,0,0,.175);
}

.top-nav>.open>.dropdown-menu>li>a {
    white-space: normal;
}

ul.message-dropdown {
    padding: 0;
    max-height: 250px;
    overflow-x: hidden;
    overflow-y: auto;
}

li.message-preview {
    width: 275px;
    border-bottom: 1px solid rgba(0,0,0,.15);
}

li.message-preview>a {
    padding-top: 15px;
    padding-bottom: 15px;
}

li.message-footer {
    margin: 5px 0;
}

ul.alert-dropdown {
    width: 200px;
}
/* Side Navigation */

@media(min-width:768px) {

.nav1 {
    margin-left: 16%;
    margin-top: 5%;
}

    .side-nav {
        position: fixed;
        top: 51px;
        left: 225px;
        width: 225px;
        margin-left: -225px;
        border: none;
        border-radius: 0;
        overflow-y: auto;
        background-color: #222;
        bottom: 0;
        overflow-x: hidden;
        padding-bottom: 40px;
    }

    .side-nav>li>a {
        width: 225px;
    }

    .side-nav li a:hover,
    .side-nav li a:focus {
        outline: none;
        background-color: #000 !important;
    }
}

.side-nav>li>ul {
    padding: 0;
}

.side-nav>li>ul>li>a {
    display: block;
    padding: 10px 15px 10px 38px;
    text-decoration: none;
    color: #999;
}

.side-nav>li>ul>li>a:hover {
    color: #fff;
}

li.dropdown {
    display: inline-block;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f9f9f9;
    min-width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    text-align: left;
}

.dropdown-content a:hover {background-color: #f1f1f1}

.dropdown:hover .dropdown-content {
    display: block;
}

 </style>
