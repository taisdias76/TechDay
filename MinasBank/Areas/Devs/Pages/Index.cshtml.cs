using Microsoft.AspNetCore.Mvc.RazorPages;
using MinasBank.Areas.Devs.Services;
using MinasBank.Areas.Devs.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinasBank.Areas.Devs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDevService _devService;

        public IEnumerable<Dev> Devs { get; set; } = new List<Dev>();

        public IndexModel(IDevService devService)
        {
            _devService = devService;
        }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            Devs = await _devService.ObterTodos(cancellationToken);
        }
    }
}
