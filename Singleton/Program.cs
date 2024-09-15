class Program
{
    static void Main(string[] args)
    {
        Servers servers = Servers.Instance;

        Console.WriteLine(servers.AddServer("http://example.com"));
        Console.WriteLine(servers.AddServer("https://example.com"));
        Console.WriteLine(servers.AddServer("http://example.com")); // False, потому что дубликат
        Console.WriteLine(servers.AddServer("ftp://example.com")); // False, потому что не http/https

        Console.WriteLine("HTTP servers: " + string.Join(", ", servers.GetHttpServers()));
        Console.WriteLine("HTTPS servers: " + string.Join(", ", servers.GetHttpsServers()));
    }
}