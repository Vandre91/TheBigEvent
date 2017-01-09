<template>
<div class="tab-content">
    <div class="tab-pane active" role="tabpanel" id="step1">
    <div class="step1">
            <div class="row">
            <div class="col-md-6">
                <label for="exampleInputEmail1">Nom de l'événement </label>
                <input type="email" v-model="name" class="form-control"  id="exampleInputEmail1" placeholder="Nom de l'événement" minlength="4" maxlength="56" required />
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
                            <select v-model="ville">
                                <option v-for="option in villes" v-bind:value="option.value">
                                    {{ option.text }}
                                </option>
                            </div>
                        </div>
                </fieldset>
            </form>
        </div>
    </div>




<ul class="list-inline pull-right">
    <li><button type="button" class="btn btn-primary next-step" @click="nextStep()">Enregistrer et continuer</button></li>
</ul>
</div>
</template>

<script>
export default {
    props:["name", "ville"],
    data(){
        return {
            villes: [
                {value: "paris", text: "Paris"},
                {value: "marseille", text: "Marseille"},
            ]
        }
    },
    methods:{
        nextStep(){
            this.$emit('nextStep', {method: "info", name: this.name, ville: this.ville})
        }
    }
}
</script>