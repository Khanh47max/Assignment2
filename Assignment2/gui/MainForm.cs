using Assignment2.data;

namespace Assignment2.gui {

	internal class MainForm : BaseForm {
		private readonly bool _forceExit = false;

		public MainForm() : base($"Water Fee Calculator") {
			if (core.ProgramEnvironment.CurrentAccount == null) {
				_forceExit = true;
				Load += (o, e) => Close();
				if (MessageBox.Show("No account logged. Move to login?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					new LoginForm().Show();
			} else {
				InitializeComponent();
				core.ProgramEnvironment.OnAccountLogout += () => Close();
			}
		}

		public new void Show() {
			if (_forceExit)
				Dispose();
			else
				Show(null);
		}

		public new void Show(IWin32Window? owner) {
			if (_forceExit)
				Dispose();
			else
				ShowDialog();
		}

		public new void ShowDialog() {
			if (_forceExit)
				Dispose();
			else
				ShowDialog(null);
		}

		public new void ShowDialog(IWin32Window? owner) {
			if (_forceExit)
				Dispose();
			else
				base.ShowDialog(owner);
		}

		private void InitializeComponent() {
			customer_list_view = new DataGridView();
			((System.ComponentModel.ISupportInitialize) customer_list_view).BeginInit();
			SuspendLayout();
			//
			// customer_list_view
			//
			customer_list_view.AllowUserToAddRows = false;
			customer_list_view.AllowUserToDeleteRows = false;
			customer_list_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			customer_list_view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			customer_list_view.Location = new Point(12, 241);
			customer_list_view.Name = "customer_list_view";
			customer_list_view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			customer_list_view.ReadOnly = true;
			customer_list_view.Size = new Size(756, 304);
			customer_list_view.TabIndex = 1;
			UpdateList();
			customer_list_view.CellFormatting += CellFormatting;
			//
			// MainForm
			//
			ClientSize = new Size(780, 557);
			Controls.Add(customer_list_view);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Name = "MainForm";
			Controls.SetChildIndex(customer_list_view, 0);
			((System.ComponentModel.ISupportInitialize) customer_list_view).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private void UpdateList() {
			customer_list_view_source.DataSource = core.ProgramEnvironment.CustomersDatabase.GetValues();
			customer_list_view.DataSource = customer_list_view_source;
			customer_list_view.Refresh();
		}

		private void CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
			if (e.ColumnIndex == customer_list_view.Columns["Type"].Index && e.Value is CustomerType type) {
				e.Value = type.GetDescription();
			}
			if (e.ColumnIndex == customer_list_view.Columns["TotalPrice"].Index && e.Value is double price) {
				if (price < 0)
					e.Value = "N/A";
				else
					e.Value = $"{price:N1}";
			}
		}

		private DataGridView customer_list_view;
		private readonly BindingSource customer_list_view_source = new();
	}
}