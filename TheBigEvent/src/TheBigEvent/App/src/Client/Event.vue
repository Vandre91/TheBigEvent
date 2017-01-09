<template>
<div class="container">
	<div class="row">
		<section>
        <div class="wizard">
            <div class="wizard-inner">
                <div class="connecting-line"></div>
                <ul class="nav nav-tabs" role="tablist">
                    <li role="presentation" class="active">
                        <a href="#step1" data-toggle="tab" aria-controls="step1" role="tab" title="info">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-info-sign"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" class="disabled">
                        <a href="#step2" data-toggle="tab" aria-controls="step2" role="tab" title="Traiteur">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-cutlery"></i>
                            </span>
                        </a>
                    </li>
                     <li role="presentation" class="disabled">
                        <a href="#step6" data-toggle="tab" aria-controls="step6" role="tab" title="menu">
                            <span class="round-tab">
                                <i class="fa fa-hand-o-up"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" class="disabled">
                        <a href="#step3" data-toggle="tab" aria-controls="step3" role="tab" title="Décoration">
                            <span class="round-tab">
                                <i class="fa fa-star"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" class="disabled">
                        <a href="#step4" data-toggle="tab" aria-controls="step4" role="tab" title="Salle">
                            <span class="round-tab">
                                <i class="fa fa-map"></i>
                            </span>
                        </a>
                    </li>
                    <li role="presentation" class="disabled">
                        <a href="#complete" data-toggle="tab" aria-controls="complete" role="tab" title="Complete">
                            <span class="round-tab">
                                <i class="glyphicon glyphicon-ok"></i>
                            </span>
                        </a>
                    </li>

                    
                </ul>
            </div>

            <form role="form">
                <div class="tab-content">
                    <div class="tab-pane active" role="tabpanel" id="step1">
                    <div class="step1">
                            <div class="row">
                            <div class="col-md-6">
                                <label for="exampleInputEmail1">Nom de l'événement </label>
                                <input type="email" class="form-control" v-model="model.Nomevent" id="exampleInputEmail1" placeholder="Nom de l'événement" minlength="4" maxlength="56" required />
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
                                            <select id="country" v-model="selected" name="country" class="input-xlarge">
                                                <option value="" v-for="option in options" v-bind:value="option.value" selected="selected">(Choisissez votre ville)</option>
                                        
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
    

     <div class="tab-pane" role="tabpanel" id="step2">
              <h3>Traiteur</h3>
              <p>Choisissez votre traiteur</p>

 <div class="container" id="step2">
    <div class="list-group">

    			<a href="#" class="list-group-item">

					<div class="media">
			        	<span class="label label-danger pull-right">Cheapest</span>
						<div class="checkbox pull-right">
				    		<label>
								<input type="checkbox" value="" >				
							</label>
						</div>
						<div class="pull-left">
						</div>
						<div class="media-body">
							<h4 class="media-heading" v-model="model.nom">Traiteur 1</h4>
							<p>Française</p>
						</div>

					</div>					
			        
    			</a>
                   <div class="clearfix"></div>
			        
			    </a>				

			</div>
</div>
              <ul class="list-inline pull-right">
                  <li><button type="button" class="btn btn-primary next-step">Enregistrer et continuer</button></li>
              </ul>
            
     </div>


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
<div class="tab-pane" role="tabpanel" id="step3">
    <h3>Décorateur</h3>
    <p>Choisissez votre décorateur</p>
 <div class="container" id="step2">
    <div class="list-group">

    			<a href="#" class="list-group-item">

					<div class="media">
			        	<span class="label label-danger pull-right">le moins cher</span>
						<div class="checkbox pull-right">
				    		<label>
								<input type="checkbox" value="">				
							</label>
						</div>
						<div class="pull-left">
						</div>
						<div class="media-body">
							<h4 class="media-heading" v-model="model.nom">Décorateur 1</h4>
                            Prix: 150€
							<p>Marriage</p>
						</div>

					</div>					
			        
    			</a>
                   <div class="clearfix"></div>
			        
			    </a>				

			</div>
</div>

    <ul class="list-inline pull-right">
        <li><button type="button" class="btn btn-default prev-step">Précédent</button></li>
        <li><button type="button" class="btn btn-primary btn-info-full next-step">Enregistrer et continuer</button></li>
    </ul>
</div>
<div class="tab-pane" role="tabpanel" id="step4">
    <h3>Salle</h3>
    <p>Choisissez votre salle</p>

 <div class="container" id="step2">
    <div class="list-group">

    			<a href="#" class="list-group-item">

					<div class="media">
			        	<span class="label label-danger pull-right">Le plus cher</span>
						<div class="checkbox pull-right">
				    		<label>
								<input type="checkbox" value="">				
							</label>
						</div>
						<div class="pull-left">
						</div>
						<div class="media-body">
							<h4 class="media-heading" v-model="model.Nom">Salle</h4>
                            Prix: 600€
							<p>Accueillir: 600 invités</p>
						</div>

					</div>					
			        
    			</a>
                   <div class="clearfix"></div>
			        
			    </a>				

			</div>
</div>

    <ul class="list-inline pull-right">
        <li><button type="button" class="btn btn-default prev-step">Précédent</button></li>
        <li><button type="button" class="btn btn-primary btn-info-full next-step">Enregistrer et continuer</button></li>
    </ul>
