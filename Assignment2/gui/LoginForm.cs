using Assignment2.core;
using Assignment2.data;

namespace Assignment2.gui {

	internal class LoginForm : BaseForm {

		public LoginForm() : base("Login") => InitializeComponent();

		private void InitializeComponent() {
			login = new Button();
			status = new StatusStrip();
			information = new ToolStripStatusLabel();
			loginInfo = new TableLayoutPanel();
			label_username = new Label();
			username = new TextBox();
			label_password = new Label();
			password = new TextBox();
			exit = new Button();
			status.SuspendLayout();
			loginInfo.SuspendLayout();
			SuspendLayout();
			//
			// login
			//
			login.Location = new Point(410, 125);
			login.Name = "login";
			login.Size = new Size(75, 23);
			login.TabIndex = 2;
			login.Text = "Login";
			login.UseVisualStyleBackColor = true;
			login.Click += Login;
			//
			// status
			//
			status.Items.AddRange(new ToolStripItem[] { information });
			status.Location = new Point(0, 151);
			status.Name = "status";
			status.Size = new Size(497, 22);
			status.TabIndex = 2;
			status.Text = "statusStrip1";
			//
			// information
			//
			information.DisplayStyle = ToolStripItemDisplayStyle.Text;
			information.Name = "information";
			information.Size = new Size(0, 17);
			//
			// loginInfo
			//
			loginInfo.AutoSize = true;
			loginInfo.ColumnCount = 2;
			loginInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			loginInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
			loginInfo.Controls.Add(label_username, 0, 0);
			loginInfo.Controls.Add(username, 1, 0);
			loginInfo.Controls.Add(label_password, 0, 1);
			loginInfo.Controls.Add(password, 1, 1);
			loginInfo.Location = new Point(12, 27);
			loginInfo.Name = "loginInfo";
			loginInfo.RowCount = 2;
			loginInfo.RowStyles.Add(new RowStyle());
			loginInfo.RowStyles.Add(new RowStyle());
			loginInfo.Size = new Size(475, 90);
			loginInfo.TabIndex = 3;
			//
			// label_username
			//
			label_username.AutoSize = true;
			label_username.Dock = DockStyle.Top;
			label_username.Location = new Point(3, 0);
			label_username.Name = "label_username";
			label_username.Size = new Size(89, 15);
			label_username.TabIndex = 0;
			label_username.Text = "Username";
			//
			// username
			//
			username.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			username.Location = new Point(98, 3);
			username.Name = "username";
			username.Size = new Size(374, 23);
			username.TabIndex = 0;
			username.KeyPress += (o, e) => {
				if (e.KeyChar == (char) Keys.Return || e.KeyChar == (char) Keys.Enter) {
					password.Focus();
				}
			};
			//
			// label_password
			//
			label_password.AutoSize = true;
			label_password.Dock = DockStyle.Top;
			label_password.Location = new Point(3, 29);
			label_password.Name = "label_password";
			label_password.Size = new Size(89, 15);
			label_password.TabIndex = 1;
			label_password.Text = "Password";
			//
			// password
			//
			password.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			password.Location = new Point(98, 32);
			password.Name = "password";
			password.Size = new Size(374, 23);
			password.TabIndex = 1;
			password.KeyPress += (o, e) => {
				if (e.KeyChar == (char) Keys.Return || e.KeyChar == (char) Keys.Enter) {
					login.Focus();
					login.PerformClick();
				}
			};
			password.UseSystemPasswordChar = true;
			//
			// exit
			//
			exit.Location = new Point(329, 125);
			exit.Name = "exit";
			exit.Size = new Size(75, 23);
			exit.TabIndex = 4;
			exit.Text = "Exit";
			exit.UseVisualStyleBackColor = true;
			exit.Click += (o, e) => Close();
			//
			// LoginForm
			//
			ClientSize = new Size(497, 173);
			Controls.Add(loginInfo);
			Controls.Add(login);
			Controls.Add(exit);
			Controls.Add(status);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "LoginForm";
			Controls.SetChildIndex(status, 0);
			Controls.SetChildIndex(exit, 0);
			Controls.SetChildIndex(login, 0);
			Controls.SetChildIndex(loginInfo, 0);
			status.ResumeLayout(false);
			status.PerformLayout();
			loginInfo.ResumeLayout(false);
			loginInfo.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		private void Login(object? sender, EventArgs e) {
			information.Text = "Checking...";
			Account account = new(username.Text, password.Text);
			login.Enabled = false;
			if (account.IsValid()) {
				core.ProgramEnvironment.CurrentAccount = account;
				information.Text = "Login successful";
				Dispose();
				new MainForm().ShowDialog();
			} else {
				login.Enabled = true;
				information.Text = "Invalid username or password";
			}
		}

		private StatusStrip status;
		private ToolStripStatusLabel information;
		private TableLayoutPanel loginInfo;
		private TextBox username;
		private Label label_username;
		private Label label_password;
		private TextBox password;
		private Button exit;
		private Button login;
	}
}