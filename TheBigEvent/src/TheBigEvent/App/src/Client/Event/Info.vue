<template>
<div class="tab-content">

<div class="tab-pane active" role="tabpanel" id="step1">
    
    <div class="tab-pane active" role="tabpanel" id="step1">
  <div id="1" class="off">
    <div id="snoAlertBox" class="alert alert-danger" data-alert="alert">
        <strong>Alert ! </strong> {{ message }}</div>
  </div>  

<div class="col-md-6">
    <div class="step1">
            <div class="row">
                <label for="InputName">Nom de l'événement </label>
                <input type="text" v-model="name_edit" class="form-control"  id="InputName" placeholder="Nom de l'événement" minlength="4" maxlength="56" required />
            </div>
    </div>
    <div class="step1">
            <div class="row">
                <label>Nombre d'invité </label>
                <input type="text"  class="form-control" v-model="Inv" id="InputNb" placeholder="Nombre d'invité" required/>
            </div>
    </div>

    <div class="step1">
            <div class="row">

                <label class="control-label">Villes</label>
                <div class="controls">
                    <select v-model="ville_edit">
                        <option v-for="option in villes" v-bind:value="option.value">
                            {{ option.text }}
                        </option>
                 </div>
            </div>
    </div>
    </div>

</div>

    <div class="col-md-6">
        <datepicker :format="format" :disabled="disabled" v-model="datevent" placeholder="Select Date" language="fr" :inline="true"></datepicker>
    </div>
<ul class="list-inline pull-right">
    <li><button type="button" class="btn btn-primary next-step" @click="nextStep()">Enregistrer et continuer</button></li>
</ul>
</div>
</template>

<script>
import Datepicker from 'vuejs-datepicker'

export default {
    components: {
        Datepicker
    },
    props:["name", "ville", "NbInvite", "date"],
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
            name_edit: this.name,
            ville_edit: this.ville,
            Inv : this.NbInvite,
            format: 'yyyy-MM-dd',
            disabled: { 
                to: new Date()
            },
            datevent: new Date(),
            message:""
        }
    },
    methods:{
        nextStep(){
            if (this.name_edit == null || this.name_edit.length == 0){
              this.message = "Un événement sans nom ?"
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);
              return;
            }
            if (this.Inv < 1) {
              this.message = "Vous voulez dansé tout seul ?"
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);
              return;
            }
            if (this.datevent < (Date.now())){
              this.message = "Comment voulez vous organiser votre événement aujourd'hui ?"
              document.getElementById('1').className = 'on';
              window.setTimeout(function() {
              document.getElementById('1').className = 'off';                
              }, 4000);
              return;
            }
           this.$emit('nextStep', {method: "info", name: this.name_edit, ville: this.ville_edit, NbInvite: this.Inv, date:this.datevent})
        }
    }
}
</script>



