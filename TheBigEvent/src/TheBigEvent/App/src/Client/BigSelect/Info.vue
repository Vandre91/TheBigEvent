<template>
<div class="tab-content">


<h4> The BigSelect vous permet d'avoir la disponibilité de vos invités.<p>
   Entrez les adresses e-mail de vos invités, un code leur sera envoyé une fois que vous aurez validé.<p>
    Proposez vos dates à vos invités et ils choisiront.
    Vous pourrez ensuite créer votre événement en fonction du BigSelect.</h4>


    <div class="tab-pane active" role="tabpanel" id="step1">


  <div id="1" class="off">
    <div id="snoAlertBox" class="alert alert-danger" data-alert="alert">
        <strong>Alert ! </strong> {{ message }}</div>
  </div>  


<div class="col-md-6">
    <label for="Name">Nom de l'événement </label>
    <input type="text" v-model="name_edit" class="form-control"  id="Name" placeholder="Nom de l'événement" minlength="4" maxlength="56" required />
</div>

<div class="col-md-6" style="margin-bottom: 1%">
        <div class="row">
            <form class="form-horizontal">
                <fieldset>
                    <!-- country select -->
                    <div class="control-group">
                        <label class="control-label">Villes</label>
                        <div class="controls">
                            <select v-model="ville_edit">
                                <option v-for="option in villes" v-bind:value="option.value" >
                                    {{ option.text }}
                                </option>
                            </div>
                        </div>
                </fieldset>
           </form>
        </div>
</div> 


    <div class="col-md-6">
        <div class="form-group">
            <label class=" control-label"  for="textarea">Votre code</label><span> Ce code permet à vos invités d'accéder a l'événement </span>
            <div class="" >                     
                <input type="textarea" class="form-control" v-model="code_edit"  name="textarea">Toutes informations sur l'event à venir</input>
            </div>
        </div>
    </div>

    <div class="col-md-6">
        <div class="form-group">
            <label class=" control-label"  for="textarea">Description</label>
            <div class="" >                     
                <input type="textarea" class="form-control" v-model="description_edit"  name="textarea">Toutes informations sur l'event à venir</input>
            </div>
        </div>
    </div>
    <div class="col-md-12" style="background-color: #c2cdd6;height: 1px;"></div>


<div class="col-md-4">
    <label>Date de BigSelect</label><br />
    <datepicker  style="display: inline-block; float: left;" :format="format" :disabled="disabled" v-model="datevent" placeholder="Select Date" language="fr" ></datepicker>
    <button v-on:click="adds(datevent)" style="float: left;"class="btn btn-primary">+ </button>
    <br /><br />
<div class="col-md-12" style="padding-left: 0;">
    <li v-for="item in date_edit" >
      <span> {{ formatDate(item.dates) }} </span>
      <button v-on:click="supp(item)"class="btn fa fa-trash"> </button>
      <br />
    </li>
</div>
</div>

<div class="col-md-8">
   <div class="form-group">
        <label>Liste des invités</label><br />
            <input style="display: inline-block" type="text" v-model="nom_invite" class="form-control" placeholder="Nom de l'invité"></input>
            <input style="display: inline-block" type="mail" v-model="mail_invite" class="form-control" placeholder="Mail@invite.fr"></input>
            <button v-on:keyup.enter="adds2()" v-on:click="adds2(nom_invite, mail_invite)"class="btn btn-primary">+ </button>
   </div>


<div class="col-md-12" style="padding-left: 0;">
    <li v-for="item in invite_edit" >
      <span>Nom : {{ item.nom }} </span>
      <span>Mail : {{ item.mail }} </span>
      <button v-on:click="supp2(item)"class="btn fa fa-trash"> </button>
      <br />
    </li>
</div>
<br />   
</div>


</div>
<ul class="list-inline pull-right">
    <li><button type="button" class="btn btn-primary next-step" @click="nextStep()" style="margin-top:3%">Enregistrer et continuer</button></li>
</ul>
 

</div>


</template>

<script>
import Datepicker from 'vuejs-datepicker'

