<template>
  <div id="app">
<!--<pulse-loader :loading="loading" :color="color" :size="size"></pulse-loader>-->


    <router-view></router-view>

  </div>
</template>


<script>
import 'bootstrap'
import $ from 'jquery'
/*import PulseLoader from 'vue-spinner/dist/vue-spinner.min.js'*/
</script>

<style>

@import "~bootstrap/dist/css/bootstrap.min.css";
@import "~font-awesome/css/font-awesome.css";


/*
.spinner-list {
  display: -webkit-flex;
  display: flex;

  -webkit-flex-flow: row wrap;
          flex-flow: row wrap;
  
  width: 200px;
  height: 200px;
 
}*/
</style>