using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RedHorizonSite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public (string, string)[] Photos => [("./img/001.png", "Bulbasaur"), ("./img/004.png", "Charmander"), ("./img/007.png", "Squirtle"), ("./img/054.png", "Psyduck"), ("./img/446.png", "Munchlax"), ("./img/568.png", "Trubbish")];

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}

public record Show(string Date, string Location, string Description);