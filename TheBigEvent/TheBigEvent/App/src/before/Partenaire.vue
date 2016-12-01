<template>
  <div class="hello">
    <h2>Nvabar<h2>
    <h1>{{ msg }}</h1>
        <img src="../../img/t1.jpg" class="img-rounded"/>
        <img src="../../img/t3.jpg" class="img-rounded"/>
 
  </div>
</template>

<script>
export default {
  name: 'hello',
  data () {
    return {
      msg: 'Galerie'
    }
  }
}
</script>

<style scoped>
h1, h2 {
  font-weight: normal;
  color: white;
margin-left: 250px;

}

img {
  height:100px;
  weight:100px;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
