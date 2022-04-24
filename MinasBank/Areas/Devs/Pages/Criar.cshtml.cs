using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinasBank.Areas.Devs.Services;
using MinasBank.Areas.Devs.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MinasBank.Areas.Devs.Pages
{
    public class CriarModel : PageModel
    {
        private readonly IDevService _devService;

        [BindProperty]
        public Dev Dev { get; set; } = new Dev();

        public CriarModel(IDevService devService)
        {
            _devService = devService;
        }

        public async Task OnGetAsync([FromRoute] Guid? id, CancellationToken cancellationToken)
        {
            if (id.HasValue)
            {
                Dev = await _devService.ObterPorId(id.Value, cancellationToken).ConfigureAwait(false);
            }
           
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _devService.Adicionar(Dev, cancellationToken).ConfigureAwait(false);
            if (!result)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostUpdateAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _devService.Alterar(Dev, cancellationToken).ConfigureAwait(false);
            if (!result)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("Index");
        }
    }
}
