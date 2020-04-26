<template>
    <div class="col-8">
    <p>Connections</p>
    <div class="list-group">
        <ul class="list-group list-group-flush">
        <ConnectionListItem
                v-for="user in list"
                :connection="user"
                v-bind:key="user.id">
        </ConnectionListItem>
        </ul>
    </div>
    </div>
</template>

<script>
    const input = [{id: 0, name: "Rens", secret: "test"}, {id: 1, name: "Peter", secret: "nothing"}, {id: 2, name: "Henk", secret: "vue"}];
    import ConnectionListItem from "@/components/ConnectionListItem";
    export default {
        name: "ConnectionList",
        components: {ConnectionListItem},
        data() {
            return {
                list: input
            };
        }
    }
</script>

<style scoped>

</style>
