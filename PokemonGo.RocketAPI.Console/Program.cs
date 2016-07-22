﻿#region

using System;
using System.Threading.Tasks;
using PokemonGo.RocketAPI.Exceptions;

#endregion

namespace PokemonGo.RocketAPI.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Logger.SetLogger(new ConsoleLogger(LogLevel.Info));

            Task.Run(() =>
            {
                try
                {
                    new Logic.Logic(new Settings()).Execute().Wait();
                }
                catch (PtcOfflineException)
                {
                    Logger.Write("PTC Servers are probably down OR your credentials are wrong. Try google",
                        LogLevel.Error);
                }
                catch (Exception ex)
                {
                    Logger.Write($"Unhandled exception: {ex}", LogLevel.Error);
                }
            });
            System.Console.ReadLine();
        }
    }
}