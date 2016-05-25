using System;
using System.IO;
using System.Net;
using System.Text;

namespace FairyZeta.Framework
{
    public class ASEConverter
    {
        public void Read(string args)
        {
            Console.Error.WriteLine("\r\nJoe Winett's SUPER AWESOME ASE to AS3 Converter\r\n");

            //if (args.Length != 1)
            //{
            //    Console.Error.WriteLine("Usage: ASEConverter <INPUT: filename.ase>");
            //    return;
            //}


            byte[] data;

            try
            {
                data = File.ReadAllBytes(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }




            if (data.Length < 12 || data[0] != 'A' || data[1] != 'S' || data[2] != 'E' || data[3] != 'F')
            {
                Console.Error.WriteLine("The file \"" + args[0] + "\" doesn't appear to be in Adobe Swatch Exchange format.");
                return;
            }

            UInt16 versionHigh = getInt16(data, 4);
            UInt16 versionLow = getInt16(data, 6);
            UInt32 blocks = getInt32(data, 8);

            Console.WriteLine("File is Adobe Swatch Exchange Format " + versionHigh + "." + versionLow + " with " + blocks + " blocks.");

            Console.WriteLine("var swatches:Array = [");

            int offset = 12;

            for (int b = 0; b < blocks; b++)
            {
                UInt16 blockType = getInt16(data, offset);
                offset += sizeof(UInt16);

                UInt32 blockLength = getInt32(data, offset);
                offset += sizeof(UInt32);

                switch (blockType)
                {
                    case 0xC001:
                        // Group Start Block (ignored)
                        break;

                    case 0xC002:
                        // Group End Block (ignored)
                        break;

                    case 0x0001:
                        // COLOR!!

                        ReadColor(data, offset, b);
                        break;

                    default:
                        Console.Error.WriteLine("Warning: Block " + b + " is of an unknown type 0x" + blockType.ToString("X") + " (file corrupt?)");
                        break;
                }

                offset += (int)blockLength;
            }

            Console.WriteLine("");
            Console.WriteLine("];");
        }


        public void ReadColor(byte[] data, int offset, int block)
        {
            UInt16 lengthName = getInt16(data, offset);
            offset += sizeof(UInt16);

            lengthName *= 2; // turn into a count of bytes, not 16-bit characters

            string Name = Encoding.BigEndianUnicode.GetString(data, offset, lengthName - 2).Trim();
            offset += lengthName;

            string colorModel = Encoding.ASCII.GetString(data, offset, 4).Trim();
            offset += 4;

            if (colorModel != "RGB")
            {
                Console.Error.WriteLine("Color \"" + Name + "\" is in " + colorModel + " but this program only does RGB, sorry.");
                return;
            }

            var rf = getFloat32(data, offset);
            int r = (int)Math.Ceiling(255.0 * rf);
            int r2 = Convert.ToInt32(255.0 * rf);
            offset += sizeof(Single);

            var gf = getFloat32(data, offset);
            int g = (int)Math.Ceiling(255.0 * gf);
            int g2 = Convert.ToInt32(255.0 * gf);
            offset += sizeof(Single);

            var bf = getFloat32(data, offset);
            int b = (int)Math.Ceiling(255.0 * bf);
            int b2 = Convert.ToInt32(255.0 * bf);
            offset += sizeof(Single);

            UInt16 colorType = getInt16(data, offset);
            // I don't care about colorType either.  You might.  See the link at the top of this page.

            if (block > 0)
                Console.WriteLine(",");
            Console.Write("   { name: \"" + Name + "\", color: 0x" + r2.ToString("X2") + g2.ToString("X2") + b2.ToString("X2") + " }");


        }

        // Microsoft?!?!?!  Why doesn't Bitconverter just deal with Endian conversion?
        // Wouldn't it have been easier to be able to tell BitConverter that the data is
        // one or the other and then it decides when to swap?  Seems backwards.

        public static UInt16 getInt16(byte[] data, int offset)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data, offset, sizeof(UInt16));
            return BitConverter.ToUInt16(data, offset);
        }
        public static UInt32 getInt32(byte[] data, int offset)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data, offset, sizeof(UInt32));
            return BitConverter.ToUInt32(data, offset);
        }

        public static Single getFloat32(byte[] data, int offset)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data, offset, sizeof(Single));
            return BitConverter.ToSingle(data, offset);
        }

        public static string getString(byte[] data, int offset)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(data, offset, sizeof(Single));
            return BitConverter.ToString(data, offset);
        }
    }
}
