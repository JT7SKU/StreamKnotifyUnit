using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace StreamKomponentUnit.Toasty
{
    public class ExampleJsInterop
    {
        public static Task<string> Prompt(IJSRuntime jsRuntime, string message)
        {
            // Implemented in exampleJsInterop.js
            return jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                message);
        }
    }
}
