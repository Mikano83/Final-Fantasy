using System.Reflection;
using System.Text;

namespace Final_Fantasy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                sb.AppendLine(type.ToString());
            }
            var result = sb.ToString();
            System.IO.File.WriteAllText(@"C:\temp\output.txt", result);
        }
    }
}