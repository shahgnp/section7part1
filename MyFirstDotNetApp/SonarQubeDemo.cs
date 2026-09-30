using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;

namespace SonarQubeDemo
{
    public class SonarQubeDemo
    {
        // ============================================================
        // 1. CODE SMELL: Hard-coded credentials
        // ============================================================
        public void ConnectToDatabase()
        {
            string username = "admin";
            string password = "Password123";

            string connectionString =
                $"Server=localhost;Database=DemoDb;User Id={username};Password={password};";

            Console.WriteLine(connectionString);
        }

        // ============================================================
        // 2. SECURITY HOTSPOT: Hard-coded secret
        // ============================================================
        public void UseApiKey()
        {
            string apiKey = "sk-demo-1234567890abcdef";

            Console.WriteLine("Using API key: " + apiKey);
        }

        // ============================================================
        // 3. VULNERABILITY: SQL Injection
        // ============================================================
        public void FindUser(string username)
        {
            string connectionString = "Server=localhost;Database=DemoDb;";

            using SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["Username"]);
            }
        }

        // ============================================================
        // 4. SECURITY HOTSPOT: Weak cryptographic algorithm
        // ============================================================
        public string GenerateHash(string input)
        {
            using MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }

        // ============================================================
        // 5. CODE SMELL: Method has unnecessary complexity
        // ============================================================
        public string GetUserStatus(int age, bool active, bool verified)
        {
            if (age > 18)
            {
                if (active)
                {
                    if (verified)
                    {
                        return "ACTIVE";
                    }
                    else
                    {
                        return "UNVERIFIED";
                    }
                }
                else
                {
                    return "INACTIVE";
                }
            }
            else
            {
                return "MINOR";
            }
        }

        // ============================================================
        // 6. BUG: Possible null reference
        // ============================================================
        public int GetUsernameLength(string username)
        {
            return username.Length;
        }

        // ============================================================
        // 7. CODE SMELL: Empty catch block
        // ============================================================
        public void ReadFile(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName);

                Console.WriteLine(content);
            }
            catch (Exception)
            {
                // Nothing happens here
            }
        }

        // ============================================================
        // 8. SECURITY HOTSPOT: HTTP instead of HTTPS
        // ============================================================
        public void CallExternalService()
        {
            using HttpClient client = new HttpClient();

            string url = "http://example.com/api/users";

            string response = client.GetStringAsync(url).Result;

            Console.WriteLine(response);
        }

        // ============================================================
        // 9. CODE SMELL: Duplicate code
        // ============================================================
        public void ProcessUser()
        {
            Console.WriteLine("Starting user processing...");
            Console.WriteLine("Validating user...");
            Console.WriteLine("Saving user...");
            Console.WriteLine("User processing completed.");
        }

        public void ProcessAdmin()
        {
            Console.WriteLine("Starting user processing...");
            Console.WriteLine("Validating user...");
            Console.WriteLine("Saving user...");
            Console.WriteLine("User processing completed.");
        }

        // ============================================================
        // 10. CODE SMELL: Unused variable
        // ============================================================
        public void CalculateSomething()
        {
            int unusedValue = 100;

            int result = 10 + 20;

            Console.WriteLine(result);
        }

        // ============================================================
        // 11. SECURITY HOTSPOT: Random number generation
        // ============================================================
        public string GenerateToken()
        {
            Random random = new Random();

            return random.Next(100000, 999999).ToString();
        }

        // ============================================================
        // 12. CODE SMELL: Hard-coded URL
        // ============================================================
        public void SendRequest()
        {
            string endpoint = "https://api.example.com/v1/users";

            Console.WriteLine(endpoint);
        }

        // ============================================================
        // 13. CODE SMELL: Magic numbers
        // ============================================================
        public bool IsEligible(int age)
        {
            if (age >= 18 && age <= 65)
            {
                return true;
            }

            return false;
        }

        // ============================================================
        // 14. BUG: Incorrect comparison
        // ============================================================
        public bool IsProduction(string environment)
        {
            if (environment == "prod")
            {
                return true;
            }

            return false;
        }

        // ============================================================
        // 15. SECURITY HOTSPOT: Deserializing untrusted data
        // ============================================================
        public object DeserializeData(string data)
        {
            // Intentionally simplistic demo code.
            // SonarQube may flag unsafe deserialization depending
            // on the analyzer/ruleset/version.
            return System.Text.Json.JsonSerializer.Deserialize<object>(data);
        }
    }
}