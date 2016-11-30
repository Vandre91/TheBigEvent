<template>

<div>

<header>
    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <ul class="nav navbar-nav navbar-left">
                    <li>
                        <router-link to="/"><img src="../img/logo.jpg" style="width:60px"></img></router-link>
                    </li>
                    <li>
                        <a> <router-link to="/Partner">Partenaire</router-link></a>
                    </li>
                    <li>
                        <a> <router-link to="/Galerie">Galerie</router-link></a>
                    </li>
                    <li>
                        <a> <router-link to="/whoarewe"> Qui-sommes-nous ?</router-link></a>
                    </li>
                </ul>
            </div>
            <div class="collapse navbar-collapse sidebar-navbar-collapse">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a class="page-scroll" href="#about">Connexion</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#services">Inscription</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</header>


<router-view></router-view>

<footer>
	<div class="col-3">
	  <div class="contact">
	    <h6 class="smallh6">Nous Contacter</h6><br>

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
	      <li><a href="https://www.facebook.com/mabanque.bnpparibas/">
		  <i class="fa fa-facebook fa-2x"></i></a></li><br>
	      <li><a href="https://www.instagram.com/bnpparibas/">
		  <i class="fa fa-instagram fa-2x"></i></a></li><br>
	      <li><a href="https://twitter.com/bnpparibas?lang=fr">
		  <i class="fa fa-twitter fa-2x"></i></a></li>
	    </ul>
          </div>
	  <div class="apropo">
            <h6 class="smallh6">A propos de nous</h6><br />
	    <p class="psmall">quand t'a rien a dire mais tu parle tout de même car tu veux une bonne note dans ton PI, et la tu continue tu continue tu continue tu continue et au final ta un 15 t'es content</p>
          </div>
	</div>
</footer>
</div>
</template>

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
.navbar-default .nav > li > a:hover,
.navbar-default .nav > li > a:focus:hover {
  color: #F05F40;
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


.navbar-nav li a {
  margin-bottom: 0px;
  padding-bottom: 0px;
  padding-top: 0px;
  line-height: 50px;
  color:#200000
}

</style>