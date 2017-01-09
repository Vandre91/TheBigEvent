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
                                <i class="fa fa-map"></i>
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
                                <i class="glyphicon glyphicon-cutlery"></i>
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
                                <label for="exampleInputEmail1">Nom de l'événement</label>
                                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="First Name" />
                                <label for="exampleInputEmail1">Lieu de l'événement</label>
                                <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Lieu" />
                            </div>
                            </div>
                    </div>
                    <div class="container" >
                    <div class="row">
                        <form class="form-horizontal col-sm-7 col-sm-offset-2" action="" method="post">
                            <div class="form-group registration-date">
                                <label class="control-label col-sm-3" for="registration-date">Date:</label>
                                <div class="input-group date registration-date-time">
                                    <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-calendar" aria-hidden="true"></span></span>
                                    <input class="form-control" name="registration_date" id="registration-date" type="date">
                                    <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-time" aria-hidden="true"></span></span>
                                    <input class="form-control" name="registration_time" id="registration-time" type="time">
                                </div>
                            </div>
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
   <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-success">                
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            Traiteur 1
                        </h3>
                        <a class="btn btn-success btn-clickable pull-right" href="#">
                            <i class="fa fa-chevron-down"></i> 
                        </a>
                    </div>
                    <div class="panel-body">
                    </div>
                </div> 
            </div>
        </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Traiteur 2
                    </h3>
                    <a class="btn btn-info btn-clickable pull-right" href="#" style="margin-left:5px;">
                        <i class="fa fa-chevron-right"></i> 
                    </a>
                     <a class="btn btn-info btn-clickable pull-right" href="#" style="margin-right:5px;">
                        <i class="fa fa-chevron-left"></i> 
                    </a>
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
    <ul class="list-inline pull-right">
        <li><button type="button" class="btn btn-default prev-step">Précédent</button></li>
        <li><button type="button" class="btn btn-primary btn-info-full next-step">Enregistrer et continuer</button></li>
    </ul>
</div>
<div class="tab-pane" role="tabpanel" id="step4">
    <h3>Salle</h3>
    <p>Choisissez votre salle</p>
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
export default {
}

$(document).on('click', '.panel-heading .btn-clickable', function(e){
    var $this = $(this);
    if(!$this.hasClass('panel-collapsed')) {
		$this.parents('.panel').find('.panel-body').slideUp();
		$this.addClass('panel-collapsed');
		$this.find('i').removeClass('fa-chevron-up').addClass('fa-chevron-down');
	} else {
		$this.parents('.panel').find('.panel-body').slideDown();
		$this.removeClass('panel-collapsed');
		$this.find('i').removeClass('fa-chevron-down').addClass('fa-chevron-up');
	}
})

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
    width: 80%;
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
    width: 20%;
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