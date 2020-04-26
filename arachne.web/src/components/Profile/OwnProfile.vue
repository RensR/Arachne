<template>
    <div>
        <profile :user="user"></profile>
    </div>
</template>

<script>
    import Profile from "@/components/Profile/Profile";
    import {FETCH_PROFILE} from "@/store/actions.type";

    export default {
        name: "OwnProfile",
        components: {Profile},
        data () {
            return{
                user: {
                    firstName: null,
                    lastName: null,
                    id: null
                }
            }
        },
        mounted () {
            this.$store.dispatch(FETCH_PROFILE, "AA30096F-92D2-4577-8870-275DEDE203F1")
            .then(user => this.user = user)
        }
    }
</script>

<style scoped>

</style>
