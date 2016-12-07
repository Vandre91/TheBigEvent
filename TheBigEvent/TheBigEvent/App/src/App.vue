<template>

<div>

<header>
    <nav class="navbar navbar-default" role = "navigation">
        <div class="container-fluid">
            <div class="navbar-header">

            <button type = "button" class = "navbar-toggle" 
                data-toggle = "collapse" data-target = "#mynav">
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
                    <li>
                        <router-link to="/whoarewe"> Qui-sommes-nous ?</router-link>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                   <li>

                         
                        <a data-toggle="modal" data-target=".bd-example-modal-sm" href="#">Connexion</a>
                    
                    <div class="modal fade bd-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <h1 style="text-align:center;">Connexion</h1>
                        <form
                            <label for="email">Adresse e-mail</label>
                            <input type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email" require>

                            <label for="Password">Mot de passe</label>
                            <input type="password" class="form-control" id="Password" placeholder="Password" require>
<button type="submit" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg" float="right" >Valider</button>
                    </div>
                    </div>
                    </div>
                    </form>
                    </li>
                    <li>
                    

                    <a data-toggle="modal" data-target=".bd-example-modal-lm" href="#1">Incription</a>
                                       
                                        <div class="modal fade bd-example-modal-lm" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                        <div class="modal-dialog modal-lm">
                                        <div class="modal-content">
                                            <h1 style="text-align:center;">Inscription</h1>
                                                <label for="email">Adresse e-mail</label>
                                                <input type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email" require>

                                                <label for="Password">Mot de passe</label>
                                                <input type="password" class="form-control" id="Password" placeholder="Password" require>

                                                <label for="Password">Confirmation du mot de passe</label>
                                                <input type="password" class="form-control" id="Password" placeholder="Password" require>
                    <button type="submit" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg" float="right" >Valider</button>
                                        </div>
                                        </div>
                                        </div>
                                        </li>

                </ul>
    </nav>
</header>

<router-view></router-view>

<footer>
	<div class="col-3">
	  <div class="contact">
	    <h6 class="smallh6">Nous Contacter </h6><br>

	    <ul>
        <li><i class="fa fa-map-marker fa-2x"></i></li><br>
        <li>In'Tech</li>
	      <li>74 bis avenue Maurice Thorez</li>
	      <li>94200 IVRY-SUR-SEINE</li><br>
	     
        <li><i class="fa fa-envelope-o fa-2x"></i></li><br>
	      <li>
		 <a style="color:#bbb;" href="mailto:admin-bnpparibas@admin.fr">Envoyer un mail</a>
	      </li>
	    </ul>
	  </div>
	  <div class="social">
            <h6 class="smallh6">Suivez notre actualité</h6><br />
            <ul>
	      <li><a href="https://www.facebook.com/TBigEvent/">
		  <i class="fa fa-facebook fa-2x"></i></a></li><br>
	      <li><a href="https://www.instagram.com/bnpparibas/">
		  <i class="fa fa-instagram fa-2x"></i></a></li><br>
	      <li><a href="https://twitter.com/TBigEvent">
		  <i class="fa fa-twitter fa-2x"></i></a></li>
	    </ul>
          </div>
	  <div class="apropo">
            <h6 class="smallh6">Qui sommes nous ?</h6><br />
	    <p class="psmall">Equipe d'étudiants de semestre 4 IL 
                        <br>Shane, Victor et Sandya
                         <br> Projet informatique d'In'Tech

        </p>
          </div>
	</div>
</footer>
</div>
</template>

<script>
import 'bootstrap'
export default {

}


</script>


<style>
@import "~bootstrap/dist/css/bootstrap.min.css";
@import "~font-awesome/css/font-awesome.css";

body {
  background-image: url('../img/header1.jpg');
  background-repeat: no-repeat;
  background-position: center center;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}

label{
    font-size: 20px;
}

button {
    float: right;
    margin-top:10px;
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
  font-size: 13px;

}

footer {

    background-color: #200000;
    opacity: 0.7;
    vertical-align: center;
    color : #ddd;
    border-top: #aaa solid 5px;
}

.col-3
{
    display: inline-block;
}

.contact, .apropo, .social
{
    float: left;
    width: 33.33%;
    padding-left : 7%;
    padding-right : 7%;
    padding-top : 1%;
    text-align : center;
}

.smallh6
{
    font-size : 20px;
}

.contact ul
{
   margin-right : 37px;
}

 .social ul {
  display: flex;
    margin-left:30px;
}

.fa-instagram, .fa-twitter {
  margin-left:40px;
} 

li
{
    list-style: none;
}

.modal-dialog lm {
    height:70%;
}
.modal-content{
    padding:30px;
    height:100%;
    width:100%;
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


</style>