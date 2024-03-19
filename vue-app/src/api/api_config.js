import axios from "axios";
axios.defaults.baseURL = "https://localhost:7245/api";
axios.defaults.headers['X-Request-With'] = "XMLHttpRequest";
axios.defaults.headers.post['Content-Type'] = 'application/json';
export default axios;


