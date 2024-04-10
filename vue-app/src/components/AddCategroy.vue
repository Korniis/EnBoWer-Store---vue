<template>
    <el-dialog v-model="dialogVisible" :title="dialogTitle"  @closed="handleClosed" width="50%">
        <el-form :model="ruleForms" label-width="120px">
            <el-form-item label="分类">
                <el-input v-model="ruleForms.name" />
            </el-form-item>
        </el-form>
        <template #footer>
            <div class="dialog-footer">
                <el-button @click="dialogVisible = false">Cancel</el-button>
                <el-button @click="AddCate" type="primary">Confirm</el-button>
            </div>
        </template>
    </el-dialog>
</template>

<script setup>
import { defineProps, defineExpose, reactive, toRefs, watch, inject } from 'vue'
import { ElMessage } from 'element-plus'
import axios from 'axios';


const props = defineProps({
    dialogTitle: { type: String },
    tableRow: { type: Object }
})

const reload= inject("getList");
const state = reactive({
    dialogVisible: false,
    ruleForms: {
        id: "",
        name: "",

    },
});

watch(() => props.tableRow,

    () => {

        state.ruleForms.id = props.tableRow.id;
        state.ruleForms.name = props.tableRow.name;

    },

    { deep: true, immediate: true }


);

const { dialogVisible, ruleForms } = toRefs(state);

const dialogCategory = () => {
    state.dialogVisible = true;
}

const AddCate = () => {
    if (props.dialogTitle === "添加") {
        let param = {
            name: ruleForms.value.name,
        };

        console.log(param),
        axios.post("/Hello/Posts", param).then(() => {
            ElMessage.success("添加成功");
            state.dialogVisible = false; // close window
            reload();
           
        })
        
    } else {

        if (props.dialogTitle === "修改") {
            let param = {
                id: props.tableRow.id,
                name: ruleForms.value.name,
            }
            console.log(param);
            axios.put("/Category/Put", param).then(() => {
                ElMessage.success("修改成功");
                state.dialogVisible = false; // close window
            reload();
           

            })
        }
    }
}
const handleClosed =()=>{

    state.ruleForms.id = "";
  state.ruleForms.name = "";

}

defineExpose({
    dialogCategory
})
</script>
