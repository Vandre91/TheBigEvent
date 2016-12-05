<template>
  <div class="accueil">

<!--     <div class="fave"></div>-->

    <img src="../../img/logo1.gif"></img>
    <h1>The Big Event</h1>

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

</div>
</template>

<script>
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.accueil {
  top : 50%;
  margin-top: 50px;
    padding-bottom:50px;
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

img {
  margin-top: 50px;
  margin-left:auto;
  margin-right:auto;
  height:auto;
  display:block;
  width: 20%;
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
