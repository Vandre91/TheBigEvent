<template>
  <div class="accueil">

    <img class="logo" src="../../img/logo1.gif"></img>
    <h1>The Big Event</h1>
<br /><br /><br />



<div class="col-md-3"></div>
<div class="col-md-6">
    <div class="art-layout-cell layout-item-2">
        <blockquote><span style="font-size: 16px; font-weight: bold;">Web-Events, qu'est-ce que c'est ?</span>
        </blockquote><p><span style="font-size: 16px;">Une plateforme pour créer votre site web évènementiel, gérer votre évènement et proposer une application aux participants.</span></p>
        <blockquote><span style="font-size: 16px; font-weight: bold;">A qui notre plateforme est-elle destinée ?</span>
        </blockquote>
        <p><span style="font-size: 14px;">Aux organisateurs d'évènements ou agences évènementielles souhaitant proposer des fonctionnalités efficaces et performantes pour leurs évènements.</span></p>
        <blockquote><span style="font-weight: bold; font-size: 16px;">Pourquoi utiliser Web-Events ?
        </span></blockquote>
        <p><span style="font-size: 14px;">
          Pour proposer un site web 100% responsive permettant de gérer les invitations, les inscriptions, les paiements, les factures, reçus, inscriptions sur place,... dans un seul et même outil.
          </span></p>
    </div>
</div>
<div class="col-md-12">
  <div id="my_carousel" class="carousel slide">
	  <div class="carousel-inner">
	    <div class="item active">
	      <img src="http://img11.hostingpics.net/pics/6531471.jpg" style="margin:0px auto;"/>
	    </div>   
	    <div class="item">
	      <img src="http://img11.hostingpics.net/pics/3897942.jpg" style="margin:0px auto;"/>
	    </div>
	    <div class="item">
	      <img src="http://img11.hostingpics.net/pics/7450703.jpg" style="margin:0px auto;"/>
	    </div>     
	  </div>
	  <a class="left carousel-control" href="#my_carousel" data-slide="prev">
	    <span class="glyphicon glyphicon-chevron-left"></span>
	  </a>
	  <a class="right carousel-control" href="#my_carousel" data-slide="next">
	    <span class="glyphicon glyphicon-chevron-right"></span>
	  </a>
	</div>
</div>
<br /><br /><br />
</div>
</template>

<script>
export default {
    
}
</script>

<style scoped>

.art-layout-cell {
  border-top-style: solid;
  border-right-style: solid;
  border-bottom-style: solid;
  border-left-style: solid;
  border-top-width: 1px;
  border-right-width: 1px;
  border-bottom-width: 1px;
  border-left-width: 1px;
  border-top-color: #CFD8E2;
  border-right-color: #CFD8E2;
  border-bottom-color: #CFD8E2;
  border-left-color: #CFD8E2;
  color: #303F50;
  padding-right: 10px;
  padding-left: 10px;
  border-radius: 10px;
}

blockquote span {
  background-color: white;
}

blockquote span:before {
    content: "\f10d";
    font-family: 'Fontawesome';
    float: left;
    margin-right: 10px;
}


.accueil {
  top : 50%;
}

h1 {
  font-weight: normal;
  font-size : 40px;
  text-align: center;
  font-weight: 700;
  text-transform: uppercase;
  margin-top: 0;
  margin-bottom: 0;
}

.logo {
  margin-left:auto;
  margin-right:auto;
  height:auto;
  display:block;
  width: 10%;
}

img {
  width: 70%;
}

.carousel-inner p
{
    margin-top : 10px;
    font-size : 20px;
    line-height : 40px;
    text-align : center;
}


 </style>
