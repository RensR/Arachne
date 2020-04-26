<template>
    <div>{{ connection.name }}</div>
</template>

<script>
    export default {
        name: "ConnectionListItem",
        props: {
            connection: {
                type: Object,
                required: true
            }
        }
    }
</script>

<style scoped>

</style>
