<template>
    <div id="container">
        <OwnProfile></OwnProfile>
        <connection-list></connection-list>
    </div>
</template>

<script>
    import OwnProfile from "@/components/Profile/OwnProfile";
    import ConnectionList from "@/components/ConnectionList";
    export default {
        name: "Home",
        components: {ConnectionList, OwnProfile}
    }
</script>

<style scoped>
#container{

}
</style>
