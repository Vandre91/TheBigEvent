<template>
<div class="tab-content">
    <div class="tab-pane active" role="tabpanel" id="step1">
    <div class="step1">
            <div class="row">
            <div class="col-md-6">
                <label for="exampleInputEmail1">Nom de l'événement </label>
                <input type="email" class="form-control"  id="exampleInputEmail1" placeholder="Nom de l'événement" minlength="4" maxlength="56" required />
            </div>
            </div>
    </div>

    


    <div class="container">
        <div class="row">
            <form class="form-horizontal">
                <fieldset>
                    <!-- country select -->
                    <div class="control-group">
                        <label class="control-label">Villes</label>
                        <div class="controls">
                            <select id="country"  name="country" class="input-xlarge">
                        
                                <option value="GH">Goussainville</option>
                                <option value="GR">Grenoble</option>
                                <option value="LV">Louvres</option>
                                <option value="LU">Luxembourg</option>
                                <option value="MO">Meaux</option>
                                <option value="PR">Paris</option>
                                <option value="SR">Sarcelles</option>
                                <option value="CR">Creil</option>


                                </select>
                            </div>
                        </div>
                </fieldset>
            </form>
        </div>
    </div>




<ul class="list-inline pull-right">
    <li><button type="button" class="btn btn-primary next-step">Enregistrer et continuer</button></li>
</ul>
</div>
</template>

<script>
export default {
    mounted(){
        setInterval(() => {
            this.$emit("test", "FDP")
        }, 2000)
    }
}
</script>