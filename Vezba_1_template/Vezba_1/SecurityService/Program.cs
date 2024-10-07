﻿using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SecurityService
{
	public class Program
	{
		static void Main(string[] args)
		{
			NetTcpBinding binding = new NetTcpBinding();
			string address = "net.tcp://localhost:9999/SecurityService";

			binding.Security.Mode = SecurityMode.Transport;
			binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
			binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

			using(ServiceHost host =  new ServiceHost(typeof(SecurityService),new Uri(address)))
			{
				host.Open();
				Console.WriteLine("Service running...");
				Console.ReadKey();
				host.Close();
			}
			
			Console.ReadLine();
			
		}
	}
}
