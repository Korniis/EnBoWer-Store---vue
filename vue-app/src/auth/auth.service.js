import axios from "@/api/api_config"
import router from "@/router";


export const loginUser = async(login)=>{



    return await axios.post('/Users/auth',login);

}

const key =  'tokenEn';
// get token
export const getToken=()=>{
return localStorage.getItem(key);


}
export const loginOut=()=>{
     localStorage.clear
    router.replace('/login')

    }