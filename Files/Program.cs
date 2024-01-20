// See https://aka.ms/new-console-template for more information

using System.Text;

const string FILEPATH = "accounts.txt";
var stream = new FileStream(FILEPATH, FileMode.Open);
int totalBytes = -1;

static void WriteBuffer(byte[] buffer, UTF8Encoding encoder)
{
    Console.Write(encoder.GetString(buffer));
    Console.WriteLine();
}

var buffer = new byte[1024]; // 1 kb
totalBytes = stream.Read(buffer, 0, buffer.Length);
var encoder = new UTF8Encoding();

while (totalBytes != 0) 
{ 
    Console.WriteLine($"Bytes read {totalBytes} ");
    WriteBuffer(buffer, encoder);
    totalBytes = stream.Read(buffer, 0, buffer.Length);
}
    


//WriteBuffer(buffer);