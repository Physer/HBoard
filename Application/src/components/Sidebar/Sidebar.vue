<template>
    <div class="sidebar">
        <div class="logo"></div>
        <div class="content"></div>
    </div>
</template>

<script>
export default {
    name: 'sidebar',

}
</script>

<style>
.logo {
    grid-area: logo;
}

.content {
    grid-area: content;
}

.sidebar {
    display:grid;
    height:100vh;
    grid-area: sidebar;
    grid-template-rows:15%;
    grid-template-areas: 
    "logo"
    "content";

    background-color:black;
}

.logo {
    background-image: url('/static/logo.png');
    background-repeat: no-repeat;
    background-size: contain;
}
</style>
