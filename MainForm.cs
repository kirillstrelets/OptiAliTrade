using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace OptiAliTrade
{
    public partial class MainForm : Form
    {
        private static readonly CurrencyService currencyService = new CurrencyService();
        private Dictionary<string, decimal> currencies = new Dictionary<string, decimal>();
        private readonly ResourceManager resManager;
        private CultureInfo cultureInfo;
        private bool _isManualInput = false;
        private string _lastValidValue = "0";

        public MainForm()
        {
            cultureInfo = new CultureInfo("en-US");
            resManager = new ResourceManager("OptiAliTrade.Localization.Lang", Assembly.GetExecutingAssembly());
            InitializeComponent();
            ApplyLocalization();
            InitUI();
        }

        private async void InitUI()
        {
            DtpDate.Value = DateTime.Today;
            try
            {
                await LoadCurrencies();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private async Task LoadCurrencies()
        {
            currencies = await currencyService.GetCurrenciesAsync(DtpDate.Value);
            CbCurrency.Items.Clear();
            foreach (var currency in currencies.Keys)
            {
                CbCurrency.Items.Add(currency);
            }
            CbCurrency.SelectedItem = "RUB";
            UpdateRates();
        }

        private void UpdateRates()
        {
            if (!currencies.ContainsKey("USD") || !currencies.ContainsKey("CNY") || !currencies.ContainsKey("RUB"))
                return;

            // Получаем выбранную валюту только для отображения курсов
            string selectedCurrency = CbCurrency.SelectedItem?.ToString();
            if (selectedCurrency == null || !currencies.ContainsKey(selectedCurrency))
                return;

            // Курсы для отображения (любая валюта)
            decimal usdToSelected = currencies["USD"] / currencies[selectedCurrency];
            decimal usdToCny = currencies["USD"] / currencies["CNY"];
            decimal cnyToSelected = currencies["CNY"] / currencies[selectedCurrency];

            lblUsdToCurrency.Text = $"USD -> {selectedCurrency}: {usdToSelected:F4} {selectedCurrency}";
            lblUsdToCny.Text = $"USD -> CNY: {usdToCny:F4} CNY";
            lblCnyToCurrency.Text = $"CNY -> {selectedCurrency}: {cnyToSelected:F4} {selectedCurrency}";

            // Расчеты для рубля (RUB)
            CalculateOptimalRate();
        }

        private void CalculateOptimalRate()
        {
            try
            {
                if (!currencies.ContainsKey("RUB")) return;

                decimal fee = decimal.Parse(TbTransactionFee.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                decimal usdtToCny = decimal.Parse(TbUsdtToCny.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                decimal desiredCny = decimal.Parse(TbCnyAmount.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                decimal usdToCny = currencies["USD"] / currencies["CNY"];
                decimal usdToRub = currencies["USD"] / currencies["RUB"];

                decimal optimalRate = Calculator.CalculateOptimalRate(
                    usdToCny,
                    usdtToCny,
                    fee,
                    usdToRub
                );

                lblOptimalRate.Text = $"{resManager.GetString("OptimalRate", cultureInfo)}: {optimalRate:F2} RUB";
            }
            catch
            {
                lblOptimalRate.Text = $"{resManager.GetString("OptimalRate", cultureInfo)}: -";
            }
        }

        private async void DtpDate_ValueChanged(object sender, EventArgs e)

        {
            try
            {
                await LoadCurrencies();
                // Имитируем изменение текста, чтобы обновить эквивалент
                TbTransactionFee_TextChanged(sender, e);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void CbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRates();
            // Имитируем изменение текста, чтобы обновить эквивалент
            TbTransactionFee_TextChanged(sender, e);
        }

        private void TbCnyAmount_TextChanged(object sender, EventArgs e)
        {
            if (!_isManualInput) return;

            try
            {
                string text = TbCnyAmount.Text;

                // Если ввели "0" - очищаем поле
                if (text == "0")
                {
                    TbCnyAmount.Text = "";
                    return;
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    lblResult.Text = "(0.00 RUB)";
                    return;
                }

                if (decimal.TryParse(text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cnyAmount) && cnyAmount >= 0)
                {
                    if (currencies.ContainsKey("CNY") && currencies.ContainsKey("RUB"))
                    {
                        decimal cnyToRubRate = currencies["CNY"] / currencies["RUB"];
                        lblResult.Text = $"({(cnyAmount * cnyToRubRate):F2} RUB)";
                    }
                }
                else
                {
                    int pos = TbCnyAmount.SelectionStart;
                    TbCnyAmount.Text = _lastValidValue;
                    TbCnyAmount.SelectionStart = Math.Max(0, pos - 1);
                }
            }
            catch
            {
                lblResult.Text = "(-)";
            }
        }

        private void TbCnyAmount_Leave(object sender, EventArgs e)
        {
            _isManualInput = false;

            // Если поле пустое при потере фокуса - ставим "0"
            if (string.IsNullOrWhiteSpace(TbCnyAmount.Text))
            {
                TbCnyAmount.Text = "0";
                _lastValidValue = "0";
            }
            else if (TbCnyAmount.Text != _lastValidValue)
            {
                // Валидация при потере фокуса
                if (decimal.TryParse(TbCnyAmount.Text.Replace(',', '.'), out decimal val) && val >= 0)
                {
                    _lastValidValue = TbCnyAmount.Text;
                }
                else
                {
                    TbCnyAmount.Text = _lastValidValue;
                }
            }

            _isManualInput = true;
        }

        private void TbCnyAmount_Enter(object sender, EventArgs e)
        {
            _isManualInput = true;
            // При получении фокуса очищаем "0"
            if (TbCnyAmount.Text == "0")
            {
                TbCnyAmount.Text = "";
            }
        }

        private void TbCnyAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            _isManualInput = true;

            // Разрешаем цифры, управляющие символы и один разделитель
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            // Проверка на один разделитель
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                ((TextBox)sender).Text.IndexOfAny(new[] { '.', ',' }) > -1)
            {
                e.Handled = true;
            }
        }

        private void TbTransactionFee_TextChanged(object sender, EventArgs e)
        {
            CalculateOptimalRate();
        }

        private void TbUsdtToCny_TextChanged(object sender, EventArgs e)
        {
            CalculateOptimalRate();
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)

        {
            cultureInfo = new CultureInfo("en-US");
            ApplyLocalization();
        }
        private void RussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cultureInfo = new CultureInfo("ru-RU");
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            this.Text = resManager.GetString("Title", cultureInfo);
            lblDate.Text = resManager.GetString("Date", cultureInfo);
            lblExchangeRate.Text = resManager.GetString("Currency", cultureInfo);
            lblTransactionFee.Text = resManager.GetString("TransactionFee", cultureInfo);
            lblCnyEquivalent.Text = resManager.GetString("WantReceive", cultureInfo);
            lblOptimalRate.Text = resManager.GetString("OptimalRate", cultureInfo);
            lblUsdtToCny.Text = resManager.GetString("UsdtToCny", cultureInfo);
            languageToolStripMenuItem.Text = resManager.GetString("Language", cultureInfo);
            UpdateRates();
        }
    }
}