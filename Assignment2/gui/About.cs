namespace Assignment2.gui {

	internal partial class About : Form {

		public About() {
			InitializeComponent();
			Text = "About";
			labelProductName.Text = "Product name: Water fee calculator";
			labelVersion.Text = "Version: beta";
			labelCopyright.Text = "Author: HuyMaster";
			textBoxDescription.Text = "Description:" +
				"\nDo you have any idea about description?";
		}
	}
}