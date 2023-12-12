using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Konpairu.Models;
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

            isLexicallyCorrect = false;
            isSyntacticallyCorrect = false;

            prevExpression = string.Empty;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        [ObservableProperty]
        private string title;

        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        public string expression;

        private string prevExpression;

        private bool isLexicallyCorrect;
        private bool isSyntacticallyCorrect;

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
                    PickerTitle = "Choose a Java file"
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
                        $"File chosen is not a Java file", "OK");

                    return;
                }

                using var stream = await javaFile.OpenReadAsync();

                using (StreamReader sr = new(stream))
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
                if (Expression is null || Expression == string.Empty)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Empty Expression!",
                        $"The expression is empty", "OK");

                    return;
                }

                if (!LexicalAnalyzer.IsLexicallyCorrect(Expression.Replace("\r", "")))
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Incorrect!",
                        $"The expression is lexically incorrect", "OK");

                    return;
                }

                isLexicallyCorrect = true;
                prevExpression = Expression;

                await Shell.Current.CurrentPage.DisplayAlert("Correct!",
                    $"The expression was a valid lexemes", "OK");
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
        private async Task SyntacticalAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                if (Expression != prevExpression || !isLexicallyCorrect)
                {
                    isLexicallyCorrect = false;
                    isSyntacticallyCorrect = false;

                    await Shell.Current.CurrentPage.DisplayAlert("Cannot Validate!",
                        $"Please analyze lexically first", "OK");

                    return;
                }

                if (!SyntaxAnalyzer.IsSyntacticallyCorrect(Expression.Replace("\r", "")))
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Incorrect!",
                        $"The expression is syntactically incorrect", "OK");

                    return;
                }

                if (Expression is null || Expression == string.Empty)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Empty Expression!",
                        $"The expression is empty", "OK");

                    return;
                }

                isSyntacticallyCorrect = true;
                prevExpression = Expression;

                await Shell.Current.CurrentPage.DisplayAlert("Correct!",
                    $"The expression is a valid syntax", "OK");
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
        private async Task SemanticAnalysisAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                if (Expression != prevExpression || !isSyntacticallyCorrect)
                {
                    isLexicallyCorrect = false;
                    isSyntacticallyCorrect = false;

                    await Shell.Current.CurrentPage.DisplayAlert("Cannot Validate!",
                        $"Please analyze syntactically first", "OK");

                    return;
                }

                if (!isSyntacticallyCorrect)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Cannot Validate!",
                        $"Please analyze syntactically first", "OK");

                    return;
                }

                if (Expression is null || Expression == string.Empty)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Empty Expression!",
                        $"The expression is empty", "OK");

                    return;
                }

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
                    $"The expression has been cleared", "OK");
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
