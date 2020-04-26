<template>
    <li class="list-group-item list-group-item-action">{{ connection.name }}</li>
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
