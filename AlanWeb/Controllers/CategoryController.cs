using AlanWeb.data;
using AlanWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlanWeb.Controllers
{
    public class CategoryController : Controller
    {
        //連接model(資料庫)的資訊
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        //透過asp-for將model傳入到這
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //透過後端處理錯誤
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                //在Name欄位下顯示
                ModelState.AddModelError("Name", "名稱不能和展示順序一樣");
            }
            if (obj.Name != null && obj.Name!.ToLower() == "test")
            {
                ModelState.AddModelError("", "名稱不能輸入測試");
            }
            // ModelState.IsValid是否通過根據model.category設置的reflection
            if (ModelState.IsValid) 
            {
                //紀錄要添加的內容
                _db.Categories.Add(obj);
                //到資料庫更新資料
                _db.SaveChanges();
                //切換至其他的Action([name,controller])
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        //透過asp-route-id傳到controller
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            //第一種方式
            Category? categoryFromDb = _db.Categories.Find(id);
            //第二種方式
            Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //第三種方式
            Category? categoryFromDb3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
        }
        //透過asp-for將model傳入到這
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //透過後端處理錯誤
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //在Name欄位下顯示
                ModelState.AddModelError("Name", "名稱不能和展示順序一樣");
            }
            if (obj.Name != null && obj.Name!.ToLower() == "test")
            {
                ModelState.AddModelError("", "名稱不能輸入測試");
            }
            // ModelState.IsValid是否通過根據model.category設置的reflection
            if (ModelState.IsValid)
            {
                //紀錄要添加的內容
                _db.Categories.Add(obj);
                //到資料庫更新資料
                _db.SaveChanges();
                //切換至其他的Action([name,controller])
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
