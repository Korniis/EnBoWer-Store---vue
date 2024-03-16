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
    }
}
