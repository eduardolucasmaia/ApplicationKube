<template>
    <div class="hello">
        <h4>version {{ appVersion }}</h4>
        <h1>{{ msg }}{{ user }}</h1>
        <h3>Environment API {{ envApi }}</h3>
        <h3>Environment WEB {{ envWeb }}</h3>
        <h3>Route {{ route }}</h3>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'HelloWorld',
        data() {
            return {
                user: null,
                envApi: null,
                envWeb: process.env.VUE_APP_ENVIRONMENT,
                appVersion: process.env.VUE_APP_VERSION,
                route: process.env.VUE_APP_API_URL
            };
        },
        props: {
            msg: String
        },
        created: function () {
            axios
                .get(`${process.env.VUE_APP_API_URL}/WindowsUser/GetUser`, { withCredentials: true })
                .then(res => {
                    this.user = res.data;
                });

            axios
                .get(`${process.env.VUE_APP_API_URL}/WindowsUser/GetAppSettings`, { withCredentials: true })
                .then(res => {
                    this.envApi = res.data;
                });
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
