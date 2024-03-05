<template>
  <el-card class="box-card">
    <template #header>
      <div class="card-header">
        <span>商品名称</span>
        <el-button type="primary" icon = "CirclePlus" circle ></el-button>
      </div>
    </template>

   <el-table :data="tableData" style="width: 100%">
    <el-table-column prop="date" label="Date" width="180" />
    <el-table-column prop="name" label="Name" width="180" />
    <el-table-column fixed="right"   label="操作" width="180" >
    <template #default>
    <el-button type="primary"  size ="small" > 修改</el-button>
    <el-button type="danger" size = "small" >删除</el-button>
  </template>
</el-table-column>
  </el-table>
 
  </el-card>
</template>

<script setup>


const tableData = [
  {
    date: '2016-05-03',
    name: 'Tom',
    address: 'No. 189, Grove St, Los Angeles',
  },
  {
    date: '2016-05-02',
    name: 'Tom',
    address: 'No. 189, Grove St, Los Angeles',
  },
  {
    date: '2016-05-04',
    name: 'Tom',
    address: 'No. 189, Grove St, Los Angeles',
  },
  {
    date: '2016-05-01',
    name: 'Tom',
    address: 'No. 189, Grove St, Los Angeles',
  },
]
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