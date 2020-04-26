<template>
    <div>
        <p>{{user.firstName}}</p>
    </div>
</template>

<script>

    export default {
        name: "Profile",
        props: {
            user: Object
        }
    }
</script>

<style scoped>
</style>
