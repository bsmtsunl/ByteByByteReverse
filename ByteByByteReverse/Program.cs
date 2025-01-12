using System.Diagnostics.Tracing;

namespace ByteByByteReverse;

class Program
{
    static void Main(string[] args)
    {
        string inputPath;
        string outputPath;
        
        if (args.Length == 0)
        {
            inputPath = "D:\\Program Files\\Rider\\Projects\\ByteByByteReverse\\bootstat.dat";
            outputPath = "D:\\Program Files\\Rider\\Projects\\ByteByByteReverse\\result.dat";
        }
        else
        {
            inputPath = args[0];
            outputPath = args[1];
        }
        
        try
        {
             FileReverser reverser = new FileReverser();
             reverser.FileReverse(inputPath, outputPath);
             Console.WriteLine("Done");
        }
        
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
             
  
    }
}