<template>
    <div>
        <profile :user="user"></profile>
        <p>{{user}}</p>
    </div>


</template>

<script>
    import Profile from "@/components/Profile/Profile";
    import axios from 'axios';

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
            axios
                .get(' http://localhost:7071/api/v1/users/aa30096f-92d2-4577-8870-275dede203f1')
                .then(response => (this.user = response.data))
        }
    }
</script>

<style scoped>

</style>
