using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konpairu
{
    public partial class KonpairuViewModel : ObservableObject
    {
        public KonpairuViewModel()
        {
            Title = "Konpairu";
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        [ObservableProperty]
        private string title;

        public bool IsNotBusy => !IsBusy;
    }
}