export default {
    components: {
        Datepicker
    },    
    props:["nom", "ville","description", "invite", "date", "code"],
    data(){
        return {
            villes: [
                {value:"bourg", text:"Bour-en-Bresse (01)"},
                {value:"laon", text:"Laon (02)"},
                {value:"moulins", text:"Moulins (03)"},
                {value:"digne", text:"Digne (04)"},
                {value:"gap", text:"Gap (05)"},
                {value:"nice", text:"Nice (06)"},
                {value:"privas", text:"Privas (07)"},
                {value:"charleville", text:"Charleville-Mézières (08)"},
                {value:"foix", text:"Foix (09)"},
                {value:"troyes", text:"Troyes (10)"},
                {value:"carcassonne", text:"Carcassonne (11)"},
                {value:"rodez", text:"Rodez (12)"},
                {value:"marseille", text:"Marseille (13)"},
                {value:"caen", text:"Caen (14)"},
                {value:"aurillac", text:"Aurilac (15)"},
                {value:"angouleme", text:"Angoulême (16)"},
                {value:"larochelle", text:"La Rochelle (17)"},
                {value:"bourges", text:"Bourges (18)"},
                {value:"tulle", text:"Tulle (19)"},
                {value:"ajaccio", text:"Ajaccio (2A)"},
                {value:"bastia", text:"Bastia (2B)"},
                {value:"dijon", text:"Dijon (21)"},
                {value:"saintbrieuc", text:"Saint-Brieuc (22)"},
                {value:"gueret", text:"Guéret (23)"},
                {value:"perigueux", text:"Périgueux (24)"},
                {value:"besancon", text:"Besançon (25)"},
                {value:"lille", text:"Valence (26)"},
                {value:"evreux", text:"Evreux (27)"},
                {value:"chartres", text:"Chartres (28)"},
                {value:"quimper", text:"Quimper (29)"},
                {value:"nimes", text:"Nîmes (30)"},
                {value:"toulouse", text:"Toulouse (31)"},
                {value:"auch", text:"Auch (32)"},
                {value:"bordeaux", text:"Bordeaux (33)"},
                {value:"montpellier", text:"Montpellier (34)"},
                {value:"rennes", text:"Rennes (35)"},
                {value:"chateauroux", text:"chateauroux (36)"},
                {value:"tours", text:"Tours (37)"},
                {value:"grenoble", text:"Grenoble (38)"},
                {value:"lons", text:"Lons-le-Saunier (39)"},
                {value:"montdemarsan", text:"Mont-de-Marsan (40)"},
                {value:"blois", text:"Blois (41)"},
                {value:"saintetienne", text:"Saint-Etienne (42)"},
                {value:"lepuyenvelay", text:"Le Puy-en-Velay (43)"},
                {value:"nantes", text:"Nantes (44)"},
                {value:"orleans", text:"Orléans (45)"},
                {value:"cahors", text:"Cahors (46)"},
                {value:"agen", text:"Agen (47)"},
                {value:"mende", text:"Mende (48)"},
                {value:"angers", text:"Angers (49)"},
                {value:"saintlo", text:"Saint-Lô (50)"},
                {value:"chalons", text:"Châlons-en-Champagne (51)"},
                {value:"chaumont", text:"Chaumont (52)"},
                {value:"laval", text:"Laval (53)"},
                {value:"nancy", text:"Nancy (54)"},
                {value:"barleduc", text:"Bar-le-Duc (55)"},
                {value:"vannes", text:"Vannes (56)"},
                {value:"metz", text:"Metz (57)"},
                {value:"nevers", text:"Nevers (58)"},
                {value:"lille", text:"Lille (59)"},
                {value:"beauvais", text:"Beauvais (60)"},
                {value:"alencon", text:"Alençon (61)"},
                {value:"arras", text:"Arras (62)"},
                {value:"clermont", text:"Clermont-Ferrand (63)"},
                {value:"pau", text:"Pau (64)"},
                {value:"tarbes", text:"Tarbes (65)"},
                {value:"perpignan", text:"Perpignan (66)"},
                {value:"strasbourg", text:"Strasbourg (67)"},
                {value:"colmar", text:"Colmar (68)"},
                {value:"lyon", text:"Lyon (69)"},
                {value:"vesoul", text:"Vesoul (70)"},
                {value:"macon", text:"Mâcon (71)"},
                {value:"lemans", text:"Le Mans (72)"},
                {value:"chambery", text:"Chambéry (73)"},
                {value:"annecy", text:"Annecy (74)"},
                {value:"paris", text:"Paris (75)"},
                {value:"rouen", text:"Rouen (76)"},
                {value:"melun", text:"Melun (77)"},
                {value:"versailles", text:"Versailles (78)"},
                {value:"niort", text:"Niort (79)"},
                {value:"amiens", text:"Amiens (80)"},
                {value:"albi", text:"Albi (81)"},
                {value:"montauban", text:"Montauban (82)"},
                {value:"toulon", text:"Toulon (83)"},
                {value:"avignon", text:"Avignon (84)"},
                {value:"larochesuryon", text:"La-Roche-sur-Yon (85)"},
                {value:"poitiers", text:"Poitiers (86)"},
                {value:"limoges", text:"Limoges (87)"},
                {value:"epinal", text:"Epinal (88)"},
                {value:"auxerre", text:"Auxerre (89)"},
                {value:"belfort", text:"Belfort (90)"},
                {value:"evry", text:"Evry (91)"},
                {value:"nanterre", text:"Nanterre (92)"},
                {value:"bobigny", text:"Bobigny (93)"},
                {value:"creteil", text:"Créteil (94)"},
                {value:"pontoise", text:"Pontoise (95)"}
            ],
            name_edit: this.nom,
            code_edit: this.code,
            ville_edit: this.ville,
            description_edit: this.description,
            disabled: { 
                to: new Date()
            },
            datevent: new Date(),
            format: 'dd/MM/yyyy',
            date_edit: [],
            nom_invite: null,
            mail_invite: null,
            invite_edit: [],
            message: ""
        }
    },
    methods:{
        nextStep(){
            if (this.name_edit == null || this.name_edit.length < 1)
            {
              this.message = "Vous devez saisir un nom."
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);
              return;
            }
            if (this.invite_edit == null || this.invite_edit.length < 1)
            {
              this.message = "Vous devez ajouter des invités."
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);         
              return;
            }
            if (this.date_edit == null || this.date_edit.length < 1)
            {
              this.message = "Vous devez ajouter des dates."
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);
              return;
            }
                var i;
                var mailreg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                
                for( i = 0; i < this.invite_edit.length; i++) {
                    if(!this.invite_edit[i].mail.match(mailreg))
                    {
                         this.message = "Certains adresses e-mail sont incorrects."
                        document.getElementById('1').className = 'on';
                        window.setTimeout(function() {
                        document.getElementById('1').className = 'off';                
                        }, 4000);
                        return;
                    }
                }
            this.$emit('nextStep', {method: "info", nom: this.name_edit, code: this.code_edit, ville: this.ville_edit, description: this.description_edit, invite: this.invite_edit, date : this.date_edit})
        },
        supp : function (item) {
            let idx = this.date.indexOf(item); 
            this.date_edit.splice(idx, 1);
        },
        adds : function (item) {
            if (item != null && item.length != 0)
            {
                let todo = {BigSelecteId: 0, dates : item}
                this.date_edit.push(todo);
            }
        },
        supp2 : function (item) {
            let idx = this.invite_edit.indexOf(item); 
            this.invite_edit.splice(idx, 1);
        },
        adds2 : function (item, item2) {
            if (item != null && item2 != null &&  item.length != 0 && item2.length != 0)
            {
                let todo = {BigSelecteId: 0, nom : item, mail : item2}
                this.invite_edit.push(todo);
            }
        },
        formatDate (input) {
            if (input != null)
            {
                    input = new Date(input);                    
                    var dd = input.getDate();
                    var mm = input.getMonth()+1;
                    var yyyy = input.getFullYear(); 
                    if(dd<10){dd='0'+dd} 
                    if(mm<10){mm='0'+mm} 
                    input = dd + '/' + mm + '/' + yyyy; 
                    return (input);
            }
        }
    }
}
</script>

<style>
 .cont2{
    overflow: hidden;
    margin-top: -50px;
    padding-top: -100px;
    border-radius: 17px;
    background-color: #414444;
    margin-top: 25px;
    color:white;
    width: 705px;
    box-shadow: 2px 2px 2px 2px #E0E0E0;
    
}   

.btn {
    float:right;
    margin-top: 0%;
}

h4{
    text-align: -webkit-center;
    font-weight: 700;
}

</style>