<template>
  <el-container class="layout-container-demo"  >
    <el-aside width="200px"  >
      <el-scrollbar style="background-color:#303133; "    > 
        <div id="headText" logo>EnBoWer'Store</div>
        <el-menu :default-openeds="['1']" text-color="#fff" active-text-color="#ffd04b" background-color="#303133">
         
          <el-sub-menu index="1">
            <template #title>

              <el-icon>
                <message />
              </el-icon>
              <h1>店铺管理</h1>
            </template>

            <el-menu-item index="1-1">首页</el-menu-item>
            <el-menu-item index="1-2">分类管理</el-menu-item>
            <el-menu-item index="1-3">商品管理</el-menu-item>
     


          </el-sub-menu>
          <el-sub-menu index="2">

            <template #title>
              <el-icon><icon-menu /></el-icon>

              <h1> 系统设置 </h1>
            </template>
         

           
              <el-menu-item index="2-1">修改密码</el-menu-item>
            
          
            
          </el-sub-menu>
        </el-menu>
      </el-scrollbar>
    </el-aside>

    <el-container>
      <el-header style="text-align: right; font-size: 12px">
        <div class="toolbar">
          <el-dropdown>
            <el-icon style="margin-right: 8px; margin-top: 1px">
              <setting />
            </el-icon>

            <template #dropdown>
              <el-dropdown-menu>
                <el-dropdown-item>View</el-dropdown-item>
                <el-dropdown-item>Add</el-dropdown-item>
                <el-dropdown-item>Delete</el-dropdown-item>
              </el-dropdown-menu>
            </template>
          </el-dropdown>
          <span>Tom</span>
        </div>
      </el-header>

      <el-main>
        <el-scrollbar>
          <el-table :data="tableData">
            <el-table-column prop="date" label="Date" width="140" />
            <el-table-column prop="name" label="Name" width="120" />
            <el-table-column prop="address" label="Address" />
          </el-table>
        </el-scrollbar>
      </el-main>
    </el-container>
  </el-container>
</template>

<script setup>
import { ref } from 'vue'
import { Menu as IconMenu, Message, Setting } from '@element-plus/icons-vue'

const item = {
  date: '2016-05-02',
  name: 'Tom',
  address: 'No. 189, Grove St, Los Angeles',
}
const tableData = ref(Array.from({ length: 15 }).fill(item))
</script>

<style scoped>
.layout-container-demo .el-header {
  position: relative;
  background-color: white;
  color: var(--el-text-color-primary);
}
.layout-container-demo {

  height: 100vh;



}


.layout-container-demo .el-aside {
  color: var(--el-text-color-primary);
  background: var(--el-color-primary-light-8);
}

.layout-container-demo .el-menu {
  border-right: none;
}

.layout-container-demo .el-main {
  padding: 0;
}

#headText {

 height:  60px;
 color: white;
 text-align: center;
 line-height: 50px;
 font-weight: bold;
 background-color: #303130;

}

.layout-container-demo .toolbar {
  display: inline-flex;
  align-items: center;
  justify-content: center;  height: 100%;
  right: 20px;
}
</style>
