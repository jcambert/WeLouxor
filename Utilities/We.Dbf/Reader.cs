//@see https://www.dbf2002.com/dbf-file-format.html

namespace We.Dbf;

public class Reader
{
    const string FILENAME = @"E:\projets\WeLouxor\Database\cmlign.dbf";

    public async Task Read()
    {
       var bytes= await File.ReadAllBytesAsync(FILENAME);
        var tmp = bytes.Skip(4).Take(4).ToArray();
       var s= Convert.ToHexString(tmp);
       //var i=Convert.ToInt32(tmp);
        var i=BitConverter.ToInt32(tmp, 0);
        var ss=BitConverter.ToString(tmp);
    }
}

public struct Header
{
    public int FileType { get; set; }
}