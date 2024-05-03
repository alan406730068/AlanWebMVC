using AlanWeb.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//加上資料庫的資訊
builder.Services.AddDbContext<ApplicationDbContext>(options=>
//根據connectionstring建立資料庫的連線  使用.net core tool的update-database更新資料庫的資訊
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 可更換成IsProduction .etc
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//使用HTTPS，保密敏感訊息的安全性
app.UseHttpsRedirection();
//所有靜態檔案可在wwwroot取得
app.UseStaticFiles();
//確保能夠通過路由到適當的端點
app.UseRouting();
//驗證身分(Cookie、JWT（JSON Web Token）)
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
