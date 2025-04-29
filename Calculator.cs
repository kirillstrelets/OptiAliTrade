namespace OptiAliTrade
{
    public static class Calculator
    {
        public static decimal CalculateOptimalRate(
        decimal usdToCnyRate,
        decimal usdtToCnyRate,
        decimal transactionFee,
        decimal usdToTargetRate)
        {
            if (usdtToCnyRate <= 0 || usdToCnyRate <= 0 || usdToTargetRate <= 0)
                return 0;

            // 1. ������� CNY ����� � ������ ��������?
            decimal totalCnyNeeded = transactionFee * usdtToCnyRate;

            // 2. ������� USDT ����� ��� ��������� totalCnyNeeded?
            decimal usdtNeeded = totalCnyNeeded / usdtToCnyRate;

            // 3. ����� CNY -> ������ (��������, RUB)
            decimal cnyToTargetRate = usdToTargetRate / usdToCnyRate;

            // 4. ����������� ���� USDT -> ������ (��������, ������� ����� ���������)
            decimal optimalRate = cnyToTargetRate * usdtToCnyRate - transactionFee;

            return optimalRate;
        }
    }
}