<template>
<div class="container">
<h4 style="text-align:center;"> Vous pouvez ici vous proposer en tant que Traiteur. Une fois inscrit en tant que traiteur, vous pourrez proposer des menus.
<br>Les menus sont catégorisés par Entré | Plat | Dessert et leurs prix diffèrent par rapport au nombre de personne.
<br>Exemple : un gâteau pour une personne coûtent 10€.
</h4>
        <div id="1" class="on">
            <div @submit="onSubmit($event)" class=".col-lg-12 forms">
                <form role="form">
                    <div class="form-group">
                        <label>*Nom : </label>
                        <input v-model="model_traiteur.nom" class="form-control" required>
                    </div>
                    <div class="form-group">
                        <label>Description de vos spécialités : </label>
                        <textarea v-model="model_traiteur.descriptions" class="form-control" rows="5"></textarea>
                    </div>
                    <button type="submit" class="btn btn-default">Submit Button</button>
                    <button type="reset" class="btn btn-default">Reset Button</button>
                </form>
            </div>
        </div>
        <br /><br />

        <div id="2" class="off">
            <div @submit="onSubmit2($event)" class=".col-lg-12 forms">
                <form role="form">
                    <div class="form-group">
                        <label>*Nom : </label>
                        <input v-model="model_menu.nom" class="form-control" required>
                    </div>
                    <label>*Catégories : </label>
                    <select v-model="model_menu.cat" required>
                        <option value="Entrer">Entré</option>
                        <option value="Plat">Plat</option>
                        <option value="Dessert">Dessert</option>
                    </select>
                    <br /><br />
                    <div class="form-group">
                        <label>*Quantité de personnes : </label>
                        <input v-model="model_menu.Nbpersonnes" class="form-control" required>
                    </div>
                    <div class="form-group">
                        <label>*Prix approximatif (en €) par rapport à la quantité de personnes :  </label>
                        <input v-model="model_menu.Prix" class="form-control" required>
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
            cat : null,
            Nbpersonnes : null,
            Prix : null,
            TraiteurId : null
        },
        model_recept : {},
        user: {},
        email: null
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
                {
                    console.log("Un traiteur vien d'être rajouter");
                    this.$router.replace('/pro/my_services');
                }
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
                {
                    console.log("Un Menu vien d'être rajouter");
                    this.$router.replace('/pro/my_services');
                }
            },
            addClassOn: async function()
            {
                document.getElementById('2').className = 'on';
                document.getElementById('1').className = 'off';
            }
        }
}

</script>

<style scoped>
.btn {
    margin-top: 0px;
}

.on {
    display: block;
}

.off {
    display: none;
}

 </style>