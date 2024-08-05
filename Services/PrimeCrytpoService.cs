using System.Security.Cryptography;
using System.Text;

namespace crypto_api.Services;

public class PrimeCrytpoService : ICryptoService
{
    private IEnumerable<int> primes =
       new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
    public string Encrypt(string content)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var p in content)
        {
            int ascii = Convert.ToInt32(p);
            int firstPrime = primes.Where(a => a < 10).OrderBy(a => Guid.NewGuid()).First();
            int secondPrime = primes.Where(a => a >= 10).OrderBy(a => Guid.NewGuid()).First();
            int value = ascii * firstPrime * firstPrime * secondPrime;
            var primeFactors = PrimeFactors(value);
            sb.Append(value.ToString("x8"));
            sb.Append(firstPrime.ToString("00"));
            sb.Append(secondPrime.ToString());
        }
        Console.WriteLine(GetHashValue(content));
        return sb.ToString();
    }

    public string Decrypt(string content)
    {
        int capacity = 12;
        int num16Length = 8;
        if (content.Length % capacity != 0)
        {
            throw new Exception("Input file is invalid length.");
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < content.Length / capacity; i++)
        {
            List<char> chars = content.ToList();
            int dec = Convert.ToInt32(string.Join("", chars.GetRange(i * capacity, num16Length)).TrimStart('0'), 16);
            int firstPrime = Convert.ToInt32(string.Join("", chars.GetRange(i * capacity + num16Length, 2)));
            int secondPrime = Convert.ToInt32(string.Join("", chars.GetRange(i * capacity + num16Length + 2, 2)));
            sb.Append(Convert.ToChar(dec / firstPrime / firstPrime / secondPrime));
        }
        Console.WriteLine(GetHashValue(sb.ToString()));
        return sb.ToString();
    }

    private IEnumerable<int> PrimeFactors(int n)
    {
        int i = 2;
        int tmp = n;

        while (i * i <= n) //※1
        {
            if (tmp % i == 0)
            {
                tmp /= i;
                yield return i;
            }
            else
            {
                i++;
            }
        }
        if (tmp != 1) yield return tmp;//最後の素数も返す
    }

    private string GetHashValue(string content)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(content);
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(bytes);
            return string.Join("", hash.Select(a => a.ToString("x2")));
        }
    }
}
