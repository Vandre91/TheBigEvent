<template>
  <div class="accueil">

    <img class="logo" src="../../img/logo1.gif"></img>
    <h1>The Big Event</h1>
<br /><br /><br />
<div id="my_carousel" class="carousel slide">
	  <div class="carousel-inner">
	    <div class="item active">
	      <img src="../../img/1.jpg" style="margin:0px auto;"/>
	    </div>   
	    <div class="item">
	      <img src="../../img/2.jpg" style="margin:0px auto;"/>
	    </div>
	    <div class="item">
	      <img src="../../img/3.jpg" style="margin:0px auto;"/>
	    </div>     
	  </div>
	  <a class="left carousel-control" href="#my_carousel" data-slide="prev">
	    <span class="glyphicon glyphicon-chevron-left"></span>
	  </a>
	  <a class="right carousel-control" href="#my_carousel" data-slide="next">
	    <span class="glyphicon glyphicon-chevron-right"></span>
	  </a>
	</div>

<br /><br /><br />
</div>
</template>

<script>
export default {
    
}
</script>

<style scoped>

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
