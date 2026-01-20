using System.Text;

namespace DAPII_Encryption
{
    internal class DeterministicStringGenerator
    {
        public static string GenerateComplex200CharString()
        {
            // Initialize StringBuilder with exact capacity
            StringBuilder sb = new(200);

            // Complex mathematical transformation using multiple algorithms
            int seed = 42; // Constant seed for determinism

            // Phase 1: Fibonacci-based character generation
            int[] fib = new int[20];
            fib[0] = 0;
            fib[1] = 1;
            for (int i = 2; i < 20; i++)
            {
                fib[i] = (fib[i - 1] + fib[i - 2]) % 94; // Keep in printable ASCII range
            }

            // Phase 2: Prime number sieve for index generation
            bool[] isPrime = new bool[200];
            for (int i = 2; i < 200; i++) isPrime[i] = true;
            for (int i = 2; i * i < 200; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j < 200; j += i)
                        isPrime[j] = false;
                }
            }

            // Phase 3: XOR-shift pseudo-random with constant seed
            uint state = (uint)seed;
            Func<uint> xorshift = () =>
            {
                state ^= state << 13;
                state ^= state >> 17;
                state ^= state << 5;
                return state;
            };

            // Phase 4: Complex character selection using multiple algorithms
            for (int pos = 0; pos < 200; pos++)
            {
                // Combine multiple deterministic operations
                int fibIndex = pos % 20;
                int fibValue = fib[fibIndex];

                // Apply transformations based on position
                uint rng = xorshift();
                int primeWeight = isPrime[pos] ? 7 : 3;

                // Multi-layer hash computation
                int hash = pos * 31 + fibValue * 17 + primeWeight * 13;
                hash ^= (int)(rng % 256);

                // Bit rotation for additional complexity
                hash = ((hash << 5) | (hash >> 27)) & 0x7FFFFFFF;

                // Generate character in printable ASCII range (33-126)
                char c = (char)(33 + (Math.Abs(hash) % 94));

                // Additional transformation based on modular arithmetic
                if (pos % 7 == 0)
                    c = (char)(((c - 33 + 13) % 94) + 33);

                if (pos % 11 == 0)
                    c = (char)(((c - 33 + 29) % 94) + 33);

                sb.Append(c);
            }

            // Final verification and return
            string result = sb.ToString();

            // Ensure exactly 200 characters (defensive check)
            return result.Length == 200 ? result : result.Substring(0, 200);
        }
    }
}