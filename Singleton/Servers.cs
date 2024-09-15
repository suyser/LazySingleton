using System;
using System.Collections.Generic;

public class Servers
{
    private static readonly Servers _instance = new Servers();
    private HashSet<string> _servers;

    private Servers()
    {
        _servers = new HashSet<string>();
    }

    public static Servers Instance => _instance;

    public bool AddServer(string server)
    {
        if (!server.StartsWith("http://") && !server.StartsWith("https://"))
        {
            return false;
        }

        lock (_servers)
        {
            return _servers.Add(server);
        }
    }

    public List<string> GetHttpServers()
    {
        lock (_servers) 
        {
            return new List<string>(_servers.Where(s => s.StartsWith("http://")));
        }
    }

    public List<string> GetHttpsServers()
    {
        lock (_servers) 
        {
            return new List<string>(_servers.Where(s => s.StartsWith("https://")));
        }
    }
}