using System.Net;
using System.Net.NetworkInformation;

public static class NetworkUtils
{
    public static bool IsPortInUse(int port)
    {
        IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        IPEndPoint[] tcpListeners = ipGlobalProperties.GetActiveTcpListeners();

        foreach (IPEndPoint endpoint in tcpListeners)
        {
            if (endpoint.Port == port)
            {
                return true;
            }
        }
        return false;
    }
}
