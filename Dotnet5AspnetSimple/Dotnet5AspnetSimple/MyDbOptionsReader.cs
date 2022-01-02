using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Dotnet5AspnetSimple
{
    public class MyDbOptionsReader
    {
        public string ReadConnectionString()
        {
            return File.ReadLines("ConnectionString.txt").First();
        }

        public void AddSslCertificate(X509CertificateCollection clientCerts)
        {
            // in real app some code here, but it doesnt matter for example
        }
    }
}