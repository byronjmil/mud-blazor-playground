using ThreeDiamonds.Models;

namespace ThreeDiamonds.Service;

public class CurrencyLocalizationProvider
{
    public static Dictionary<string, CurrencyLocalization> GetDictionary()
    {
        return new Dictionary<string, CurrencyLocalization>
        {
            { "CNY", new CurrencyLocalization { CurrencyCode = "CN", BankNoteName = "Chinese Yuan", Rank = 1, Symbol = "元" } },
            { "USD", new CurrencyLocalization { CurrencyCode = "US", BankNoteName = "United States Dollar", Rank = 2, } },
            { "EUR", new CurrencyLocalization { CurrencyCode = "DE", BankNoteName = "Euro (European Union)", Rank = 3, } },
            { "JPY", new CurrencyLocalization { CurrencyCode = "JP", BankNoteName = "Japanese Yen", Rank = 4, Symbol = "¥" } },
            { "GBP", new CurrencyLocalization { CurrencyCode = "GB", BankNoteName = "British Pound Sterling", Rank = 5, Symbol = "£" } },
        };
    }
}
