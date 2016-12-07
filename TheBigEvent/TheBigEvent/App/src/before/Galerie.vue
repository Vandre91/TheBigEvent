<template>
  <div class="container">
  <div class="row">
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 1" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t1.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 2" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t3.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 3" href="#"><img class="thumbnail img-responsive" src="../../img/deco/d1.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 4" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t2.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 5" href="#"><img class="thumbnail img-responsive" src="../../img/deco/d4.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 6" href="#"><img class="thumbnail img-responsive" src="../../img/deco/d5.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 8" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t4.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 9" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t5.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 10" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t7.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 11" href="#"><img class="thumbnail img-responsive" src="../../img/traiteur/t6.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 12" href="#"><img class="thumbnail img-responsive" src="../../img/deco/d7.jpg" /></a></div>
      <div class="col-lg-3 col-sm-4 col-xs-6"><a title="Image 13" href="#"><img class="thumbnail img-responsive" src="../../img/deco/d8.jpg" /></a></div>
   

  <div tabindex="-1" class="modal fade" id="myModal" role="dialog">
  <div class="modal-dialog">
  <div class="modal-content " >
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
     // require("../../node_modules/bootstrap/dist/js/bootstrap.min.js")
export default {


}

  $(document).ready(function() {
$('.thumbnail').click(function(){
      $('.modal-body').empty();
  	var title = $(this).parent('a').attr("title");
  	$('.modal-title').html(title);
  	$($(this).parents('div').html()).appendTo('.modal-body');
  	$('#myModal').modal({show:true});
});
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.modal-dialog
{
  width: 500px;
}

.modal-content
{
  height:100%;
  width:100%;

}

.thumbnail {margin-bottom:6px;}

</style>
