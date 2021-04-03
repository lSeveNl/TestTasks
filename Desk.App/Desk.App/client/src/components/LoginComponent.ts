import Component from "vue-class-component";
import Vue from "vue";
import axios from "axios";

@Component
export default class LoginComponent extends Vue{  
    login = "";
    password = "";
    show = false;
    status = 0;

    getToken() {

        axios.post("/api/account/token/", { login: this.login, password: this.password })
            .then(x => this.status = x.status);
    }
}