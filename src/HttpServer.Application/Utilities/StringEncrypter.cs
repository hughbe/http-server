using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HttpServer.Utilities
{
    public interface IStringEncryptor
    {
        string EncryptString(string plainText);
        string DecryptString(string encryptedText);
    }

    public class TripleDesStringEncryptor : IDisposable, IStringEncryptor
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;
        private TripleDESCryptoServiceProvider _provider;

        public TripleDesStringEncryptor()
        {
            _key = Encoding.ASCII.GetBytes("GSYAHAGCBDUUADIADKOPAAAW");
            _iv = Encoding.ASCII.GetBytes("USAZBGAW");
            _provider = new TripleDESCryptoServiceProvider();
        }

        public string EncryptString(string plainText) => Transform(plainText, _provider.CreateEncryptor(_key, _iv));

        public string DecryptString(string encryptedText) => Transform(encryptedText, _provider.CreateDecryptor(_key, _iv));
        
        private string Transform(string text, ICryptoTransform transform)
        {
            if (text == null)
            {
                return null;
            }

            using (var stream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    var input = Encoding.Default.GetBytes(text);
                    cryptoStream.Write(input, 0, input.Length);
                    cryptoStream.FlushFinalBlock();

                    return Encoding.Default.GetString(stream.ToArray());
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_provider != null)
            {
                _provider.Dispose();
                _provider = null;
            }
        }
    }
}
