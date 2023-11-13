using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [RelayCommand]
        private async Task CheckLexicalAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to check Lexical Analysis {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        [RelayCommand]
        private async Task CheckSemanticAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to check Lexical Analysis {ex.Message}", "OK");
            }
            finally
            {

            }
        }

        [RelayCommand]
        private async Task CheckSyntacticalAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to check Lexical Analysis {ex.Message}", "OK");
            }
            finally
            {

            }
        }
    }
}
