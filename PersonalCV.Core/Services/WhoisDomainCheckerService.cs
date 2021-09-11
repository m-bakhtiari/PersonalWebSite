using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCV.Core.Services
{
    public class WhoisDomainCheckerService
    {
        public async Task<string> CheckDomain(string domain)
        {
            domain = w_LookupComplete(domain);
            var w = new Whois();
            var res = w.Lookup(domain);

            if (res.Contains("Registry Domain ID"))
            {
                return "false";
            }
            else if (res.Contains("No match for"))
            {
                return "true";
            }
            else
            {
                return null;
            }
        }
        string w_LookupComplete(string domain)
        {
            domain = domain.Replace("\r\n", "<br/>");
            return domain;
        }
    }

    public delegate void WhoisEventHandler(object sender, WhoisEventArgs e);

    /// <summary>
    /// Our class containing information to be passed to
    /// the lookup event.
    /// </summary>
    public class WhoisEventArgs : EventArgs
    {
        public string WhoisInfo
        {
            get
            {
                return this.whoisInfo;
            }
        }
        public string WhoisServer
        {
            get
            {
                return this.whoisServer;
            }
        }

        private string whoisInfo;
        private string whoisServer;

        public WhoisEventArgs(string Info, string Server)
        {
            this.whoisInfo = Info;
            this.whoisServer = Server;
        }
    }

    /// <summary>
    /// Perform a whois lookup on a domain name, enabling you to 
    /// find out if a domain name is registered, and if it is - 
    /// to whom and what name servers it uses.
    /// </summary>
    public class Whois
    {
        /// <summary>
        /// The server used to perform the whois. If this is not set,
        /// then an attempt to find the whois server automatically is
        /// made. If none is found, the internic whois server is used
        /// by default.
        /// </summary>
        public string WhoisServer
        {
            get
            {
                return this.whoisServer;
            }
            set
            {
                this.whoisServer = value;
            }
        }

        /// <summary>
        /// Called when the lookup has been complete.
        /// </summary>
        public event WhoisEventHandler LookupComplete;


        private string whoisServer = "";

        /// <summary>
        /// Performs a whois lookup on the domain provided.
        /// </summary>
        /// <param name="Domain">The domain to lookup.</param>
        /// <returns>Information returned by the domain whois server,
        /// which can then be string parsed to see if the domain is available or taken.</returns>
        public string Lookup(string Domain)
        {
            string result = "";
            string[] parts = new string[] { };

            // Knock off http and www if it's in the Domain
            if (Domain.StartsWith("http://"))
            {
                Domain = Domain.Replace("http://", "");
            }

            if (Domain.StartsWith("www."))
            {
                Domain = Domain.Substring(4, Domain.Length - 4);
            }

            if (Domain.IndexOf(".tv") != -1 || Domain.IndexOf(".pro") != -1 || Domain.IndexOf(".name") != -1)
            {
                // As result says - certain domain authorities like to keep their whois service private.
                // There maybe extra tlds to add.
                result = "'.pro','.name', and '.tv' domains require an account for a whois";
            }
            else
            {
                if (Domain.IndexOf(".") != -1)
                {
                    // Find the whois server for the domain ourselves, if non set.
                    if (this.whoisServer == "")
                    {
                        this.whoisServer = this.getWhoisServer(Domain);
                    }

                    // Connect to the whois server
                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect(this.whoisServer, 43);
                    NetworkStream networkStream = tcpClient.GetStream();

                    // Send the domain name to the whois server
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(Domain + "\r\n");
                    networkStream.Write(buffer, 0, buffer.Length);

                    // Read back the results
                    buffer = new byte[8192];
                    int i = networkStream.Read(buffer, 0, buffer.Length);
                    while (i > 0)
                    {
                        i = networkStream.Read(buffer, 0, buffer.Length);
                        result += ASCIIEncoding.ASCII.GetString(buffer); ;
                    }
                    networkStream.Close();
                    tcpClient.Close();
                }
                else
                {
                    result = "Please enter a valid domain name.";
                }
            }

            // Fire event with the info of the lookup
            if (this.LookupComplete != null)
            {
                WhoisEventArgs whoisEventArgs = new WhoisEventArgs(result, this.whoisServer);
                this.LookupComplete(this, whoisEventArgs);
            }

            return result;
        }

        /// <summary>
        /// Gets the whois server for a domain using
        /// whois-servers.net.
        /// </summary>
        /// <param name="domainName">The domain name to retrieve the whois server for.</param>
        /// <returns>The whois server hostname.</returns>
        private string getWhoisServer(string domainName)
        {
            string[] parts = domainName.Split('.');
            string tld = parts[parts.Length - 1];
            string host = tld + ".whois-servers.net";

            // .tk doesn't resolve, but it's whois server is public
            if (tld == "tk")
            {
                return "whois.dot.tk";
            }

            try
            {
                IPHostEntry ipHostEntry = Dns.GetHostByName(host);

                if (ipHostEntry.HostName == host)
                {
                    // No entry found, use internic as default
                    host = "whois.internic.net";
                }
                else
                {
                    host = ipHostEntry.HostName;
                }

                return host;
            }
            catch
            {
                host = "whois.internic.net";
                return host;
            }
        }
    }
}