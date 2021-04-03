<template>
    <div class="common">
        <v-layout>
            <v-flex>
                <v-card 
                class="window">
                        <v-card-title class="primary" v-text="'Войдите в систему'"></v-card-title>
                        <v-text-field class="input" label="You login" counter="25" v-model="login"></v-text-field>
                        <v-text-field 
                        class="input" 
                        label="You password" 
                        counter="25" 
                        v-model="password" 
                        :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'" 
                        @click:append="show = !show"
                        :type="show ? 'text' : 'password'">
                        </v-text-field>
                        <v-btn class="btn" @click="getToken">Войти</v-btn>
                </v-card>
            </v-flex>
        </v-layout>
    </div>
</template>

<script src="./LoginComponent.ts">
</script>

<style lang="scss">
.common{
    height: 100%;
    background-image: url("https://lookw.ru/10/1014/1566950009-ultrafiolet-38.jpg");
}
.primary{
    color:azure;
}
.window{
    top: 100%;
    margin:auto;
    height: 300px;
    width: 400px;
}
.input{
    padding: 20px;
}
.btn{
    margin: 0;
    width: 100px;
    left: 4cm; 
}
</style>>
