<template>
  <el-card class="box-card">
    <template #header>
      <div class="card-header">
        <span>商品名称</span>
        <el-button type="primary" @click="showDialog" icon="CirclePlus" circle></el-button>
      </div>
    </template>

    <el-table :data="tableData.list" style="width: 100%">
      <el-table-column prop="nid" label="Id" width="180" />
      <el-table-column prop="name" label="Name" width="180" />
      <el-table-column fixed="right" label="操作" width="180">
        <template #default>
          <el-button type="primary" size="small"> 修改</el-button>
          <el-button type="danger" size="small">删除</el-button>
        </template>
      </el-table-column>

    </el-table>

  </el-card>
  <AddCategroy ref="addCategory" :dialogTitle="dialogTitle" ></AddCategroy>
</template>

<script setup>

import { ref, reactive, onMounted } from 'vue';
import axios from '@/api/api_config.js';
import AddCategroy from '@/components/AddCategroy.vue';
import { isNull } from '@/utils/filter';
/////////////////

const tableData = reactive({ list: [] })
const addCategory = ref(null) //获取子组件实例
const dialogTitle = ref("")


/////////////////


onMounted(() => {

  getList();

})

const getList = () => {
  return axios.get('/Hello/GetList').then((res) => {
    tableData.list = res.data.map((item, index) => {
      return { ...item, nid: index + 1 };
    });
    console.log(tableData.list);
  });
};



const showDialog = (row) => {

  if (isNull(row)) {
    dialogTitle.value = "添加";

  }
  else {
    dialogTitle.value = "修改";

  }

  addCategory.value.dialogCategory();

};


</script>

<!-- <style scoped>

.box-card
{

width: 100wh;
height: 100vh;

}
.item
{
  margin-bottom: 18px;
}
.text {
  font-size: 14px;
}
</style> -->