namespace AutomatedTestingFramework.Core.Controls
{
	public interface IDropDown : IContentElement
	{
		string SelectedValue { get; }
		void SelectValue(string value);
		void SelectText(string value);
	}
}