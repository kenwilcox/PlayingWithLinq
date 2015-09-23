<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.IO.Compression</Namespace>
</Query>

static string directoryPath = @"C:\Users\wilcoxk\Desktop";

void Main()
{
  var directory = new DirectoryInfo(directoryPath);
  Compress(directory);
  foreach(var fileToDecompress in directory.GetFiles("*.cmp")) {
    Decompress(fileToDecompress);
  }  
}

// Define other methods and classes here
public static void Compress(DirectoryInfo directorySelected)
{
  foreach (FileInfo file in directorySelected.GetFiles("*.xml"))
  using (FileStream originalFileStream = file.OpenRead())
  {
      if ((File.GetAttributes(file.FullName) & FileAttributes.Hidden)
          != FileAttributes.Hidden & file.Extension != ".cmp")
      {
          using (FileStream compressedFileStream = File.Create(file.FullName + ".cmp"))
          {
              using (DeflateStream compressionStream = new DeflateStream(compressedFileStream, CompressionMode.Compress))
              {
                  originalFileStream.CopyTo(compressionStream);
              }
          }

          FileInfo info = new FileInfo(directoryPath + "\\" + file.Name + ".cmp");
          Console.WriteLine("Compressed {0} from {1} to {2} bytes.", file.Name, file.Length, info.Length);
      }
  }
}
    
public static void Decompress(FileInfo fileToDecompress)
{
  using (FileStream originalFileStream = fileToDecompress.OpenRead())
  {
      string currentFileName = fileToDecompress.FullName;
      string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
      currentFileName.Dump();
      newFileName.Dump();
      using (FileStream decompressedFileStream = File.Create(newFileName))
  	{
          using (DeflateStream decompressionStream = new DeflateStream(originalFileStream, CompressionMode.Decompress))
  	    {
              decompressionStream.CopyTo(decompressedFileStream);
              Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
  	    }
  	}
  }
}
