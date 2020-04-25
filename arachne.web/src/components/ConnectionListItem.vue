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
            },
            key: Number
        }
    }
</script>

<style scoped>

</style>
