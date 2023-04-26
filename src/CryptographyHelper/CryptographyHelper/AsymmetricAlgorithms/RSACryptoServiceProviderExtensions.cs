using System;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;

namespace CryptographyHelper.AsymmetricAlgorithms
{
    /// <summary>
    /// Rsa ToXmlString is not supported on .NET Core 2.0 #874
    /// https://github.com/dotnet/core/issues/874
    /// </summary>
    public static class RSACryptoServiceProviderExtensions
    {
        public static void FromXmlString2(this RSACryptoServiceProvider rsa, string xmlString)
        {
            rsa.ImportParameters(xmlString.FromXmlString());
        }

        public static void FromXmlString2(this RSA rsa, string xmlString)
        {
            rsa.ImportParameters(xmlString.FromXmlString());
        }

        public static string ToXmlString2(this RSACryptoServiceProvider rsa, bool includePrivateParameters)
        {
            return rsa.ExportParameters(includePrivateParameters).ToXmlString();
        }

        public static string ToXmlString2(this RSA rsa, bool includePrivateParameters)
        {
            return rsa.ExportParameters(includePrivateParameters).ToXmlString();
        }

        private static RSAParameters FromXmlString(this string xmlString)
        {
            RSAParameters parameters = new RSAParameters();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            if (!xmlDoc.DocumentElement.Name.Equals("RSAKeyValue"))
            {
                throw new Exception("Invalid XML RSA key.");

            }

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                switch (node.Name)
                {
                    case "Modulus": parameters.Modulus = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "Exponent": parameters.Exponent = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "P": parameters.P = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "Q": parameters.Q = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "DP": parameters.DP = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "DQ": parameters.DQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "InverseQ": parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                    case "D": parameters.D = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
                }
            }

            return parameters;
        }

        private static string ToXmlString(this RSAParameters parameters)
        {
            var xml = string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                  parameters.Modulus.ToBase64String(),
                  parameters.Exponent.ToBase64String(),
                  parameters.P.ToBase64String(),
                  parameters.Q.ToBase64String(),
                  parameters.DP.ToBase64String(),
                  parameters.DQ.ToBase64String(),
                  parameters.InverseQ.ToBase64String(),
                  parameters.D.ToBase64String());

            XElement doc = XElement.Parse(xml);
            doc.Descendants().Where(e => string.IsNullOrEmpty(e.Value)).Remove();

            return doc.ToString()
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty)
                .Replace(" ", string.Empty);
        }
    }
}
