<template>

<div class="container">

<div class="col-lg-6 col-md-6">
    <h1>Vos réservations</h1>
    <div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>#</th>
                <th>Nom de votre réservations</th>
                <th>Date</th>
                <th>Lieu</th>
            </tr>
        </thead>
        <tbody>
            <tr class="success">
                <td>1</td>
                <td>Noêl</td>
                <td>25/12/2016</td>
                <td>Londre</td>
            </tr>
            <tr class="success">
                <td>2</td>
                <td>Nouvel an</td>
                <td>31/12/2016</td>
                <td>Paris</td>
            </tr>
            <tr class="warning">
                <td>3</td>
                <td>Itération PI</td>
                <td>10/01/2017</td>
                <td>In'Tech</td>
            </tr>
            <tr class="danger">
                <td>4</td>
                <td>Forum PI</td>
                <td>23/01/2017</td>
                <td>In'Tech</td>
            </tr>
        </tbody>
    </table>
    </div>
</div>


<div class="col-lg-6 col-md-6">
    <div class="widget">
    <div class="widget-header">
        <h1>Raccourcis</h1>
    </div>
    <!-- /widget-header -->
    <div class="widget-content">
        <div class="shortcuts">

            <router-link to="/pro/add" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa fa-plus"></i><span class="shortcut-label"> Ajouter une prestation </span></a>
            </router-link>


            <router-link to="/pro/event" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-list-alt"></i><span class="shortcut-label"> Confirmer un évènement </span></a>
            </router-link>

            <router-link to="/pro/Conversation" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-comment"></i><span class="shortcut-label">Discussion avec les clients</span></a>
            </router-link>

            <router-link to="/pro/profil" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-user"></i><span class="shortcut-label">Modifier<br /> son profil</span></a>
            </router-link>

            <a href="mailto:thebigevent@intechinfo.fr" class="shortcut"><i class="shortcut-icon fa fa-tag"></i><span class="shortcut-label"> Envoyer un mail au support</span> </a>

            <router-link to="/logout" class="router">
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-power-off"></i><span class="shortcut-label"> Se <br /> déconnecter</span> </a>
            </router-link>
    </div>
        <!-- /shortcuts --> 
    </div>
    <!-- /widget-content --> 
    </div>


</div>
</template>

<script>
export default {
}

</script>

<style scoped>

@import "~bootstrap/dist/css/bootstrap.min.css";
@import "~font-awesome/css/font-awesome.css";


.shortcuts {
	text-align: center;	
}

.shortcuts .shortcut { 
	width: 22.50%;
	display: inline-block;
	padding: 12px 0;
	margin: 0 .9% 1em;
	vertical-align: top;	
	
	text-decoration: none;
	
	background: #f9f6f1;
	
	border-radius: 5px;
}

.shortcuts .shortcut .shortcut-icon {
	margin-top: .25em;
	margin-bottom: .25em;
	
	font-size: 32px;
	color: #545454;
}

.shortcuts .shortcut:hover {
	background: #00ba8b;
}

.shortcuts .shortcut:hover span{
	color: #fff;
}

.shortcuts .shortcut:hover .shortcut-icon {
	color: #fff;
}

.shortcuts .shortcut-label {
	display: block;
	
	font-weight: 400;
	color: #545454;
}


 </style>
