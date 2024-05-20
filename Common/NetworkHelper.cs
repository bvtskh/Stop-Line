using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SMT.Common
{
    public class NetworkHelper
    {
        public static bool CheckConnect(string ip)
        {
            Ping ping = new Ping();
            //change the following ip variable into the ip adress you are looking for
            IPAddress address = IPAddress.Parse(ip);
            PingReply pong = ping.Send(address);
            if (pong.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }
        public static string GetMacAddress(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }
            string result = null;
            NetworkHelper.Try_catch(delegate
            {
                result = NetworkHelper.Get_mac_address(url);
            });
            return result;
        }

        private static string Get_mac_address(string url)
        {
            string result;
            using (TcpClient tcpClient = new TcpClient())
            {
                Uri uri = new Uri(url);
                tcpClient.Connect(uri.Host, uri.Port);
                if (!tcpClient.Connected)
                {
                    result = null;
                }
                else
                {
                    IPEndPoint iPEndPoint = (IPEndPoint)tcpClient.Client.LocalEndPoint;
                    string ip = iPEndPoint.Address.ToString();
                    NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                    int num = allNetworkInterfaces.Length;
                    for (int i = 0; i < num; i++)
                    {
                        NetworkInterface networkInterface = allNetworkInterfaces[i];
                        IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
                        List<UnicastIPAddressInformation> list = iPProperties.UnicastAddresses.MakeList<UnicastIPAddressInformation>();
                        UnicastIPAddressInformation unicastIPAddressInformation = list.Find((UnicastIPAddressInformation t) => t.IsDnsEligible && t.Address.ToString() == ip);
                        if (unicastIPAddressInformation != null)
                        {
                            result = networkInterface.GetPhysicalAddress().ToString();
                            return result;
                        }
                    }
                    tcpClient.Close();
                    result = null;
                }
            }
            return result;
        }

        private static void Try_catch(Action action)
        {
            try
            {
                action();
            }
            catch
            {
            }
        }
    }
}
