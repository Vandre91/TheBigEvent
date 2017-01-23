<template>
    <div class="container">

<div id="1" class="off">
    <div id="snoAlertBox" class="alert alert-danger" data-alert="alert">
        <strong>Erreur ! </strong> {{ message }}</div>
</div>


<h4 style="text-align:center;"> Vous pouvez ici proposer vos salles. Le nom, le nombre de place, le prix est nécessaire, une description est conseillée. </h4>
        <div @submit="onSubmit($event)" class=".col-lg-12 forms">
            <form role="form">
                <div class="form-group">
                    <label>*Nom de la Salle : </label>
                    <input v-model="model.Nom" class="form-control" required>
                </div>
                <div class="form-group">
                    <label>*Nombre de place disponible : </label>
                    <input v-on:keyup="alertw()" v-model="model.Nbplace" class="form-control" required>
                </div>
                <div class="form-group">
                    <label>*Prix approximatif (en €) :  </label>
                    <input v-on:keyup="alertw()" v-model="model.Prix" class="form-control" required>
                </div>
                <div class="form-group">
                    <label>Description :</label>
                    <textarea v-model="model.Description" class="form-control" rows="5"></textarea>
                </div>
                <button type="submit" class="btn btn-default">Submit Button</button>
                <button type="reset" class="btn btn-default">Reset Button</button>
            </form>
        </div>
    </div>
</template>

<script>

import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
export default {
  	data () {
      return {
        model: {
            nom : null,
            Nbplace : null,
            Prix : null,
            userId : null,
            Description : null
        },
        user: {},
        email: null,
        message: "aucun"
       }
  	},
    mounted() {
            this.email = AuthService.hisEmail();
            this.loadModelUser(this.email);
        },
    methods: {
            loadModelUser: async function(email) {
              this.user = await UserService.getUserAsync(email);
              this.user = this.user.content;
              this.model.userId = this.user.userId;
            },
            onSubmit: async function(e) {
                e.preventDefault();
                var result = null;
                var reg = /^\d+$/;
                if (reg.test(this.model.Nbplace) == false)
                    return;
                if (reg.test(this.model.Prix) == false)
                    return;
                result = await UserService.addSalleAsync(this.model);
                if(result != false)
                    this.$router.replace('/pro/my_services');
            },
            alertw() {
                var reg = /^\d+$/;
                if (reg.test(this.model.Nbplace) == false && this.model.Nbplace != null && this.model.Nbplace.length != 0)
                {
                    this.message = "Le nombre de place ne doit contenir que des chiffres."
                    document.getElementById('1').className = 'on';
                    $("#snoAlertBox").fadeIn();
                    return;
                }
                else
                    document.getElementById('1').className = 'off';
                if (reg.test(this.model.Prix) == false && this.model.Prix != null && this.model.Prix.length != 0)
                {
                    this.message = "Le prix ne doit contenir que des chiffres."
                    document.getElementById('1').className = 'on';
                    $("#snoAlertBox").fadeIn();
                    return;
                }
                else
                    document.getElementById('1').className = 'off';
            }
        }
}


</script>

<style scoped>
    .forms {
        margin-bottom: 10%;
        float: left;
    }
</style>