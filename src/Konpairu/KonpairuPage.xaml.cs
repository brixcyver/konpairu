namespace Konpairu;

public partial class KonpairuPage : ContentPage
{
	public KonpairuPage(KonpairuViewModel konpairuViewModel)
	{
		BindingContext = konpairuViewModel;

		InitializeComponent();
	}
}