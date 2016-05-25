using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FairyZeta.Framework
{
    public static class StreamExtensions
    {
        #region Static Methods

        /// <summary>
        /// Reads a 4-byte floating point value from the current stream using big-endian encoding and advances the position of the stream by four bytes.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>A 4-byte floating point value read from the source stream.</returns>
        public static float ReadSingleBigEndian(this Stream stream)
        {
            unsafe
            {
                int value;

                value = stream.ReadUInt32BigEndian();

                return *(float*)&value;
            }
        }

        /// <summary>
        /// Reads a ASCII string of the specified length.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <param name="length">The number of characters in the string.</param>
        /// <returns>The string read from the stream.</returns>
        public static string ReadString(this Stream stream, int length)
        {
            byte[] buffer;

            buffer = new byte[length];

            stream.Read(buffer, 0, buffer.Length);

            return Encoding.ASCII.GetString(buffer);
        }

        /// <summary>
        /// Reads a unicode string of the specified length in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <param name="length">The number of characters in the string.</param>
        /// <returns>The string read from the stream.</returns>
        public static string ReadStringBigEndian(this Stream stream, int length)
        {
            byte[] buffer;

            buffer = new byte[length * 2];

            stream.Read(buffer, 0, buffer.Length);

            return Encoding.BigEndianUnicode.GetString(buffer);
        }

        /// <summary>
        /// Reads a unicode string from the current stream in big-endian format. The string is prefixed with the length.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>The string read from the stream.</returns>
        public static string ReadStringBigEndian(this Stream stream)
        {
            int length;
            string value;

            // string is null terminated, value saved in file includes the terminator

            length = stream.ReadUInt16BigEndian() - 1;
            value = stream.ReadStringBigEndian(length);
            stream.ReadUInt16BigEndian(); // read and discard the terminator

            return value;
        }

        /// <summary>
        /// Reads a 2-byte unsigned integer from the current stream using big-endian encoding and advances the position of the stream by two bytes.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>A 2-byte unsigned integer read from the source stream.</returns>
        public static int ReadUInt16BigEndian(this Stream stream)
        {
            return (stream.ReadByte() << 8) | stream.ReadByte();
        }

        /// <summary>
        /// Reads a 4-byte unsigned integer from the current stream using big-endian encoding and advances the position of the stream by four bytes.
        /// </summary>
        /// <param name="stream">The stream to read the data from.</param>
        /// <returns>A 4-byte unsigned integer read from the source stream.</returns>
        public static int ReadUInt32BigEndian(this Stream stream)
        {
            return ((byte)stream.ReadByte() << 24) | ((byte)stream.ReadByte() << 16) | ((byte)stream.ReadByte() << 8) |
                   (byte)stream.ReadByte();
        }

        /// <summary>
        /// Writes the characters from an ASCII string into the specified stream
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="value">The value to write</param>
        public static void Write(this Stream stream, string value)
        {
            foreach (char c in value)
            {
                stream.WriteByte((byte)c);
            }
        }

        /// <summary>
        /// Writes a floating point number in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="value">The value to write</param>
        public static void WriteBigEndian(this Stream stream, float value)
        {
            unsafe
            {
                stream.WriteBigEndian(*(int*)&value);
            }
        }

        /// <summary>
        /// Writes a unicode string to the specified stream in big-endian format
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="value">The value.</param>
        public static void WriteBigEndian(this Stream stream, string value)
        {
            byte[] data;

            data = Encoding.BigEndianUnicode.GetBytes(value);

            stream.WriteBigEndian((ushort)value.Length);
            stream.Write(data, 0, data.Length);
        }

        /// <summary>
        /// Writes a 16bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="value">The value to write</param>
        public static void WriteBigEndian(this Stream stream, ushort value)
        {
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 0));
        }

        /// <summary>
        /// Writes a 32bit unsigned integer in big-endian format.
        /// </summary>
        /// <param name="stream">The stream to write the data to.</param>
        /// <param name="value">The value to write</param>
        public static void WriteBigEndian(this Stream stream, int value)
        {
            stream.WriteByte((byte)((value & 0xFF000000) >> 24));
            stream.WriteByte((byte)((value & 0x00FF0000) >> 16));
            stream.WriteByte((byte)((value & 0x0000FF00) >> 8));
            stream.WriteByte((byte)((value & 0x000000FF) >> 0));
        }

        #endregion
    }
}
