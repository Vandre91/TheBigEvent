<template>
<div>

<div class="row db-padding-btm db-attached">
    <div class="col-md-4"> </div>
      <div class="col-md-4">
          <div class="db-wrapper" style="width:140%">
            <div class="db-pricing-eleven db-bk-color-three">

                <div class="price">
                  <small>
                  Si vous avez reçu un mail, vous pouvez inscrire le mot de passe afin de pouvoir 
                  donné vos disponibilités
                  </small>
                </div>


                <div class="type">
                  Invité
                </div>
                <ul>
                  <div class="pricing-footer">
                  <div class="col-md-12">
                      <label for="Name">Votre code : </label><br />
                    <div class="col-lg-3"> </div>
                  <div class="col-md-6" style="margin-bottom: 5%;">
                      <input type="text" v-model="code_invite" class="form-control" style="margin:auto;text-align: center;" placeholder="Insérer votre code" minlength="4" maxlength="56" required />
                  </div>
                  </div>
                  <router-link to="/biginvite"><a @click="code('code_invite')" class="db-button-color-square btn-lg">Valider</a></router-link>
                 </div>
                </ul>


            </div>
          </div>

      </div>


  </div>
</template>

<script>
import BigSelectService from '../services/BigSelect.js'

    export default {
        data () {
          return {
                code_invite:"",
            }
        },
        methods: {
          code: async function(code) {
              await BigSelectService.codeinvite(code);
          }
        }
    }
</script>

<style scoped>
/*=============================================================
    Authour URL: www.designbootstrap.com
    
    http://www.designbootstrap.com/

    License: MIT     
========================================================  */

/*============================================================
BACKGROUND COLORS
============================================================*/

.db-bk-color-two {
    background-color: #46A6F7;
}

.db-bk-color-three {
    background-color: #47887E;
}
/*============================================================
PRICING STYLES
==========================================================*/

.db-button-color-square {
    color: #fff;
    background-color: rgba(0, 0, 0, 0.50);
    border: none;
    border-radius: 5px;
    -webkit-border-radius: 5px;
    -moz-border-radius: 5px;

}

    .db-button-color-square:hover {
        color: #fff;
        background-color: rgba(0, 0, 0, 0.50);
        border: none;
    }


.db-pricing-eleven {
    margin-bottom: 30px;
    text-align: center;
    box-shadow: 0 0 5px rgba(0, 0, 0, .5);
    color: #fff;
    line-height: 30px;
}

    .db-pricing-eleven ul {
        list-style: none;
        margin: 0;
        text-align: center;
        padding-left: 0px;
    }

        .db-pricing-eleven ul li {
            padding-top: 20px;
            padding-bottom: 20px;
            cursor: pointer;
        }

            .db-pricing-eleven ul li i {
                margin-right: 5px;
            }


    .db-pricing-eleven .price {
        background-color: rgba(0, 0, 0, 0.5);
        padding: 20px 20px 20px 20px;
        font-size: 60px;
        font-weight: 900;
        color: #FFFFFF;
    }

        .db-pricing-eleven .price small {
            color: #B8B8B8;
            display: block;
            font-size: 12px;
        }

    .db-pricing-eleven .type {
        background-color: #52E89E;
        padding: 20px 20px;
        font-weight: 900;
        text-transform: uppercase;
        font-size: 30px;
    }

    .db-pricing-eleven .pricing-footer {
        padding: 20px;
    }

.db-attached > .col-lg-4,
.db-attached > .col-lg-3,
.db-attached > .col-md-4,
.db-attached > .col-md-3,
.db-attached > .col-sm-4,
.db-attached > .col-sm-3 {
    padding-left: 0;
    padding-right: 0;
}

.db-pricing-eleven.popular {
    margin-top: 10px;
}

    .db-pricing-eleven.popular .price {
        padding-top: 80px;
    }

</style>
