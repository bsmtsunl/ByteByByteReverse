namespace ByteByByteReverse;
using System;
using System.IO;

public class FileReverser
{
    public void FileReverse(string inputFilePath, string outputFilePath)
    {
        if (!File.Exists(inputFilePath))
        {
            throw new FileNotFoundException("Input file could not be found.", inputFilePath);
        }

        using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
        {
            using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                int bufferSize = 4 * 1024;
                byte[] buffer = new byte[bufferSize];
                int bytesToRead = 0;
                for (long offset = inputStream.Length; offset > 0; offset -= bufferSize)
                {
                    bytesToRead = bufferSize < offset ? bufferSize : (int)offset;
                    
                    inputStream.Seek(offset - bytesToRead, SeekOrigin.Begin);
                    inputStream.Read(buffer, 0, bytesToRead);

                    Array.Reverse(buffer, 0, bytesToRead);

                    outputStream.Write(buffer, 0, bytesToRead);
                }
            }
        }
        
    }
    
}