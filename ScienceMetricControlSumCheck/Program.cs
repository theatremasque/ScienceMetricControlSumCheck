
using System.Threading.Channels;

internal class Program
{
    /*
     Останній символ в ідентифікаторі ORCID є контрольною сумою. 
    Відповідно до ISO/IEC 7064:2003, MOD 11-2, ця контрольна сума має бути «0» - «9», 
    хоча контрольна цифра також може бути «X» (що представляє значення 10). 
    Нижче описано, як це розрахувати. Дізнайтеся більше про формат ідентифікатора 
    ORCID за адресою
     */
    private static void Main(string[] args)
    {
        List<string> orcids = new List<string>
        {
            "0000-0003-1415-9269",
            //"0000-0001-5109-3700",
            //"0000-0002-1694-233X"
        };

        foreach (string orcid in orcids)
        {
             var resultOfMethod = CheckSumOfDigits(orcid.Replace("-","").ToCharArray());

            Console.WriteLine(CheckResult(resultOfMethod, orcid));
        }

        static int CheckSumOfDigits(char[] digits)
        {
            int result = 0;



            result = (int)Char.GetNumericValue(digits[0]) * 2;

            for (int i = 1; i < digits.Length - 1; i++)
            {
                result = (result + (int)Char.GetNumericValue(digits[i])) * 2;

            }

            var remainder = result % 11;

            var checkOfControlDigits = 12 - remainder;

            Console.WriteLine(checkOfControlDigits);

            return checkOfControlDigits;
        }

        static bool CheckResult(int resultOfMethod, string orcid)
        {
            var lastIndex = (int)Char.GetNumericValue(orcid.Last());

            if (lastIndex == resultOfMethod)
            {
                return true;
            }

            return false;
        }
    }
}