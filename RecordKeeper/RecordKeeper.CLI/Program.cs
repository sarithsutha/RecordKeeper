﻿using RecordKeeper.CLI.InputHandlers;
using System;

namespace RecordKeeper.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: hook up a DI container. For now manually inject as its only two of them
            Repo.IRecordsRepository repo = new Repo.RecordsRepository();
            Service.IRecordsService svc = new Service.RecordsService(repo);
            //END
            Console.WriteLine("Starting Record Keeper's interative command line session...");
            bool exit = false;
            while (!exit)
            {
                new InputContext(svc).PrintOptions();
                var input = Console.ReadKey();
                exit = new InputContext(svc).HandleInputKey(input.Key);
            }
        }
    }
}
