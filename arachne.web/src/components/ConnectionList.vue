<template>
    <ul>
        <ConnectionListItem
                v-for="user in list"
                :connection="user"
                :key="user.id">
        </ConnectionListItem>
    </ul>

</template>

<script>
    import ConnectionListItem from "@/components/ConnectionListItem";
    export default {
        name: "ConnectionList",
        components: {ConnectionListItem},
        props: {
            list: Array
        }
    }
</script>

<style scoped>

</style>
