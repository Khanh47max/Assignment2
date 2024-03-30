using Assignment2.core;
using Assignment2.utils;

namespace Assignment2.gui {

	internal class BaseForm : Form, IDisposable {

		protected event ThemeChanged OnThemeChange;

		protected Color ControlForeColor = Settings.Default.DarkMode ? Color.White : Color.Black;
		private MenuStrip menu;
		private ToolStripMenuItem options_menu;
		private ToolStripMenuItem darkMode_options_menu;
		protected Color ControlColor;

		public BaseForm(string? title = null) {
			InitializeComponent();
			ConfigureEvent();
			Text = title ?? GetType().Name;
			Load += (o, e) => {
				SystemColor.onColorChanged += ColorChanged;
				ConfigureColor();
				OnThemeChange.DynamicInvoke();
			};
		}

		private void ConfigureColor() {
			OnThemeChange += ThemeChange;
			SystemColor.GetColor(out Color color, Windows.UI.ViewManagement.UIColorType.Accent);
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

		private void ThemeChange() {
			BackColor = Settings.Default.DarkMode ? Color.FromArgb(20, 20, 20) : Color.FromArgb(220, 220, 220);
			ControlForeColor = Settings.Default.DarkMode ? Color.White : Color.Black;
			SystemColor.TriggerUpdate();
		}

		public new void Show() {
			Show(null);
		}

		public new void Show(IWin32Window? owner) {
			ShowDialog(owner);
		}

		public new void ShowDialog() {
			ShowDialog(null);
		}

		public new void ShowDialog(IWin32Window? owner) {
			Log.i($"GUI {GetType().FullName} showing");
			base.ShowDialog();
		}

		public new void Dispose() {
			base.Dispose();
			Log.i($"GUI {GetType().FullName} closed");
		}

		private void InitializeComponent() {
			menu = new MenuStrip();
			options_menu = new ToolStripMenuItem();
			darkMode_options_menu = new ToolStripMenuItem();
			menu.SuspendLayout();
			SuspendLayout();
			//
			// menu
			//
			menu.Items.AddRange(new ToolStripItem[] { options_menu });
			menu.Location = new Point(0, 0);
			menu.Name = "menuStrip1";
			menu.Size = new Size(284, 24);
			menu.TabIndex = 0;
			menu.Text = "menuStrip1";
			//
			// options_menu
			//
			options_menu.DropDownItems.AddRange(new ToolStripItem[] { darkMode_options_menu });
			options_menu.Name = "optionsToolStripMenuItem";
			options_menu.Size = new Size(61, 20);
			options_menu.Text = "Options";
			//
			// darkMode_options_menu
			//
			darkMode_options_menu.Name = "darkModeToolStripMenuItem";
			darkMode_options_menu.ShowShortcutKeys = false;
			darkMode_options_menu.Size = new Size(180, 22);
			darkMode_options_menu.Text = "Dark Mode";
			//
			// BaseForm
			//
			ClientSize = new Size(284, 261);
			Controls.Add(menu);
			MainMenuStrip = menu;
			Name = "BaseForm";
			StartPosition = FormStartPosition.CenterScreen;
			menu.ResumeLayout(false);
			menu.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void ConfigureEvent() {
			darkMode_options_menu.Click += (o, e) => {
				darkMode_options_menu.Checked = !darkMode_options_menu.Checked;
				Settings.Default.DarkMode = darkMode_options_menu.Checked;
				OnThemeChange.Invoke();
			};
		}

		protected delegate void ThemeChanged();
	}
}