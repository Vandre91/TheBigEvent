<template>
<div class="tab-pane" role="tabpanel" id="complete">
    <h3>Valider</h3>
    <p>Vous avez tout compléter</p>
    <li><button type="button" class="btn btn-primary btn-info-full next-step" @click="nextStep()">Enregistrer et continuer</button></li>
</div>
</template>

<script>
export default {
    methods:{
        nextStep(){
             this.$emit('nextStep', {method: "valid"})

             
        }
    }
}
</script>