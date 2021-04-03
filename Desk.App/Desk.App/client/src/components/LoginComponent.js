import { __decorate } from "tslib";
import Component from "vue-class-component";
import Vue from "vue";
import axios from "axios";
let LoginComponent = class LoginComponent extends Vue {
    constructor() {
        super(...arguments);
        this.login = "";
        this.password = "";
        this.show = false;
        this.status = 0;
    }
    getToken() {
        axios.post("/api/account/token/", { login: this.login, password: this.password })
            .then(x => this.status = x.status);
    }
};
LoginComponent = __decorate([
    Component
], LoginComponent);
export default LoginComponent;
//# sourceMappingURL=LoginComponent.js.map