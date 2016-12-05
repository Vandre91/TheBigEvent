<template>
  <div class="accueil">

<!--     <div class="fave"></div>-->

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
     require("../../node_modules/bootstrap/dist/js/bootstrap.min.js")
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

.fave {
  width: 70px;
  height: 50px;
  background: url(http://www.cssanimation.rocks/images/posts/steps/twitter_fave.png) no-repeat;
  background-position: 0 0;
  display:inline-block;
  transform : scale(1.5,1.5);
  margin-right:0px;
  margin-bottom:-15px;
}
.fave:hover {
  background-position: -3519px 0;
  transition: background 1s steps(55);
}
 </style>
