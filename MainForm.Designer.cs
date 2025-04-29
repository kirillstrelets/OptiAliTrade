using System.Windows.Forms;

namespace OptiAliTrade
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblExchangeRate;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.ComboBox CbCurrency;
        private System.Windows.Forms.Label lblUsdToCurrency;
        private System.Windows.Forms.Label lblUsdToCny;
        private System.Windows.Forms.Label lblCnyToCurrency;
        private System.Windows.Forms.Label lblCurrencyCNY;
        private System.Windows.Forms.Label lblTransactionFee;
        private System.Windows.Forms.TextBox TbTransactionFee;
        private System.Windows.Forms.Label lblUsdtToCny;
        private System.Windows.Forms.TextBox TbUsdtToCny;
        private System.Windows.Forms.Label lblOptimalRate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnglishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RussianToolStripMenuItem;
        private System.Windows.Forms.Label lblCnyEquivalent;
        private System.Windows.Forms.TextBox TbCnyAmount;
        private System.Windows.Forms.Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblDate = new System.Windows.Forms.Label();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.CbCurrency = new System.Windows.Forms.ComboBox();
            this.lblUsdToCurrency = new System.Windows.Forms.Label();
            this.lblUsdToCny = new System.Windows.Forms.Label();
            this.lblCnyToCurrency = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTransactionFee = new System.Windows.Forms.Label();
            this.TbTransactionFee = new System.Windows.Forms.TextBox();
            this.lblUsdtToCny = new System.Windows.Forms.Label();
            this.TbUsdtToCny = new System.Windows.Forms.TextBox();
            this.lblOptimalRate = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnglishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCnyEquivalent = new System.Windows.Forms.Label();
            this.TbCnyAmount = new System.Windows.Forms.TextBox();
            this.lblCurrencyCNY = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(263, 61);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 20);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date:";
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.Location = new System.Drawing.Point(263, 92);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(103, 20);
            this.lblExchangeRate.TabIndex = 2;
            this.lblExchangeRate.Text = "Exchange rate for:";
            // 
            // DtpDate
            // 
            this.DtpDate.Location = new System.Drawing.Point(309, 60);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(122, 20);
            this.DtpDate.TabIndex = 1;
            this.DtpDate.ValueChanged += new System.EventHandler(this.DtpDate_ValueChanged);
            // 
            // CbCurrency
            // 
            this.CbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCurrency.Location = new System.Drawing.Point(366, 88);
            this.CbCurrency.Name = "CbCurrency";
            this.CbCurrency.Size = new System.Drawing.Size(50, 21);
            this.CbCurrency.TabIndex = 3;
            this.CbCurrency.SelectedIndexChanged += new System.EventHandler(this.CbCurrency_SelectedIndexChanged);
            // 
            // lblUsdToCurrency
            // 
            this.lblUsdToCurrency.Location = new System.Drawing.Point(263, 122);
            this.lblUsdToCurrency.Name = "lblUsdToCurrency";
            this.lblUsdToCurrency.Size = new System.Drawing.Size(168, 20);
            this.lblUsdToCurrency.TabIndex = 4;
            this.lblUsdToCurrency.Text = "USD -> Currency:";
            // 
            // lblUsdToCny
            // 
            this.lblUsdToCny.Location = new System.Drawing.Point(263, 152);
            this.lblUsdToCny.Name = "lblUsdToCny";
            this.lblUsdToCny.Size = new System.Drawing.Size(168, 20);
            this.lblUsdToCny.TabIndex = 5;
            this.lblUsdToCny.Text = "USD -> CNY:";
            // 
            // lblCnyToCurrency
            // 
            this.lblCnyToCurrency.Location = new System.Drawing.Point(263, 182);
            this.lblCnyToCurrency.Name = "lblCnyToCurrency";
            this.lblCnyToCurrency.Size = new System.Drawing.Size(168, 20);
            this.lblCnyToCurrency.TabIndex = 6;
            this.lblCnyToCurrency.Text = "CNY -> Currency:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(283, 37);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 15;
            // 
            // lblTransactionFee
            // 
            this.lblTransactionFee.Location = new System.Drawing.Point(11, 66);
            this.lblTransactionFee.Name = "lblTransactionFee";
            this.lblTransactionFee.Size = new System.Drawing.Size(127, 20);
            this.lblTransactionFee.TabIndex = 9;
            this.lblTransactionFee.Text = "Transaction fee (USDT):";
            // 
            // TbTransactionFee
            // 
            this.TbTransactionFee.Location = new System.Drawing.Point(144, 66);
            this.TbTransactionFee.Name = "TbTransactionFee";
            this.TbTransactionFee.Size = new System.Drawing.Size(100, 20);
            this.TbTransactionFee.TabIndex = 10;
            this.TbTransactionFee.TextChanged += new System.EventHandler(this.TbTransactionFee_TextChanged);
            // 
            // lblUsdtToCny
            // 
            this.lblUsdtToCny.Location = new System.Drawing.Point(11, 96);
            this.lblUsdtToCny.Name = "lblUsdtToCny";
            this.lblUsdtToCny.Size = new System.Drawing.Size(117, 20);
            this.lblUsdtToCny.TabIndex = 11;
            this.lblUsdtToCny.Text = "USDT -> CNY (HTX):";
            // 
            // TbUsdtToCny
            // 
            this.TbUsdtToCny.Location = new System.Drawing.Point(144, 96);
            this.TbUsdtToCny.Name = "TbUsdtToCny";
            this.TbUsdtToCny.Size = new System.Drawing.Size(100, 20);
            this.TbUsdtToCny.TabIndex = 12;
            this.TbUsdtToCny.TextChanged += new System.EventHandler(this.TbUsdtToCny_TextChanged);
            // 
            // lblOptimalRate
            // 
            this.lblOptimalRate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOptimalRate.Location = new System.Drawing.Point(11, 182);
            this.lblOptimalRate.Name = "lblOptimalRate";
            this.lblOptimalRate.Size = new System.Drawing.Size(233, 30);
            this.lblOptimalRate.TabIndex = 13;
            this.lblOptimalRate.Text = "Optimal rate:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnglishToolStripMenuItem,
            this.RussianToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // EnglishToolStripMenuItem
            // 
            this.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            this.EnglishToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.EnglishToolStripMenuItem.Text = "English";
            this.EnglishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItem_Click);
            // 
            // RussianToolStripMenuItem
            // 
            this.RussianToolStripMenuItem.Name = "RussianToolStripMenuItem";
            this.RussianToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.RussianToolStripMenuItem.Text = "Русский";
            this.RussianToolStripMenuItem.Click += new System.EventHandler(this.RussianToolStripMenuItem_Click);
            // 
            // lblCnyEquivalent
            // 
            this.lblCnyEquivalent.Location = new System.Drawing.Point(12, 37);
            this.lblCnyEquivalent.Name = "lblCnyEquivalent";
            this.lblCnyEquivalent.Size = new System.Drawing.Size(91, 20);
            this.lblCnyEquivalent.TabIndex = 7;
            this.lblCnyEquivalent.Text = "I want to receive:";
            // 
            // TbCnyAmount
            // 
            this.TbCnyAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCnyAmount.Location = new System.Drawing.Point(144, 35);
            this.TbCnyAmount.Name = "TbCnyAmount";
            this.TbCnyAmount.Size = new System.Drawing.Size(100, 20);
            this.TbCnyAmount.TabIndex = 8;
            this.TbCnyAmount.Text = "0";
            this.TbCnyAmount.TextChanged += new System.EventHandler(this.TbCnyAmount_TextChanged);
            this.TbCnyAmount.Enter += new System.EventHandler(this.TbCnyAmount_Enter);
            this.TbCnyAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbCnyAmount_KeyPress);
            this.TbCnyAmount.Leave += new System.EventHandler(this.TbCnyAmount_Leave);
            // 
            // lblCurrencyCNY
            // 
            this.lblCurrencyCNY.AutoSize = true;
            this.lblCurrencyCNY.Location = new System.Drawing.Point(251, 37);
            this.lblCurrencyCNY.Name = "lblCurrencyCNY";
            this.lblCurrencyCNY.Size = new System.Drawing.Size(29, 13);
            this.lblCurrencyCNY.TabIndex = 16;
            this.lblCurrencyCNY.Text = "CNY";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(452, 214);
            this.Controls.Add(this.lblCurrencyCNY);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.DtpDate);
            this.Controls.Add(this.lblExchangeRate);
            this.Controls.Add(this.CbCurrency);
            this.Controls.Add(this.lblUsdToCurrency);
            this.Controls.Add(this.lblUsdToCny);
            this.Controls.Add(this.lblCnyToCurrency);
            this.Controls.Add(this.lblCnyEquivalent);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.TbCnyAmount);
            this.Controls.Add(this.lblTransactionFee);
            this.Controls.Add(this.TbTransactionFee);
            this.Controls.Add(this.lblUsdtToCny);
            this.Controls.Add(this.TbUsdtToCny);
            this.Controls.Add(this.lblOptimalRate);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "OptiAliTrade";
            this.TopMost = true;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}