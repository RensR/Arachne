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
        methods: {
            async getToken(){
                this.authToken = await this.$auth.getAccessToken();
            }
        },
        async mounted () {
            await this.getToken();
            this.$store.dispatch(FETCH_PROFILE,  this.authToken)
            .then(user => this.user.firstName = user)
        }
    }
</script>

<style scoped>

</style>
