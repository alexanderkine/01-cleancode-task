using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{

		private static void SaveData(string s, byte[] d)
		{
		    var fileStreams = new List<FileStream>()
		    {
		        new FileStream(s, FileMode.OpenOrCreate),
		        new FileStream(Path.ChangeExtension(s, "bkp"), FileMode.OpenOrCreate)
		    };
		    foreach (var file in fileStreams)
                WriteData(file, d);
			var tf = s + ".time";
			var fs3 = new FileStream(tf, FileMode.OpenOrCreate);
			var t = BitConverter.GetBytes(DateTime.Now.Ticks);
			WriteData(fs3,t);
		}

        //private FileStream GetFileStream(string path,string extension, FileMode fileMode)
        //{
        //    return new FileStream(path,);
        //}

        private static void WriteData(Stream file, byte[] d)
	    {
            file.Write(d, 0, d.Length);
            file.Close();
	    }
	}
}