<!--<template>-->
<!--    <div>-->
<!--        <OwnProfile></OwnProfile>-->
<!--        <connection-list></connection-list>-->
<!--    </div>-->
<!--</template>-->

<!--<script>-->
<!--    import OwnProfile from "@/components/Profile/OwnProfile";-->
<!--    import ConnectionList from "@/components/ConnectionList";-->
<!--    export default {-->
<!--        name: "Home",-->
<!--        components: {ConnectionList, OwnProfile}-->
<!--    }-->
<!--</script>-->

<!--<style scoped>-->
<!--</style>-->


<template>
    <div id="home">
        <div v-if="this.$parent.authenticated">
            <p>Welcome back, {{claims.name}}!</p>
        </div>
        <div v-if="!this.$parent.authenticated">
            <button
                    v-on:click="login()"
            >
                Login
            </button>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'home',
        data: function () {
            return {
                claims: '',
            }
        },
        created() {
            this.setup()
        },
        methods: {
            async setup() {
                this.claims = await this.$auth.getUser()
            },
            async isAuthenticated() {
                this.authenticated = await this.$auth.isAuthenticated()
            },
            login() {
                this.$auth.loginRedirect('/')
            },
        }
    }
</script>
