using AlanWeb.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//�[�W��Ʈw����T
builder.Services.AddDbContext<ApplicationDbContext>(options=>
//�ھ�connectionstring�إ߸�Ʈw���s�u  �ϥ�.net core tool��update-database��s��Ʈw����T
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// �i�󴫦�IsProduction .etc
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//�ϥ�HTTPS�A�O�K�ӷP�T�����w����
app.UseHttpsRedirection();
//�Ҧ��R�A�ɮץi�bwwwroot���o
app.UseStaticFiles();
//�T�O����q�L���Ѩ�A�����I
app.UseRouting();
//���Ҩ���(Cookie�BJWT�]JSON Web Token�^)
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
