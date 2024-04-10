<template>
  <el-container class="layout-container-demo">
    <el-aside width="200px">
      <el-scrollbar style="background-color:#303133; ">
        <div class="headText">
          <el-icon>
            <Chicken />
          </el-icon>
          <div>EnBoWer'Store</div>

          <el-icon>
            <Chicken />
          </el-icon>
        </div>
        <el-menu :default-openeds="['1']" text-color="#fff" active-text-color="#ffd04b" background-color="#303133"
          :router="true">

          <el-sub-menu index="1">
            <template #title>

              <el-icon>
                <message />
              </el-icon>
              <h1>店铺管理</h1>
            </template>

            <el-menu-item index="/">
              <el-icon>
                <HomeFilled />
              </el-icon>
              首页</el-menu-item>
            <el-menu-item index="category">
              <el-icon>
                <SetUp />
              </el-icon>
              分类管理
            </el-menu-item>
            <el-menu-item index="About">
              <el-icon>
                <Paperclip />
              </el-icon>商品管理
            </el-menu-item>



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
        <router-view>

        </router-view>

      </el-main>
      <el-footer>Footer</el-footer>
    </el-container>
  </el-container>
</template>

<script setup>

import { Menu as IconMenu, Message, Setting } from '@element-plus/icons-vue'

</script>

<style scoped>
.layout-container-demo .el-header {
  position: relative;
  background-color: white;
  color: var(--el-text-color-primary);
  box-shadow: var(--el-box-shadow-light);

}

.card-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.layout-container-demo {

  height: 100vh;



}

.box-card {

  width: 100wh;
  height: 100vh;


}

.item {
  margin-bottom: 18px;
}

.text {
  font-size: 14px;
}

.layout-container-demo .el-aside {
  color: var(--el-text-color-primary);
  background: var(--el-color-primary-light-8);
}

.layout-container-demo .el-footer {
  box-shadow: var(--el-box-shadow-dark);

}

.layout-container-demo .el-menu {
  border-right: none;
}

.layout-container-demo .el-main {
  margin: 10px 0px 0px 0px;
  box-shadow: var(--el-box-shadow-light);
  padding: 0;
}

.headText {

  height: 60px;
  color: white;
  justify-content: center;
  align-items: center;
  display: flex;
  text-align: center;
  font-weight: bold;
  background-color: #303133;

}

::-webkit-scrollbar {
  width: 0 !important;
}


.layout-container-demo .toolbar {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  right: 20px;
}
</style>
