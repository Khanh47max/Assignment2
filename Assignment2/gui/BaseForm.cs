using Assignment2.core;

namespace Assignment2.gui {

	internal class BaseForm : Form {
		protected Color ControlForeColor = Color.White;
		protected Color ControlColor;

		public BaseForm(string title = "Untitled") {
			InitializeComponent();
			ConfigureColor();
			Text = title;
			SystemColor.onColorChanged += ColorChanged;
		}

		private void ConfigureColor() {
			SystemColor.GetColor(out Color color, Windows.UI.ViewManagement.UIColorType.Accent);
			// BackColor = Color.FromArgb(20, 20, 20);
			ControlColor = color;
			ColorChanged(ControlColor);
		}

		public void ColorChanged(Color color) {
			ControlColor = color;
			UpdateControls(Controls);
		}

		private void UpdateControls(Control.ControlCollection controls) {
			if (controls.Count <= 0) return;
			foreach (Control control in controls) {
				UpdateControls(control.Controls);
				control.BackColor = ControlColor;
				control.ForeColor = ControlForeColor;
				control.Invalidate();
			}
		}

		private void InitializeComponent() {
			SuspendLayout();
			Button b = new();
			TextBox textBox = new();
			b.Text = "Hello";
			textBox.Location = new Point(0, b.Bottom);
			Controls.Add(b);
			Controls.Add(textBox);
			Name = "BaseForm";
			StartPosition = FormStartPosition.CenterScreen;
			ResumeLayout(false);
		}
	}
}