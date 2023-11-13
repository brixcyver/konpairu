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

        [ObservableProperty]
        public string expression;

        [RelayCommand]
        private async Task ChooseFileAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                var javaFile = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Choose a java file"
                });

                if (javaFile is null)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Cancelled!",
                        $"Choosing a file cancelled", "OK");

                    return;
                }

                if (!javaFile.FileName.EndsWith("java", StringComparison.OrdinalIgnoreCase))
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Invalid File!",
                        $"File chosen is not a java file", "OK");

                    return;
                }

                using var stream = await javaFile.OpenReadAsync(); 

                using (StreamReader sr = new StreamReader(stream))
                {
                    StringBuilder sb = new();

                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }

                    Expression = sb.ToString();
                }

                await Shell.Current.CurrentPage.DisplayAlert("Success!",
                    $"File has been added", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to add file: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task LexicalAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                await Shell.Current.CurrentPage.DisplayAlert("Correct!",
                    $"The expression has a valid lexemes", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to analyze lexemes: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SemanticAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                await Shell.Current.CurrentPage.DisplayAlert("Correct!",
                    $"The expression has a valid semantics", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to analyze semantics: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SyntacticalAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                await Shell.Current.CurrentPage.DisplayAlert("Correct!",
                    $"The expression has a valid syntax", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to analyze syntax: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        [RelayCommand]
        private async Task ClearExpressionAsync()
        {
            if (IsBusy)
            {
                return;
            }

            bool isConfirmed = await Shell.Current.CurrentPage.DisplayAlert("Clear Expression", "Are you sure you want to clear the expression?",
                            "Yes", "No");

            if (!isConfirmed)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Cancelled!",
                    $"Clearing expression cancelled", "OK");

                return;
            }

            IsBusy = true;

            try
            {
                Expression = string.Empty;

                await Shell.Current.CurrentPage.DisplayAlert("Success!",
                    $"The expression has a valid lexemes", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to clear expression: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