</div>
<div class="tab-pane" role="tabpanel" id="complete">
    <h3>Valider</h3>
    <p>Vous avez tout compléter</p>
    <li><button type="button" class="btn btn-primary btn-info-full next-step">Enregistrer et continuer</button></li>
    </div>
    <div class="clearfix"></div>
</div>
</form>
</div>
</section>
</div>
</div>




</template>
<script src="http://momentjs.com/downloads/moment-timezone-with-data.js"></script>
<script src="http://momentjs.com/downloads/moment-with-locales.js"></script>
<script src="http://momentjs.com/downloads/moment-timezone-with-data.js"></script>

<script>
import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
export default {
    
  	data () {
      return {
        model: {
            content:{
            Nomevent : null,
            ville : null,
            Date : null
            }
        },
        email: null,
        Traiteur: {
            nom : null,
            ville : null,
            nbinvite : null
        },

        Menu: {
            options: [
      { text: 'samossa', value: 'A' },
      { text: 'salade', value: 'B' },
      { text: 'couscous', value: 'C' },
      { text: 'riz', value: 'D' },
      { text: 'gateau', value: 'E' },
      { text: 'Glace', value: 'F' }
                    ]
        },

        Salle: {
            nom : null,
            ville : null,
            nbplace : null,
            autre : null
        },
        Deco: {
            nom : null,
            ville: null,
            type: null,
            prixapprox:null
        }
        }
      
  	},
    mounted() {
            this.email = AuthService.hisEmail();

            this.loadModelUser(this.email);
        },
    methods: {
            loadModelUser: async function(email) {
              this.model = await UserService.getUserAsync(email);
              console.log(this.model.content.mail);
            }
        }
 
}

$(document).ready(function() {
    $('[id^=detail-]').hide();
    $('.toggle').click(function() {
        $input = $( this );
        $target = $('#'+$input.attr('data-toggle'));
        $target.slideToggle();
    });
});

$(document).on('click', '.panel div.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-minus').addClass('glyphicon-plus');
    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-plus').addClass('glyphicon-minus');
    }
});
$(document).ready(function () {
    $('.panel-heading span.clickable').click();
    $('.panel div.clickable').click();
});


$(document).ready(function () {
    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();
    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {
        var $target = $(e.target);
 
        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);

    });
    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });
});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}

function addNow() {
  nowDate = moment().tz("Europe/London").format('YYYY-MM-DD');
  nowTime = moment().tz("Europe/London").format('HH:mm:ss');
  document.getElementById('registration-date').value = nowDate;
  document.getElementById('registration-time').value = nowTime;
  set = setTimeout(function () { addNow(); }, 1000);
}
</script>

<style scoped>

.wizard {
    margin: 20px auto;
    background: #fff;
}

.wizard .nav-tabs {
    position: relative;
    margin: 40px auto;
    margin-bottom: 0;
    border-bottom-color: #e0e0e0;
}

.wizard > div.wizard-inner {
    position: relative;
}

.connecting-line {
    height: 2px;
    background: #e0e0e0;
    position: absolute;
    width: 90%;
    margin: 0 auto;
    left: 0;
    right: 0;
    top: 50%;
    z-index: 1;
}

.wizard .nav-tabs > li.active > a, .wizard .nav-tabs > li.active > a:hover, .wizard .nav-tabs > li.active > a:focus {
    color: #555555;
    cursor: default;
    border: 0;
    border-bottom-color: transparent;
}

span.round-tab {
    width: 70px;
    height: 70px;
    line-height: 70px;
    display: inline-block;
    border-radius: 100px;
    background: #fff;
    border: 2px solid #e0e0e0;
    z-index: 2;
    position: absolute;
    left: 0;
    text-align: center;
    font-size: 25px;
}
span.round-tab i{
    color:#555555;
}
.wizard li.active span.round-tab {
    background: #fff;
    border: 2px solid #5bc0de;
    
}
.wizard li.active span.round-tab i{
    color: #5bc0de;
}

span.round-tab:hover {
    color: #333;
    border: 2px solid #333;
}

.wizard .nav-tabs > li {
    width: 15%;
}

.wizard li:after {
    content: " ";
    position: absolute;
    left: 46%;
    opacity: 0;
    margin: 0 auto;
    bottom: 0px;
    border: 5px solid transparent;
    border-bottom-color: #5bc0de;
    transition: 0.1s ease-in-out;
}

.wizard li.active:after {
    content: " ";
    position: absolute;
    left: 46%;
    opacity: 1;
    margin: 0 auto;
    bottom: 0px;
    border: 10px solid transparent;
    border-bottom-color: #5bc0de;
}

.wizard .nav-tabs > li a {
    width: 70px;
    height: 70px;
    margin: 20px auto;
    border-radius: 100%;
    padding: 0;
}

    .wizard .nav-tabs > li a:hover {
        background: transparent;
    }

.wizard .tab-pane {
    position: relative;
    padding-top: 50px;
}

.wizard h3 {
    margin-top: 0;
}

@media( max-width : 585px ) {

    .wizard {
        width: 90%;
        height: auto !important;
    }

    span.round-tab {
        font-size: 16px;
        width: 50px;
        height: 50px;
        line-height: 50px;
    }

    .wizard .nav-tabs > li a {
        width: 50px;
        height: 50px;
        line-height: 50px;
    }

    .wizard li.active:after {
        content: " ";
        position: absolute;
        left: 35%;
    }

    
}
 </style>