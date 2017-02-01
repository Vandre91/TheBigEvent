<template>
<div class="container">


<div id="3" class="off">
    <div id="snoAlertBox" class="alert alert-danger" data-alert="alert">
        <strong>Erreur ! </strong> {{ message }}</div>
</div>

<h4 style="text-align:center;"> Vous pouvez ici vous proposer en tant que Traiteur. Une fois inscrit en tant que traiteur, vous pourrez proposer des menus.
<br>Les menus sont catégorisés par Entré | Plat | Dessert et leurs prix diffèrent par rapport au nombre de personnes.
<br>Exemple : un gâteau pour une personne coûtent 10€.
</h4>
        <div id="1" class="on">
            <div @submit="onSubmit($event)" class="col-lg-12 forms">
                <form role="form">
                    <div class="form-group">
                        <label>*Nom : </label>
                        <input v-model="model_traiteur.nom" class="form-control input" required>
                    </div>
                    <div class="form-group">
                        <label>Description de vos spécialités : </label>
                        <textarea v-model="model_traiteur.descriptions" class="form-control input" rows="5"></textarea>
                    </div>
                    <button type="submit" class="btn btn-default">Submit Button</button>
                    <button type="reset" class="btn btn-default">Reset Button</button>
                </form>
            </div>
        </div>

        <div id="2" class="off">
            <div @submit="onSubmit2($event)" class="col-lg-12 forms">
                <form role="form">
                    <div class="form-group">
                        <label>*Nom : </label>
                        <input v-model="model_menu.nom" class="form-control input" required>
                    </div>
                    <div class="form-group">
                    <label>*Entrer : </label>
                    <br />
                    <input v-model="model_menu.entrer" class="form-control input" required>
                    </div>
                    <div class="form-group">
                    <label>*Plat : </label>
                    <br />
                    <input v-model="model_menu.plat" class="form-control input" required>
                    </div>
                    <div class="form-group">
                    <label>*Dessert : </label>
                    <br />
                    <input v-model="model_menu.dessert" class="form-control input" required>
                    </div>
                    <div class="form-group">
                        <label>*Quantité de personnes : </label>
                        <input v-on:keyup="alertw()" v-model="model_menu.Nbpersonnes" class="form-control input" required>
                    </div>
                    <div class="form-group">
                        <label>*Prix approximatif (en €) par rapport à la quantité de personnes :  </label>
                        <input v-on:keyup="alertw()" v-model="model_menu.Prix" class="form-control input" required>
                    </div>
                    <button type="submit" class="btn btn-default">Submit Button</button>
                    <button type="reset" class="btn btn-default">Reset Button</button>
                </form>
            </div>
        </div>
</div>
</template>

<script>
import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
export default {
  	data () {
      return {
        model_traiteur: {
            nom : null,
            descriptions : null,
            userId : null
        },
        model_menu : {
            nom : null,
            entrer : null,
            plat : null,
            dessert : null,
            Nbpersonnes : null,
            Prix : null,
            TraiteurId : null
        },
        model_recept : {},
        user: {},
        email: null,
        message: "Aucun"
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
              this.model_recept = await UserService.getTraiteurAsync(this.user.userId);
              this.model_recept = this.model_recept.content;
              if (this.model_recept != null)
                  this.addClassOn();
            },
            onSubmit: async function(e) {
                e.preventDefault();
                var result = null;
                this.model_traiteur.userId = this.user.userId;
                result = await UserService.addTraiteurAsync(this.model_traiteur);
                if(result != false)
                    this.$router.replace('/pro/my_services');
            },

            onSubmit2: async function(e) {
                e.preventDefault();
                var result = null;
                this.model_menu.TraiteurId = this.model_recept.traiteurId
                var reg = /^\d+$/;
                if (reg.test(this.model_menu.Nbpersonnes) == false)
                    return;
                if (reg.test(this.model_menu.Prix) == false)
                    return;
                result = await UserService.addMenuAsync(this.model_menu);
                if(result != false)
                    this.$router.replace('/pro/my_services');
            },
            addClassOn: async function()
            {
                document.getElementById('2').className = 'on';
                document.getElementById('1').className = 'off';
            },
            alertw() {
                var reg = /^\d+$/;
                if (reg.test(this.model_menu.Nbpersonnes) == false && this.model_menu.Nbpersonnes != null && this.model_menu.Nbpersonnes.length != 0)
                {
                    this.message = "Le nombre de place ne doit contenir que des chiffres."
                    document.getElementById('3').className = 'on';
                    $("#snoAlertBox").fadeIn();
                    return;
                }
                else
                    document.getElementById('3').className = 'off';
                if (reg.test(this.model_menu.Prix) == false && this.model_menu.Prix != null && this.model_menu.Prix.length != 0)
                {
                    this.message = "Le prix ne doit contenir que des chiffres."
                    document.getElementById('3').className = 'on';
                    $("#snoAlertBox").fadeIn();
                    return;
                }
                else
                    document.getElementById('3').className = 'off';
            }            
        }
}

</script>

<style scoped>
.btn {
    margin-top: 0px;
}


    .input {
        position: relative;
        left:37%;
    }

    .form-group {
        text-align: center;
    }

 </style>