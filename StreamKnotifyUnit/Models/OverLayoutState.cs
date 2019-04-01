using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamKnotifyUnit.Models
{
    public class OverLayoutState
    {
        public event EventHandler StateChanged;
        public bool ShowConfigureDialog { get; private set; }
        //handle overlays state
       public void AddConfiguredOverlay()
        {
            StateHasChanged();
        }
        public void RemoveConfiguredOverlay()
        {
            StateHasChanged();
        }
        public void ResetLayouts()
        {

        }
        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
