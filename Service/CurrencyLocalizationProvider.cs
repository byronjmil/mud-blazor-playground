using ThreeDiamonds.Models;

namespace ThreeDiamonds.Service;

public class CurrencyLocalizationProvider
{
    public static Dictionary<string, CurrencyLocalization> GetDictionary()
    {
        return new Dictionary<string, CurrencyLocalization>
        {
            { "CNY", new CurrencyLocalization { BankNoteName = "Chinese Yuan", } },
            { "USD", new CurrencyLocalization { BankNoteName = "United States Dollar", } },
            { "EUR", new CurrencyLocalization { BankNoteName = "Euro (European Union)", } },
            { "JPY", new CurrencyLocalization { BankNoteName = "Japanese Yen", } },
            { "GBP", new CurrencyLocalization { BankNoteName = "British Pound Sterling", } },
            { "RUB", new CurrencyLocalization { BankNoteName = "Russian Ruble", } },
            { "MXN", new CurrencyLocalization { BankNoteName = "Mexican Peso", } },
        };
    }
}
