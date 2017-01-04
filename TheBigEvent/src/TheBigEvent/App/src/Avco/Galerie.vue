<template>
  <div class="container">
  <div class="row">
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Suchi crevette !" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t1.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Gâteau de mariage" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t3.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Salle de fête" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/deco/d1.jpg" />
          </a>
          </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Dessert au chocolat" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t2.jpg" />
          </a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Salle de mariage (en plein air !)" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/deco/d4.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Salle de mariage" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/deco/d5.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Des petits fours" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t4.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Le Thonmate (tomate au thon)" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t5.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Le Fourré au blanc" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t7.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Appétissant !" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/traiteur/t6.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="Oui, je le veux !" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/deco/d7.jpg" />
        </a>
      </div>
      <div class="col-lg-3 col-sm-4 col-xs-6">
        <a title="La classe" href="#">
          <img v-on:click="zoom" class="thumbnail img-responsive" src="../../img/deco/d8.jpg" />
        </a>
      </div>
  <div tabindex="-1" class="modal fade" id="myModal" role="dialog">
  <div class="modal-dialog">
  <div class="modal-content">
    <div class="modal-header">
		<button class="close" type="button" data-dismiss="modal">×</button>
		<h3 class="modal-title">Heading</h3>
	</div>
	<div class="modal-body">
		
	</div>
	<div class="modal-footer">
		<button class="btn btn-default" data-dismiss="modal">Close</button>
	</div>
   </div>
  </div>
</div>
  </div>
  </div>
</template>

<script>
    export default {        
        methods: {
            zoom() {
              $('.modal-body').empty();
              var title = $(this).parent('a').attr("title");
              var img = $(this).parent('img').attr("src");

              $('.modal-title').html(title);
//              $('.modal-title').html(img);
              $($(this).parents('div').html()).appendTo('.modal-body');
              $('#myModal').modal({show:true});
            }
        }
    }
</script>

<style scoped>

.modal-dialog
{
  width: 500px;
}

modal-content
{
  height:200px;
}
.thumbnail {margin-bottom:6px;}

</style>
