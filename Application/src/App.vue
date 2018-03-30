<template>
    <div id="app" class="grid">
        <sidebar></sidebar>
        <header-bar></header-bar>
        <div class="main">
            <maps></maps>
        </div>
    </div>
</template> 

<script>
export default {
    name: 'app',
};
</script>

<style>
.main {
    grid-area: main;
    display:grid;
    grid-template-columns: 25%;
    grid-template-rows: 35%;
}

.grid {
    display: grid;
    height:100vh;
    grid-template-columns: 10% auto;
    grid-template-rows: 25% auto 35%;
    grid-template-areas: 
    "sidebar header header"
    "sidebar main main";

    background-color:yellow;
}
</style>

