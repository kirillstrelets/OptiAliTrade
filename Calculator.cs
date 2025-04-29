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

            // 1. Сколько CNY нужно с учетом комиссии?
            decimal totalCnyNeeded = transactionFee * usdtToCnyRate;

            // 2. Сколько USDT нужно для получения totalCnyNeeded?
            decimal usdtNeeded = totalCnyNeeded / usdtToCnyRate;

            // 3.  Курс CNY -> валюта (например, RUB)
            decimal cnyToTargetRate = usdToTargetRate / usdToCnyRate;

            // 4. Оптимальный курс USDT -> Валюта (максимум, который можно заплатить)
            decimal optimalRate = cnyToTargetRate * usdtToCnyRate - transactionFee;

            return optimalRate;
        }
    }
}