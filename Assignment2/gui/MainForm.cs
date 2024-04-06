using Assignment2.data;
using Assignment2.utils;

namespace Assignment2.gui {

	// TODO: Add functionality to the MainForm
	internal class MainForm : BaseForm {
		private readonly bool _forceExit = false;
		private bool _updateMode = false;

		public MainForm() : base($"Water Fee Calculator") {
			if (core.ProgramEnvironment.CurrentAccount == null) {
				_forceExit = true;
				Load += (o, e) => Close();
				if (MessageBox.Show("No account logged. Move to login?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					new LoginForm().Show();
			} else {
				InitializeComponent();
				ConfigDataSource();
				ConfigInputBox();
				ConfigButton();
				FillComboBox();
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
				ShowDialog(owner);
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
			components = new System.ComponentModel.Container();
			customer_list_view = new DataGridView();
			inputPanel = new Panel();
			controlPanel = new Panel();
			cancelUpdate = new Button();
			update = new Button();
			delete = new Button();
			add = new Button();
			thisMonth = new TextBox();
			thisMonthLabel = new Label();
			lastMonth = new TextBox();
			lastMonthLabel = new Label();
			type = new ComboBox();
			typeLabel = new Label();
			name = new TextBox();
			nameLabel = new Label();
			error = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize) customer_list_view).BeginInit();
			inputPanel.SuspendLayout();
			controlPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) error).BeginInit();
			SuspendLayout();
			//
			// customer_list_view
			//
			customer_list_view.AllowUserToAddRows = false;
			customer_list_view.AllowUserToDeleteRows = false;
			customer_list_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			customer_list_view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			customer_list_view.Location = new Point(12, 156);
			customer_list_view.Name = "customer_list_view";
			customer_list_view.ReadOnly = true;
			customer_list_view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			customer_list_view.Size = new Size(756, 389);
			customer_list_view.TabIndex = 1;
			customer_list_view.CellFormatting += CellFormatting;
			customer_list_view.DoubleClick += OpenDetailForm;
			//
			// inputPanel
			//
			inputPanel.Controls.Add(controlPanel);
			inputPanel.Controls.Add(thisMonth);
			inputPanel.Controls.Add(thisMonthLabel);
			inputPanel.Controls.Add(lastMonth);
			inputPanel.Controls.Add(lastMonthLabel);
			inputPanel.Controls.Add(type);
			inputPanel.Controls.Add(typeLabel);
			inputPanel.Controls.Add(name);
			inputPanel.Controls.Add(nameLabel);
			inputPanel.Location = new Point(12, 27);
			inputPanel.Name = "inputPanel";
			inputPanel.Size = new Size(756, 123);
			inputPanel.TabIndex = 2;
			//
			// controlPanel
			//
			controlPanel.Controls.Add(cancelUpdate);
			controlPanel.Controls.Add(update);
			controlPanel.Controls.Add(delete);
			controlPanel.Controls.Add(add);
			controlPanel.Location = new Point(599, 3);
			controlPanel.Name = "controlPanel";
			controlPanel.Size = new Size(154, 117);
			controlPanel.TabIndex = 8;
			//
			// cancelUpdate
			//
			cancelUpdate.Dock = DockStyle.Top;
			cancelUpdate.Location = new Point(0, 69);
			cancelUpdate.Name = "cancelUpdate";
			cancelUpdate.Size = new Size(154, 23);
			cancelUpdate.TabIndex = 3;
			cancelUpdate.Text = "Cancel";
			cancelUpdate.UseVisualStyleBackColor = true;
			cancelUpdate.Visible = false;
			//
			// update
			//
			update.Dock = DockStyle.Top;
			update.Location = new Point(0, 46);
			update.Name = "update";
			update.Size = new Size(154, 23);
			update.TabIndex = 1;
			update.Text = "Update";
			//
			// delete
			//
			delete.Dock = DockStyle.Top;
			delete.Location = new Point(0, 23);
			delete.Name = "delete";
			delete.Size = new Size(154, 23);
			delete.TabIndex = 2;
			delete.Text = "Delete";
			//
			// add
			//
			add.Dock = DockStyle.Top;
			add.Location = new Point(0, 0);
			add.Name = "add";
			add.Size = new Size(154, 23);
			add.TabIndex = 0;
			add.Text = "Add";
			//
			// thisMonth
			//
			thisMonth.Location = new Point(78, 90);
			thisMonth.Name = "thisMonth";
			thisMonth.Size = new Size(222, 23);
			thisMonth.TabIndex = 7;
			//
			// thisMonthLabel
			//
			thisMonthLabel.AutoSize = true;
			thisMonthLabel.Location = new Point(5, 93);
			thisMonthLabel.Name = "thisMonthLabel";
			thisMonthLabel.Size = new Size(67, 15);
			thisMonthLabel.TabIndex = 6;
			thisMonthLabel.Text = "Last Month";
			//
			// lastMonth
			//
			lastMonth.Location = new Point(78, 61);
			lastMonth.Name = "lastMonth";
			lastMonth.Size = new Size(222, 23);
			lastMonth.TabIndex = 5;
			//
			// lastMonthLabel
			//
			lastMonthLabel.AutoSize = true;
			lastMonthLabel.Location = new Point(3, 64);
			lastMonthLabel.Name = "lastMonthLabel";
			lastMonthLabel.Size = new Size(67, 15);
			lastMonthLabel.TabIndex = 4;
			lastMonthLabel.Text = "Last Month";
			//
			// type
			//
			type.DropDownStyle = ComboBoxStyle.DropDownList;
			type.FormattingEnabled = true;
			type.Location = new Point(78, 32);
			type.Name = "type";
			type.Size = new Size(222, 23);
			type.TabIndex = 3;
			//
			// typeLabel
			//
			typeLabel.AutoSize = true;
			typeLabel.Location = new Point(3, 35);
			typeLabel.Name = "typeLabel";
			typeLabel.Size = new Size(31, 15);
			typeLabel.TabIndex = 2;
			typeLabel.Text = "Type";
			//
			// name
			//
			name.Location = new Point(78, 3);
			name.MaxLength = 48;
			name.Name = "name";
			name.Size = new Size(401, 23);
			name.TabIndex = 1;
			//
			// nameLabel
			//
			nameLabel.AutoSize = true;
			nameLabel.Location = new Point(5, 6);
			nameLabel.Name = "nameLabel";
			nameLabel.Size = new Size(42, 15);
			nameLabel.TabIndex = 0;
			nameLabel.Text = "Name:";
			nameLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// error
			//
			error.BlinkRate = 100;
			error.ContainerControl = this;
			//
			// MainForm
			//
			ClientSize = new Size(780, 557);
			Controls.Add(inputPanel);
			Controls.Add(customer_list_view);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			Name = "MainForm";
			Controls.SetChildIndex(customer_list_view, 0);
			Controls.SetChildIndex(inputPanel, 0);
			((System.ComponentModel.ISupportInitialize) customer_list_view).EndInit();
			inputPanel.ResumeLayout(false);
			inputPanel.PerformLayout();
			controlPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) error).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		private void CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e) {
			if (e.ColumnIndex == customer_list_view.Columns["PriceWithoutVAT"].Index || e.ColumnIndex == customer_list_view.Columns["VAT"].Index) {
				customer_list_view.Columns[e.ColumnIndex].Visible = false;
			}
			if (e.ColumnIndex == customer_list_view.Columns["Type"].Index && e.Value is CustomerType _type) {
				e.Value = _type.GetDescription();
			}
			if (e.ColumnIndex == customer_list_view.Columns["TotalPrice"].Index && e.Value is double price) {
				if (price < 0)
					e.Value = "N/A";
				else
					e.Value = $"{price:N1}";
			}
		}

		private void ConfigDataSource() {
			customer_list_view_source.DataSource = core.ProgramEnvironment.CustomersDatabase.GetValues();
			customer_list_view.DataSource = customer_list_view_source;
			customer_list_view.Columns["PriceWithoutVAT"].Visible = false;
			customer_list_view.Columns["VAT"].Visible = false;
		}

		private void FillComboBox() {
			List<CustomerType> customerTypes = Enum.GetValues(typeof(CustomerType)).Cast<CustomerType>().ToList();
			customerTypes.Remove(CustomerType.NotSet);
			type.DataSource = customerTypes;
			type.Format += (o, e) => {
				if (e.ListItem is CustomerType customerType)
					e.Value = customerType.GetDescription();
			};
		}

		private void OpenDetailForm(object? sender, EventArgs e) {
			if (_updateMode) {
				Log.w("Can't view detail while updating");
				return;
			}
			if (customer_list_view.SelectedRows.Count > 0) {
				Customer customer = (Customer) customer_list_view.SelectedRows[0].DataBoundItem;
				new CustomerDetailsForm(customer, this).ShowDialog();
			}
		}

		private void AddAction(object? sender, EventArgs e) {
			string Name;
			if (string.IsNullOrEmpty(name.Text)) {
				error.SetError(name, "Name is required");
				return;
			} else {
				error.SetError(name, "");
				Name = name.Text;
			}
			double LastMonth;
			if (string.IsNullOrEmpty(lastMonth.Text)) {
				error.SetError(lastMonth, "Last month is required");
				return;
			} else {
				if (!double.TryParse(lastMonth.Text, out LastMonth)) {
					error.SetError(lastMonth, "Last month is not a valid number");
					return;
				}
				error.SetError(lastMonth, "");
			}
			double ThisMonth;
			if (string.IsNullOrEmpty(thisMonth.Text)) {
				error.SetError(thisMonth, "This month is required");
				return;
			} else {
				if (!double.TryParse(thisMonth.Text, out ThisMonth)) {
					error.SetError(thisMonth, "This month is not a valid number");
					return;
				}
				error.SetError(thisMonth, "");
			}
			CustomerType Type;
			if (type.SelectedItem == null) {
				error.SetError(type, "Type is required");
				return;
			} else {
				error.SetError(type, "");
				Type = (CustomerType) type.SelectedItem;
			}
			if (LastMonth > ThisMonth) {
				error.SetError(lastMonth, "Last month cannot be greater than this month");
				return;
			} else {
				error.SetError(lastMonth, "");
			}
			Customer customer = new(Name, Type, LastMonth, ThisMonth);
			customer_list_view_source.Add(customer);
			name.Text = "";
			type.SelectedIndex = 0;
			lastMonth.Text = "";
			thisMonth.Text = "";
			customer_list_view.ClearSelection();
		}

		private void DeleteAction(object? sender, EventArgs e) {
			if (customer_list_view.SelectedRows.Count > 0) {
				Customer customer = (Customer) customer_list_view.SelectedRows[0].DataBoundItem;
				customer_list_view_source.Remove(customer);
				customer_list_view.ClearSelection();
			}
		}

		private void UpdateAction(object? sender, EventArgs e) {
			if (_updateMode) {
				if (customer_list_view.SelectedRows.Count <= 0) return;
				Customer customer = (Customer) customer_list_view.SelectedRows[0].DataBoundItem;
				Customer copyCustomer = new(customer.Name, customer.Type, customer.LastMonthUsage, customer.ThisMonthUsage);
				CustomerType Type = (CustomerType) type.SelectedItem;
				double LastMonth = double.Parse(lastMonth.Text);
				double ThisMonth = double.Parse(thisMonth.Text);
				if (LastMonth > ThisMonth) {
					error.SetError(lastMonth, "Last month cannot be greater than this month");
					return;
				} else {
					error.SetError(lastMonth, "");
				}
				copyCustomer.Type = Type;
				copyCustomer.LastMonthUsage = LastMonth;
				copyCustomer.ThisMonthUsage = ThisMonth;
				int index = customer_list_view_source.IndexOf(customer);
				customer_list_view_source.RemoveAt(index);
				if (customer_list_view_source.Count <= 0) {
					customer_list_view_source.Add(copyCustomer);
				} else {
					customer_list_view_source.Insert(index, copyCustomer);
				}
				customer_list_view.ClearSelection();
				name.Text = "";
				type.SelectedIndex = 0;
				lastMonth.Text = "";
				thisMonth.Text = "";
			} else {
				Text = "Update Mode";
				_updateMode = true;
				name.Enabled = false;
				add.Enabled = false;
				delete.Enabled = false;
				cancelUpdate.Visible = true;
				customer_list_view.SelectionChanged += UpdateMode;
				customer_list_view.ClearSelection();
			}
		}

		private void UpdateMode(object? sender, EventArgs e) {
			if (customer_list_view.SelectedRows.Count > 0) {
				Customer customer = (Customer) customer_list_view.SelectedRows[0].DataBoundItem;
				name.Text = customer.Name;
				type.SelectedItem = customer.Type;
				lastMonth.Text = customer.LastMonthUsage.ToString();
				thisMonth.Text = customer.ThisMonthUsage.ToString();
			}
		}

		private void CancelUpdateAction(object? sender, EventArgs e) {
			Text = "Water Fee Calculator";
			_updateMode = false;
			name.Enabled = true;
			add.Enabled = true;
			delete.Enabled = true;
			cancelUpdate.Visible = false;
			customer_list_view.SelectionChanged -= UpdateMode;
			name.Text = "";
			type.SelectedIndex = 0;
			lastMonth.Text = "";
			thisMonth.Text = "";
			customer_list_view.ClearSelection();
		}

		private void ConfigButton() {
			add.Click += AddAction;

			delete.Click += DeleteAction;

			update.Click += UpdateAction;

			cancelUpdate.Click += CancelUpdateAction;

			customer_list_view.SelectionChanged += (o, e) => {
				delete.Visible = customer_list_view.SelectedRows.Count > 0;
			};
			delete.Visible = customer_list_view.SelectedRows.Count > 0;
		}

		private void ConfigInputBox() {
			lastMonth.KeyPress += (o, e) => {
				if (o is null) return;
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
					e.Handled = true;
				}
				if ((e.KeyChar == '.') && (lastMonth.Text.IndexOf('.') > -1)) {
					e.Handled = true;
				}
			};
			thisMonth.KeyPress += (o, e) => {
				if (o is null) return;
				if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
					e.Handled = true;
				}
				if ((e.KeyChar == '.') && (thisMonth.Text.IndexOf('.') > -1)) {
					e.Handled = true;
				}
			};
		}

		private DataGridView customer_list_view;
		private Panel inputPanel;
		private TextBox name;
		private Label nameLabel;
		private ComboBox type;
		private Label typeLabel;
		private TextBox thisMonth;
		private Label thisMonthLabel;
		private TextBox lastMonth;
		private Label lastMonthLabel;
		private Panel controlPanel;
		private Button delete;
		private Button update;
		private Button add;
		private ErrorProvider error;
		private System.ComponentModel.IContainer components;
		private Button cancelUpdate;
		private readonly BindingSource customer_list_view_source = [];
	}
}