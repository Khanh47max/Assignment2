using Assignment2.core;

namespace Assignment2.gui {

	internal class BaseForm : Form {

		public BaseForm() {
			InitializeComponent();
			ConfigureColor();
			SystemColor.colorChanged += ColorChanged;
		}

		private void ConfigureColor() {
			SystemColor.GetAccentColor(out Color backColor);
			BackColor = backColor;
		}

		public void ColorChanged(Color color) {
			BackColor = color;
		}

		private void InitializeComponent() {
		}
	}
}