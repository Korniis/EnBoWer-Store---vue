import { getToken } from "@/auth/auth.service";
import axios from "axios";
import { ElMessage } from "element-plus";
axios.defaults.baseURL = "https://localhost:7245/api";
axios.defaults.headers['X-Request-With'] = "XMLHttpRequest";
axios.defaults.headers.post['Content-Type'] = 'application/json';

axios.interceptors.request.use(Option => {

    const jwtToken =getToken();
    if (jwtToken) {
        Option.headers.Authorization = `Bearer ${jwtToken}`;
    }
    return Option;
})
axios.interceptors.response.use(res => {
    console.log(res);
    return res;
}, error => {

    ElMessage({
        message:error.response.data.message,
        type : error,

    })
    return error;

})
export default axios;


