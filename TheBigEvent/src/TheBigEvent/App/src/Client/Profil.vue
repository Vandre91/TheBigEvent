<template>

<div class="container">
  <h1 class="page-header">Modifier son profil</h1>
  <div class="row">


      <form class="form-horizontal" role="form">
        <div class="form-group">
          <label class="col-lg-3 control-label">Prénom:</label>
          <div class="col-lg-8">
            <input class="form-control" value="Sandya" type="text" required>
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Nom:</label>
          <div class="col-lg-8">
            <input class="form-control" value="Madione" type="text" required>
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">City: </label>
          <div class="col-lg-8">
            <input class="form-control" value="" type="text">
          </div>
        </div>
        <div class="form-group">
          <label class="col-lg-3 control-label">Telephone:</label>
          <div class="col-lg-8">
            <input class="form-control" value="" type="text">
          </div>
        </div>

        <div class="form-group">
          <label class="col-md-3 control-label"></label>
          <div class="col-md-8">
            <input class="btn btn-primary" value="Save Changes" type="button">
          </div>
</div>


<h2 class="page-header">Modifier son Compte</h2>
  <div class="row">       
        <div class="form-group">
          <label class="col-lg-3 control-label">Email:</label>
          <div class="col-lg-8">
            <input class="form-control" value="Madione@intechinfo.fr" type="text"required>
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label">Mot de passe:</label>
          <div class="col-md-8">
            <input class="form-control" value="11111122333" type="password">
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label"> Confirmation du mot de passe:</label>
          <div class="col-md-8">
            <input class="form-control" value="11111122333" type="password">
          </div>
        </div>
        <div class="form-group">
          <label class="col-md-3 control-label"></label>
          <div class="col-md-8">
            <input class="btn btn-primary" value="Save Changes" type="button">
            
          <input class="btn btn-danger" value="Supprimer le compte" type="button">

          </div>

        </div>
  </div>
  </div>
</template>

<script>
export default {
    
}
</script>

<style>

ul.message-dropdown {
    padding: 0;
    max-height: 250px;
    overflow-x: hidden;
    overflow-y: auto;
}

li.message-preview {
    width: 275px;
    border-bottom: 1px solid rgba(0,0,0,.15);
}

li.message-preview>a {
    padding-top: 15px;
    padding-bottom: 15px;
}

li.message-footer {
    margin: 5px 0;
}

ul.alert-dropdown {
    width: 200px;
}
 </style>
