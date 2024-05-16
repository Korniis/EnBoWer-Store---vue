import { loginUser } from "@/auth/auth.service";
import router from "@/router";
const authModule={
    //when you use you need add namespace
    namespaced:true,
    state: {
        signInState :{
            email :'',
            exp : Date.now(),
            sub :'',
            token: null,

        }
    },
    getters: {
    },
    mutations: {
        userLogin (state,token) {

            state.signInState.token=token;
            localStorage.setItem('tokenEn',token);

        }

    },
    actions: {
        async userLoginAction({commit},login)
        {
            const{data} =   await loginUser(login);
            console.log(data);
            
            commit('userLogin',data.token);
            router.replace('/');
        }

    },
    modules: {
    }
}
export default authModule;