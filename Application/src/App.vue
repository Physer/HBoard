<template>
    <div id="app">
        <header>
            <router-link :to="{name: 'home'}">HBoard</router-link>
        </header>
        <main>
            <router-view></router-view>
        </main>
    </div>
</template> 

<script>
export default {
    name: 'app',
};
</script>

<style>

</style>

