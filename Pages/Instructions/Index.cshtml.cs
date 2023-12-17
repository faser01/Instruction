using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Instruction.Pages.Instructions
{
    public class IndexModel : PageModel
    {
        private readonly Dictionary<string, Dictionary<string, string>> _instructions;
        public IndexModel()
        {
            _instructions = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "ruOfficial", new Dictionary<string, string>
                    {
                        {"teaBag", "Инструкция по завариванию чая в пакетике"},
                        {"looseTea", "Инструкция по завариванию листового чая"}
                    }
                },
                {
                    "ruConversational", new Dictionary<string, string>
                    {
                        {"teaBag", "Инструкция по завариванию чая в пакетике (разговорный)"},
                        {"looseTea", "Инструкция по завариванию листового чая (разговорный)"}
                    }
                },
                {
                    "en", new Dictionary<string, string>
                    {
                        {"teaBag", "Tea Bag Brewing Instructions"},
                        {"looseTea", "Loose Leaf Tea Brewing Instructions"}
                    }
                }
            };
        }

        [BindProperty(SupportsGet = true)]
        public string SelectedLanguage { get; set; } = "ruOfficial";

        public List<SelectListItem> LanguageOptions => new List<SelectListItem>
        {
            new SelectListItem("Russian (Official)", "ruOfficial"),
            new SelectListItem("Russian (Conversational)", "ruConversational"),
            new SelectListItem("English", "en")
        };

        public string InstructionTitle => _instructions[SelectedLanguage]["teaBag"];

        public string InstructionContent => _instructions[SelectedLanguage]["looseTea"];

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Instructions/Index", new { selectedLanguage = SelectedLanguage });
        }
    }
}
