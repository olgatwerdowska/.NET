using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Mvc4.Models;
using System.Collections.Generic;


namespace Mvc4.Controllers
{
  public class TestController : Controller
{
    // 
    // GET: /HelloWorld/

    public string Index()
    {
        return "This is my default action...";
    }

    // 
    // GET: /HelloWorld/Welcome/ 

    public string Welcome()
    {
        return "This is the Welcome action method...";
    }

    public IActionResult TestModel()
    {
        var model = new List<TestModel>
        {
            new TestModel {TypeProdukt = "Apple" , Price = 3.5 , Description = "sweet"},
            new TestModel {TypeProdukt = "Lime" , Price = 6 , Description = "sour"},
            new TestModel {TypeProdukt = "Banana" , Price = 4.5 , Description = "sweet"},
            new TestModel {TypeProdukt = "Apple Green" , Price = 2.5 , Description = "sweet"}
        };
         
        return View(model);
    }
}
}