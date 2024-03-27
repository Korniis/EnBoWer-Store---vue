<template>


    <el-dialog v-model="dialogVisible" :title="dialogTitle" width="50%">
        asdasdasfa
        <el-form :model="form" label-width=120px>
            <el-form-item label="分类">
                <el-input v-model="ruleForms.name" />
            </el-form-item>

        </el-form>
        <template #footer>
            <div class="dialog-footer">
                <el-button @click="dialogVisible = false">Cancel</el-button>
                <el-button @click="AddCate" type="primary">
                    Confirm
                </el-button>
            </div>
        </template>
    </el-dialog>
</template>

<script setup>
import { reactive, toRefs } from 'vue'
import { ElMessageBox } from 'element-plus'


const props = defineProps({
    dialogTitle: {
        type: String,


    }
})

const state = reactive({

    dialogVisible: false,

    ruleForms: {

        id: "",
        name: "图书",

    }

});

const { dialogVisible, ruleForms } = toRefs(state);

const dialogCategory = () => {
    state.dialogVisible = true;

}

if (props.dialogTitle === "分类") {
    let param = {

        name: ruleForms.value.name,

    }

    axios.post("/Category",param).then(()=>{


    })

}




const AddCate = () => {


}

defineExpose({

    dialogCategory

})


//   const handleClose = (done: () => void) => {
//     ElMessageBox.confirm('Are you sure to close this dialog?')
//       .then(() => {
//         done()
//       })
//       .catch(() => {
//         // catch error
//       })
//   }
</script>