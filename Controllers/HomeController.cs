using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Newtonsoft.Json;
using EmailTemplateApp.Models;
using System.IO;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _env;

    public HomeController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult Index()
    {
        // Load email templates from JSON file
        var emailTemplates = LoadEmailTemplatesFromJson();
        ViewBag.EmailTemplates = emailTemplates;

        return View();
    }

    private List<EmailTemplate> LoadEmailTemplatesFromJson()
    {
        var path = Path.Combine(_env.ContentRootPath, "App_Data", "EmailTemplates.json");
        var json = System.IO.File.ReadAllText(path);
        var emailTemplates = JsonConvert.DeserializeObject<List<EmailTemplate>>(json);

        return emailTemplates ?? new List<EmailTemplate>();
    }

}
