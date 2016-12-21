<template>
  <div id="app">
<<<<<<< HEAD

<header>
    <nav class="navbar navbar-default" role = "navigation">
        <div class="container-fluid">
            <div class="navbar-header">
            <button type = "button" class = "navbar-toggle" data-toggle = "collapse" data-target = "#mynav">
                <span class = "sr-only">Toggle navigation</span>
                <span class = "icon-bar"></span>
                <span class = "icon-bar"></span>
                <span class = "icon-bar"></span>
            </button>
            <a class = "navbar-brand">
                <router-link to="/"><img src="../img/logo.jpg" style="width:55px"></img></router-link>
            </a>
        </div>
        <div class="collapse navbar-collapse" id = "mynav">
            <ul class="nav navbar-nav navbar-left ">
                <li>
                    <router-link to="/Partner">Partenaire</router-link>
                </li>
                <li>
                    <router-link to="/Galerie">Galerie</router-link>
                </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li><a href="#" @click="login('Base')"><span class="glyphicon glyphicon-log-in"></span> Connexion</a></li>
                <li><a href="#" @click="login('Base1')"><span class="glyphicon glyphicon-user"></span> Inscription</a></li>
            </ul>
    </nav>
</header>

<router-view></router-view>

<footer>
	<div class="col-3">
	  <div class="contact">
	    <h3 style="padding-bottom:30px;">Nous Contacter </h3>
	    <ul>
            <li><i class="fa fa-map-marker fa-2x"></i></li><br />
            <li>In'Tech</li>
	        <li>74 bis avenue Maurice Thorez</li>
	        <li>94200 IVRY-SUR-SEINE</li><br />
            <li><i class="fa fa-envelope-o fa-2x"></i></li><br />
            <li><a style="color:#bbb;" href="mailto:admin-bnpparibas@admin.fr">Envoyer un mail</a></li>
	    </ul>
	  </div>
	  <div class="social">
          <h3 style="padding-bottom:30px;">Suivez notre actualité</h3>
            <ul>
                <li><a href="https://www.facebook.com/TBigEvent/">
		        <i class="fa fa-facebook fa-2x"></i></a></li><br>
	            <li><a href="https://www.instagram.com/tbevent/">
		        <i class="fa fa-instagram fa-2x"></i></a></li><br>
	            <li><a href="https://twitter.com/TBigEvent">
		        <i class="fa fa-twitter fa-2x"></i></a></li>
	        </ul>
      </div>
      <div class="apropo">
          <h3 style="padding-bottom:30px;">Qui sommes nous ?</h3>
          <p>Dans le cadre d'un projet de scolarité, nous avions pour but de créer un site évènementiel.</p>
          <p>Notre équipe de semestre 4 en IL est composé de :<br>- Shane DJAFARALY <br>- Victor ANDRE <br>- Sandya MADIONE</p>
      </div>
	</div>
</footer>

  </div>
</template>

<script>
import 'bootstrap'
import AuthService from './services/auth.js'
import Vue from 'vue'
import $ from 'jquery'


    export default {

        created() {
            AuthService.registerAuthenticatedCallback(this.onAuthenticated);
        },
        beforeDestroy() {
            AuthService.removeAuthenticatedCallback(this.onAuthenticated);
        },
        methods: {
            login(provider) {
                    AuthService.login(provider);
            },

            onAuthenticated() {
                 this.$router.replace('/');
            }
        },
    };

=======
    <router-view></router-view>
  </div>
</template>


<script>
import 'bootstrap'
import $ from 'jquery'
>>>>>>> master
</script>

<style>

@import "~bootstrap/dist/css/bootstrap.min.css";
@import "~font-awesome/css/font-awesome.css";
<<<<<<< HEAD

body {
  background-image: url('../img/header1.jpg');
  background-repeat: no-repeat;
  background-position: center center;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}

header {
    padding-bottom:30px;
}

header navbar-nav {
  line-height:200px;
}

.navbar-default {
  background-color: #FFF;
}
.navbar-default .nav > li > a,
.navbar-default .nav > li > a:focus {
  text-transform: uppercase;
  font-weight: 700;
  font-size: 14px;
}

footer {
    background-color: #100000;
    opacity: 0.7;
    color : #ddd;
    border-top: #bbb solid 1px;
}

.col-3 {
    display: inline-block;
    width: 100%;
}

.contact, .apropo, .social {
    float: left;
    width: 33.33%;
    text-align : center;
}

.contact ul {
    padding-right : 10%;
}

 .social ul {
  display: inline-flex;
  padding: 0;
}

.fa-instagram, .fa-twitter {
    padding-left : 70%;
} 

li {
    list-style: none;
}

.modal-content {
    padding:30px;
    height:100%;
}

.navbar-nav li {
  margin-bottom: 0px;
  padding-bottom: 0px;
  padding-top: 0px;
  line-height: 50px;
  color:#200000;
}

.navbar-brand {
padding: 5px;
}

.btn {
    float:right;
    margin-top: 5%;
}
</style>
=======
</style>
>>>>>>> master
