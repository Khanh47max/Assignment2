using Assignment2.data;
using System.Drawing.Printing;

namespace Assignment2.gui {

	internal class CustomerDetailsForm : BaseForm {
		private readonly Customer _customer;
		private Label vat;
		private Label vatLabel;
		private readonly Form _parent;

		public CustomerDetailsForm(Customer customer, Form parent) : base("User Details") {
			_customer = customer;
			_parent = parent;
			InitializeComponent();
			ConfigureMenuItem();
			ConfigurePrintAction();
			RegisterEvent();
			FillContent();
		}

		private void InitializeComponent() {
			name_label = new Label();
			typeLabel = new Label();
			addTimeLabel = new Label();
			lastMonthLabel = new Label();
			thisMonthLabel = new Label();
			totalUsageLabel = new Label();
			priceLabel = new Label();
			epfLabel = new Label();
			totalPriceLabel = new Label();
			name = new Label();
			type = new Label();
			addTime = new Label();
			lastMonth = new Label();
			thisMonth = new Label();
			totalUsage = new Label();
			price = new Label();
			epf = new Label();
			totalPrice = new Label();
			statusMenu = new StatusStrip();
			idLabel = new ToolStripStatusLabel();
			printMenuItem = new ToolStripMenuItem();
			panel = new Panel();
			vat = new Label();
			vatLabel = new Label();
			statusMenu.SuspendLayout();
			panel.SuspendLayout();
			SuspendLayout();
			//
			// name_label
			//
			name_label.AutoSize = true;
			name_label.Font = new Font("Segoe UI", 9.75F);
			name_label.Location = new Point(11, 18);
			name_label.Name = "name_label";
			name_label.Size = new Size(46, 17);
			name_label.TabIndex = 2;
			name_label.Text = "Name:";
			name_label.TextAlign = ContentAlignment.MiddleLeft;
			//
			// typeLabel
			//
			typeLabel.AutoSize = true;
			typeLabel.Font = new Font("Segoe UI", 9.75F);
			typeLabel.Location = new Point(11, 47);
			typeLabel.Name = "typeLabel";
			typeLabel.Size = new Size(38, 17);
			typeLabel.TabIndex = 4;
			typeLabel.Text = "Type:";
			typeLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// addTimeLabel
			//
			addTimeLabel.AutoSize = true;
			addTimeLabel.Font = new Font("Segoe UI", 9.75F);
			addTimeLabel.Location = new Point(10, 76);
			addTimeLabel.Name = "addTimeLabel";
			addTimeLabel.Size = new Size(84, 17);
			addTimeLabel.TabIndex = 6;
			addTimeLabel.Text = "Time created";
			addTimeLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// lastMonthLabel
			//
			lastMonthLabel.AutoSize = true;
			lastMonthLabel.Font = new Font("Segoe UI", 9.75F);
			lastMonthLabel.Location = new Point(11, 123);
			lastMonthLabel.Name = "lastMonthLabel";
			lastMonthLabel.Size = new Size(72, 17);
			lastMonthLabel.TabIndex = 8;
			lastMonthLabel.Text = "Last month";
			lastMonthLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// thisMonthLabel
			//
			thisMonthLabel.AutoSize = true;
			thisMonthLabel.Font = new Font("Segoe UI", 9.75F);
			thisMonthLabel.Location = new Point(11, 152);
			thisMonthLabel.Name = "thisMonthLabel";
			thisMonthLabel.Size = new Size(72, 17);
			thisMonthLabel.TabIndex = 10;
			thisMonthLabel.Text = "This month";
			thisMonthLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// totalUsageLabel
			//
			totalUsageLabel.AutoSize = true;
			totalUsageLabel.Font = new Font("Segoe UI", 9.75F);
			totalUsageLabel.Location = new Point(11, 181);
			totalUsageLabel.Name = "totalUsageLabel";
			totalUsageLabel.Size = new Size(36, 17);
			totalUsageLabel.TabIndex = 12;
			totalUsageLabel.Text = "Total";
			totalUsageLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// priceLabel
			//
			priceLabel.AutoSize = true;
			priceLabel.Font = new Font("Segoe UI", 9.75F);
			priceLabel.Location = new Point(11, 228);
			priceLabel.Name = "priceLabel";
			priceLabel.Size = new Size(36, 17);
			priceLabel.TabIndex = 14;
			priceLabel.Text = "Price";
			priceLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// epfLabel
			//
			epfLabel.AutoSize = true;
			epfLabel.Font = new Font("Segoe UI", 9.75F);
			epfLabel.Location = new Point(11, 257);
			epfLabel.Name = "epfLabel";
			epfLabel.Size = new Size(28, 17);
			epfLabel.TabIndex = 16;
			epfLabel.Text = "EPF";
			epfLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// totalPriceLabel
			//
			totalPriceLabel.AutoSize = true;
			totalPriceLabel.Font = new Font("Segoe UI", 9.75F);
			totalPriceLabel.Location = new Point(11, 315);
			totalPriceLabel.Name = "totalPriceLabel";
			totalPriceLabel.Size = new Size(36, 17);
			totalPriceLabel.TabIndex = 19;
			totalPriceLabel.Text = "Total";
			totalPriceLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// name
			//
			name.BorderStyle = BorderStyle.FixedSingle;
			name.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			name.Location = new Point(93, 15);
			name.Name = "name";
			name.Size = new Size(292, 23);
			name.TabIndex = 3;
			//
			// type
			//
			type.BorderStyle = BorderStyle.FixedSingle;
			type.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			type.Location = new Point(93, 44);
			type.Name = "type";
			type.Size = new Size(292, 23);
			type.TabIndex = 5;
			//
			// addTime
			//
			addTime.BorderStyle = BorderStyle.FixedSingle;
			addTime.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			addTime.Location = new Point(93, 73);
			addTime.Name = "addTime";
			addTime.Size = new Size(291, 23);
			addTime.TabIndex = 7;
			//
			// lastMonth
			//
			lastMonth.BorderStyle = BorderStyle.FixedSingle;
			lastMonth.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			lastMonth.Location = new Point(93, 120);
			lastMonth.Name = "lastMonth";
			lastMonth.Size = new Size(292, 23);
			lastMonth.TabIndex = 9;
			//
			// thisMonth
			//
			thisMonth.BorderStyle = BorderStyle.FixedSingle;
			thisMonth.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			thisMonth.Location = new Point(93, 149);
			thisMonth.Name = "thisMonth";
			thisMonth.Size = new Size(292, 23);
			thisMonth.TabIndex = 11;
			//
			// totalUsage
			//
			totalUsage.BorderStyle = BorderStyle.FixedSingle;
			totalUsage.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			totalUsage.Location = new Point(93, 178);
			totalUsage.Name = "totalUsage";
			totalUsage.Size = new Size(292, 23);
			totalUsage.TabIndex = 13;
			//
			// price
			//
			price.BorderStyle = BorderStyle.FixedSingle;
			price.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			price.Location = new Point(93, 225);
			price.Name = "price";
			price.Size = new Size(292, 23);
			price.TabIndex = 15;
			//
			// epf
			//
			epf.BorderStyle = BorderStyle.FixedSingle;
			epf.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			epf.Location = new Point(93, 254);
			epf.Name = "epf";
			epf.Size = new Size(292, 23);
			epf.TabIndex = 17;
			//
			// totalPrice
			//
			totalPrice.BorderStyle = BorderStyle.FixedSingle;
			totalPrice.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			totalPrice.Location = new Point(93, 312);
			totalPrice.Name = "totalPrice";
			totalPrice.Size = new Size(292, 23);
			totalPrice.TabIndex = 18;
			//
			// statusMenu
			//
			statusMenu.Font = new Font("Segoe UI", 9.75F);
			statusMenu.Items.AddRange(new ToolStripItem[] { idLabel });
			statusMenu.Location = new Point(0, 369);
			statusMenu.Name = "statusMenu";
			statusMenu.Size = new Size(397, 22);
			statusMenu.TabIndex = 1;
			statusMenu.Text = "statusMenu";
			//
			// idLabel
			//
			idLabel.BackColor = SystemColors.ControlLightLight;
			idLabel.Font = new Font("Segoe UI", 9.75F);
			idLabel.Name = "idLabel";
			idLabel.Size = new Size(50, 17);
			idLabel.Text = "idLabel";
			//
			// printMenuItem
			//
			printMenuItem.Name = "printMenuItem";
			printMenuItem.Size = new Size(32, 19);
			printMenuItem.Text = "Print";
			//
			// panel
			//
			panel.BackColor = SystemColors.ControlLightLight;
			panel.BorderStyle = BorderStyle.FixedSingle;
			panel.Controls.Add(totalPrice);
			panel.Controls.Add(totalPriceLabel);
			panel.Controls.Add(vat);
			panel.Controls.Add(vatLabel);
			panel.Controls.Add(epf);
			panel.Controls.Add(epfLabel);
			panel.Controls.Add(price);
			panel.Controls.Add(priceLabel);
			panel.Controls.Add(totalUsage);
			panel.Controls.Add(totalUsageLabel);
			panel.Controls.Add(thisMonth);
			panel.Controls.Add(thisMonthLabel);
			panel.Controls.Add(lastMonth);
			panel.Controls.Add(lastMonthLabel);
			panel.Controls.Add(addTime);
			panel.Controls.Add(addTimeLabel);
			panel.Controls.Add(type);
			panel.Controls.Add(typeLabel);
			panel.Controls.Add(name);
			panel.Controls.Add(name_label);
			panel.Dock = DockStyle.Fill;
			panel.Font = new Font("Segoe UI", 9.75F);
			panel.Location = new Point(0, 24);
			panel.Name = "panel";
			panel.Size = new Size(397, 345);
			panel.TabIndex = 20;
			//
			// vat
			//
			vat.BorderStyle = BorderStyle.FixedSingle;
			vat.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
			vat.Location = new Point(93, 283);
			vat.Name = "vat";
			vat.Size = new Size(292, 23);
			vat.TabIndex = 21;
			//
			// vatLabel
			//
			vatLabel.AutoSize = true;
			vatLabel.Font = new Font("Segoe UI", 9.75F);
			vatLabel.Location = new Point(11, 286);
			vatLabel.Name = "vatLabel";
			vatLabel.Size = new Size(29, 17);
			vatLabel.TabIndex = 20;
			vatLabel.Text = "VAT";
			vatLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			// CustomerDetailsForm
			//
			ClientSize = new Size(397, 391);
			Controls.Add(panel);
			Controls.Add(statusMenu);
			FormBorderStyle = FormBorderStyle.Fixed3D;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "CustomerDetailsForm";
			Controls.SetChildIndex(statusMenu, 0);
			Controls.SetChildIndex(panel, 0);
			statusMenu.ResumeLayout(false);
			statusMenu.PerformLayout();
			panel.ResumeLayout(false);
			panel.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void FillContent() {
			name.Text = _customer.Name;
			type.Text = _customer.Type.GetDescription();
			addTime.Text = _customer.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
			lastMonth.Text = $"{_customer.LastMonthUsage:n1} m³";
			thisMonth.Text = $"{_customer.ThisMonthUsage:n1} m³";
			totalUsage.Text = $"{_customer.TotalUsage:n1} m³";
			price.Text = _customer.PriceWithoutVAT == -1 ? "N/A" : $"{_customer.PriceWithoutVAT:n1} VND";
			epf.Text = $"{_customer.EPF:n1} VND";
			vat.Text = $"{_customer.VAT:n1} VND";
			totalPrice.Text = _customer.TotalPrice == -1 ? "N/A" : $"{_customer.TotalPrice:n1} VND";
			idLabel.Text = "ID: " + _customer.ID;
		}

		private void ConfigureMenuItem() {
			List<ToolStripItem> menuItems = [printMenuItem];
			foreach (ToolStripItem item in menu.Items) {
				menuItems.Add(item);
			}
			menu.Items.Clear();
			menu.Items.AddRange([.. menuItems]);
		}

		private void ConfigurePrintAction() {
			printMenuItem.Click += (o, e) => {
				Bitmap memoryImage = new(Size.Width, Size.Height);
				PrintDocument printDocument = new();
				PrintDialog print = new();

				print.Document = printDocument;
				print.Document.DocumentName = "User Details";

				printDocument.PrintPage += (o, e) => {
					e.Graphics?.DrawImage(memoryImage, 0, 0);
				};
				DialogResult result = print.ShowDialog();
				printDocument.BeginPrint += (o, e) => TopMost = false;
				Rectangle printPage = new(0, 0, printDocument.DefaultPageSettings.PaperSize.Width, printDocument.DefaultPageSettings.PaperSize.Height);

				panel.DrawToBitmap(memoryImage, new Rectangle(0, 0, panel.Width, panel.Height));
				memoryImage = new Bitmap(memoryImage, new Size(printPage.Width, (int) (panel.Height * (printPage.Width / (double) panel.Width))));

				if (result == DialogResult.OK)
					printDocument.Print();
			};
		}

		private void RegisterEvent() {
			Load += (o, e) => _parent.Hide();
			FormClosing += (o, e) => _parent.Show();
		}

		private Label name;
		private Label type;
		private Label addTime;
		private Label lastMonth;
		private Label thisMonth;
		private Label totalUsage;
		private Label epf;
		private Label price;
		private Label totalPrice;

		private Label name_label;
		private Label typeLabel;
		private Label addTimeLabel;
		private Label lastMonthLabel;
		private Label thisMonthLabel;
		private Label totalUsageLabel;
		private Label priceLabel;
		private Label epfLabel;
		private Label totalPriceLabel;

		private StatusStrip statusMenu;
		private ToolStripStatusLabel idLabel;
		private Panel panel;
		private ToolStripMenuItem printMenuItem;
	}
}