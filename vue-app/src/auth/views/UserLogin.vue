<template>

  <body id="poster">
    <el-form :rules="rules" class="login-container" ref="loginForm" :model="ruleForm" label-position="left" label-width="auto">
      <h3 class="login_title">系统登录</h3>
      <el-form-item class="l-input" label="账号:" prop="email">
        <el-input type="text" v-model="ruleForm.email" auto-complete="off" placeholder=""></el-input>
      </el-form-item>
      <el-form-item class="l-input" label="密码:" prop="password">
        <el-input type="password" v-model="ruleForm.password" auto-complete="off" placeholder=""></el-input>
      </el-form-item>
      <el-form-item class="l_buttonContent">
        <div style="display: flex; padding: 0px 100px 10px 100px; width: 100%; justify-content: space-between;">
        <el-button type="primary" style="width: 40%;    background: #505458; border: none" @click="submitForm(loginForm)">登录</el-button>
        <el-button type="primary" style="width: 40%;   color: black;  background: #ffffff; border: 1px solid grey">注册</el-button>
        </div>
        </el-form-item>
    </el-form>
  </body>
</template>
<script setup>
import { reactive, ref, toRefs } from 'vue';
import { useStore } from 'vuex';

import FormRules from 'element-plus';

const store=useStore();
const loginForm = ref('');
const state = reactive({
  ruleForm: {
    email: "123456",
    password: "123456",
  }
})

const rules = reactive  ({
  email: [
    { required: true, message: '请输入账号', trigger: 'blur' },
  ],
  password: [
    { required: true, message: '请输入密码', trigger: 'blur' },

  ],
})

const submitForm = async (formEl) => {
  console.log(formEl)
  if (!formEl) return
  await formEl.validate((valid) => {
    if (valid) {
      //通过验证
       store.dispatch('authModule/userLoginAction',state.ruleForm);
      console.log('submit!',formEl)
    } else {
      console.log('error submit!')
    }
  })

}
const { ruleForm } = toRefs(state);

</script>
<style>
#poster {
  background: url("../../assets/background.png");
  background-position: center;
  height: 100%;
  width: 100%;
  background-size: cover;
  position: fixed;
}
body {
  margin: 0px;
  padding: 0;
}
.login-container {
  border-radius: 15px;
  background-clip: padding-box;
  margin: 90px auto;
  width: 350px;
  padding: 35px 35px 15px 35px;
  background: #fff;
  border: 1px solid #eaeaea;
  box-shadow: 0 0 25px #cac6c6;
  height: 250px;
}
.login_title {
  margin: 0px auto 40px auto;
  text-align: center;
  color: #505458;
}
</style>