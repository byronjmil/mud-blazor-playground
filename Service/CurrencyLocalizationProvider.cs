using ThreeDiamonds.Models;

namespace ThreeDiamonds.Service;

public class CurrencyLocalizationProvider
{
    public static Dictionary<string, CurrencyLocalization> GetDictionary()
    {
        return new Dictionary<string, CurrencyLocalization>
        {
            { "USD", new CurrencyLocalization { CurrencyCode = "US", BankNoteName = "United States Dollar", Rank = 2, } },
            { "EUR", new CurrencyLocalization { CurrencyCode = "DE", BankNoteName = "Euro (European Union)", Rank = 3, } },
        };
    }
}
