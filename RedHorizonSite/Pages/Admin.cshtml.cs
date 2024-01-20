using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedHorizonSite.Data;

namespace RedHorizonSite.Pages;

public class AdminModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    [BindProperty]
    [Required]
    public string ShowDate {get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
    [BindProperty]
    [Required(AllowEmptyStrings = false)]
    public string Location {get; set; }
    [BindProperty]
    [Required(AllowEmptyStrings = false, ErrorMessage ="Description cannot be null or empty")]
    public string Description {get; set; }

    public AdminModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await Task.Delay(1);

        Console.WriteLine($"{ShowDate} {Location} {Description}");

        var service = new ShowService();
        await service.AddShowAsync(new Data.Show(ShowDate, Location, Description));

        return Page();
    }
}
public record NewShow(DateTime Date, string Location, string Description);
