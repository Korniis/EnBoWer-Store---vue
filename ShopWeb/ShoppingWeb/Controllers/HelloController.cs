using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingWeb.Data;
using ShoppingWeb.Models;
namespace ShoppingWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelloController : ControllerBase
    {  //初始化 依赖注入
        private readonly MyDbContext ctx;
        public HelloController(MyDbContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetList()
        {
            var List = await ctx.Categories.ToListAsync(); 
            return List;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetList(int id)
        {
            var List = await ctx.Categories.FindAsync(id);

            if (List == null)
            {
                return NotFound();
            }
            return List;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Posts(Category model)
        { 


            await ctx.Categories.AddAsync(model);

            return await ctx.SaveChangesAsync();
        }
        [HttpPut]
        public async Task<ActionResult<Category>> Put(Category model)
        {


            var List = await ctx.Categories.FindAsync(model.Id);

            if (List == null)
            {
                return NotFound();
            }
            List.Name = model.Name;
            await ctx.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete (int id)
        {

           var c= await ctx.Categories.FindAsync(id);
            if(c == null) 
            {
                return NotFound();
            }
            ctx.Remove(c);
            return  await ctx.SaveChangesAsync();
           


        }
    }
}
