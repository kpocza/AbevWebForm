using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace WebForm.Generator.Common
{
    internal class ZipHandler
    {
        private ZipFile zipFile { get; set; }

        internal ZipHandler(string inputFile)
        {
            zipFile = new ZipFile(File.OpenRead(inputFile));
        }

        internal byte[] GetENYK()
        {
            var enyks = zipFile.Cast<ZipEntry>().Where(e => e.Name.StartsWith("application/nyomtatvanyok/") && e.Name.EndsWith(".enyk")).ToList();

            if (enyks.Count > 1)
            {
                throw new Exception("Több, mint egy enyk állományt található");
            }

            if (enyks.Count == 0)
            {
                throw new Exception("Nem található enyk állomány");
            }

            var entry = enyks.Single();
            return GetUnCompressed(entry);
        }

        private byte[] GetUnCompressed(ZipEntry entry)
        {
            var zipIn = zipFile.GetInputStream(entry);

            var outMem = new MemoryStream();
            var bw = new BinaryWriter(outMem);
            long size = entry.Size;
            byte[] data = new byte[size];
            while (true)
            {
                size = zipIn.Read(data, 0, data.Length);
                if (size > 0) bw.Write(data, 0, (int)size);
                else break;
            }
            var result = outMem.ToArray();;
            bw.Close();
            return result;
        }
    }
}
