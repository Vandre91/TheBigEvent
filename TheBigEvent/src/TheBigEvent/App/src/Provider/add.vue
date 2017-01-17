<template>
<div class="container">


<div class=".col-lg-12">
    <div class="widget">
    <div class="widget-header">
        <h1>Que-souhaitez-vous ?</h1>
    </div>
    <!-- /widget-header -->
    <div class="widget-content">
        <div class="shortcuts">

            <router-link to="/pro/Add_salle">   
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-plus"></i><span class="shortcut-label"> S'ajouter en tant que locataire.</span></a>
            </router-link>


            <router-link to="/pro/Add_deco">   
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-plus"></i><span class="shortcut-label"> S'ajouter en tant que décorateur.</span></a>
            </router-link>

            <router-link to="/pro/Add_traiteur">   
            <a href="javascript:;" class="shortcut"><i class="shortcut-icon fa fa-plus"></i><span class="shortcut-label">S'ajouter en tant que traiteur.</span></a>
            </router-link>

    </div>
        <!-- /shortcuts --> 
    </div>
    <!-- /widget-content --> 
    </div>


</div>

<router-view></router-view>

</div>
</template>

<script>
import AuthService from '../services/auth.js'
export default {
  	data () {
      return {
		tab: 1,
        email: null
       }
	},
     mounted() {
            this.email = AuthService.hisEmail();
        }
}
 
</script>



<style scoped>

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