using Assignment2.utils;

namespace Assignment2.gui {

	internal partial class BaseForm : Form {
		private MenuStrip menu;
		private ToolStripMenuItem options_menu;
		private ToolStripMenuItem about_menu;
		private ToolStripMenuItem console_options_menu;

		public BaseForm() : this(null) {
		}

		public BaseForm(string? title) {
			InitializeComponent();
			ConfigureEvent();
			Text = title ?? GetType().Name;
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
			base.ShowDialog(owner);
		}

		private void InitializeComponent() {
			menu = new MenuStrip();
			options_menu = new ToolStripMenuItem();
			console_options_menu = new ToolStripMenuItem();
			about_menu = new ToolStripMenuItem();
			menu.SuspendLayout();
			SuspendLayout();
			//
			// menu
			//
			menu.Items.AddRange(new ToolStripItem[] { options_menu, about_menu });
			menu.Location = new Point(0, 0);
			menu.Name = "menu";
			menu.Size = new Size(284, 24);
			menu.TabIndex = 0;
			menu.Text = "menuStrip1";
			//
			// options_menu
			//
			options_menu.DropDownItems.AddRange(new ToolStripItem[] { console_options_menu });
			options_menu.Name = "options_menu";
			options_menu.ShowShortcutKeys = false;
			options_menu.Size = new Size(61, 20);
			options_menu.Text = "Options";
			//
			// console_options_menu
			//
			console_options_menu.Checked = true;
			console_options_menu.CheckOnClick = true;
			console_options_menu.CheckState = CheckState.Checked;
			console_options_menu.Name = "console_options_menu";
			console_options_menu.ShowShortcutKeys = false;
			console_options_menu.Size = new Size(180, 22);
			console_options_menu.Text = "Console Window";
			//
			// about_menu
			//
			about_menu.Name = "about_menu";
			about_menu.ShowShortcutKeys = false;
			about_menu.Size = new Size(52, 20);
			about_menu.Text = "About";
			about_menu.Click += OpenAbout;
			//
			// BaseForm
			//
			TopMost = true;
			ClientSize = new Size(284, 261);
			Controls.Add(menu);
			MainMenuStrip = menu;
			Name = "BaseForm";
			StartPosition = FormStartPosition.CenterParent;
			menu.ResumeLayout(false);
			menu.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void ConfigureEvent() {
			FormClosed += (o, e) => {
				Log.i($"GUI {GetType().FullName} closed");
				Dispose();
			};
			console_options_menu.Click += (o, e) => {
				int show = DLLIntermediate.SW_RESTORE;
				int hide = DLLIntermediate.SW_HIDE;
				DLLIntermediate.ShowWindow(DLLIntermediate.GetConsoleWindow(), console_options_menu.Checked ? show : hide);
			};
		}

		private void OpenAbout(object? sender, EventArgs e) {
			new About().ShowDialog(this);
		}
	}
}