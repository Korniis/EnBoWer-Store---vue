<template>
  <div>
    <el-card class="box-card">
      <template #header>
        <div class="card-header">
          <span>商品名称</span>
          <el-button type="primary" @click="showDialog()" icon="el-icon-circle-plus-outline" circle></el-button>
        </div>
      </template>

      <el-table :data="tableData.list" style="width: 100%">
        <el-table-column prop="nid" label="Id" width="180" />
        <el-table-column prop="name" label="Name" width="180" />
        <el-table-column fixed="right" label="操作" width="180">
          <template #default="scope">
            <el-button type="primary" size="small" @click="showDialog(scope.row)">修改</el-button>
            <el-button type="danger" size="small" @click="open(scope.row)">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
    </el-card>

    <AddCategroy ref="addCategory" :tableRow="tableRow" :dialogTitle="dialogTitle"></AddCategroy>
  </div>
</template>

<script setup>
import { ref, reactive, onMounted, provide } from 'vue';
import axios from '@/api/api_config.js';
import AddCategroy from '@/components/AddCategroy.vue';
import { isNull } from '@/utils/filter';
import { ElMessage, ElMessageBox } from 'element-plus'

const tableData = reactive({ list: [] });
const addCategory = ref(null);
const dialogTitle = ref('');
const tableRow = ref({});

onMounted(() => {
  getList();
});

const getList = () => {
  return axios.get('/Category/GetList').then((res) => {
    tableData.list = res.data.map((item, index) => {
      return { ...item, nid: index + 1 };
    });
  });
};
provide("getList",getList);

const showDialog = (row) => {
  if (isNull(row)) {
    dialogTitle.value = '添加';

  }
  else {
    dialogTitle.value = '修改';
    tableRow.value = row;

  }

  addCategory.value.dialogCategory();
  
 // 这里可能需要调整，根据 AddCategroy 组件的实际情况
};
const open = (row) => {


  ElMessageBox.confirm(
    '是否要删除',
    'Warning',
    {
      confirmButtonText: 'yes',
      cancelButtonText: 'no',
      type: 'warning',
    }
  )
    .then(() => {
      console.log(row.id);
      axios.delete('/Category/Delete/' + row.id).then(() => {
        ElMessage({
          type: 'success',
          message: 'Delete completed',
        });
        getList();

      })

    })
    .catch(() => {
      ElMessage({
        type: 'info',
        message: 'Delete canceled',
      })
    })

}
</script>

<style scoped>
.box-card {
  width: auto;
  height: 100vh;
}

.item {
  margin-bottom: 18px;
}

.text {
  font-size: 14px;
}
</style>
