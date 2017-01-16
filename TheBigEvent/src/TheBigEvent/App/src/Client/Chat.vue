<template>
<div id="app">
    <span>bonjour</span>
    <div class="sidebar">
    </div>
    <div class="main">
        <text>bbbbb</text>
    </div>
</div>
</template>

<script>

import AuthService from '../services/auth.js'
import UserService from '../services/UserService.js'
import EventService from '../services/EventService.js'
import ConversationService from '../services/ConversationService.js'

export default {
data () {
      return {
            
            
        }
  	},
    mounted() {
            
    },
    methods: {
        
    }
}
</script>
<style scoped>
#app {
    margin: 20px auto;
    width: 800px;
    height: 600px;

    overflow: hidden;
    border-radius: 3px;

    .sidebar {
        float: left;
        width: 200px;
        color: #f4f4f4;
        background-color: #2e3238;
    }
    .main {
        position: relative;
        overflow: hidden;
        background-color: #eee;
    }
    .text {
        position: absolute;
        width: 100%;
        bottom: 0;
        left: 0;
    }
    .message {
        height: ~'calc(100% - 160px)';
    }
}
</style>