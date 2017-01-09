<template>
<div class="tab-pane" role="tabpanel" id="step6">
    <h3>menu</h3>
    <p>Choisissez votre menu </p>

    <div class="row">
            <div class="col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading clickable">
                        <h3 class="panel-title">
                            Par le traiteur 1</h3>
                        <span class="pull-right "></span>
                    </div>
                    <div class="panel-body">
                    <div class="col-md-6">
                    <h4>Proposition</h4>

                    <div class="funkyradio">
                        <div class="funkyradio-default">
                            <input type="checkbox"  name="checkbox" id="checkbox1" checked/>
                            <label for="checkbox1">salade</label>
                        </div>
                        <div class="funkyradio-primary">
                            <input type="checkbox" name="checkbox"  id="checkbox2" checked/>
                            <label for="checkbox2">samossa</label>
                        </div>
                        <div class="funkyradio-success">
                            <input type="checkbox"  name="checkbox" id="checkbox3" checked/>
                            <label for="checkbox3">couscous</label>
                        </div>
                        <div class="funkyradio-danger">
                            <input type="checkbox"  name="checkbox" id="checkbox4" checked/>
                            <label for="checkbox4">riz</label>
                        </div>
                        <div class="funkyradio-warning">
                            <input type="checkbox"  name="checkbox" id="checkbox5" checked/>
                            <label for="checkbox5">gateau</label>
                        </div>
                        <div class="funkyradio-info">
                            <input type="checkbox"  name="checkbox" id="checkbox6" checked/>
                            <label for="checkbox6">Glace</label>
                        </div>
                    </div>
</div>
</div>
</div>
</div>
</div>
<ul class="list-inline pull-right">
<li><button type="button" class="btn btn-default prev-step">Précédent</button></li>
<li><button type="button" class="btn btn-primary next-step">Enregistrer et continuer</button></li>
</ul>
</div>

</template>

<script>
export default {
    
}
</script>