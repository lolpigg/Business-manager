﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Money
{
    internal class Jdaughter
    {
        public static void Serialize<T>(T business, int a)
        {
            if (a == 1)
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\business.json", JsonConvert.SerializeObject(business));
            }
            else if (a == 0)
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\types.json", JsonConvert.SerializeObject(business));
            }
        }
        public static T Deserialize<T>()
        {
            if (!File.Exists((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\business.json")))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\business.json");
            }
            var fils = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\business.json");
            return JsonConvert.DeserializeObject<T>(fils);
        }
        public static T Deserialize2<T>()
        {
            if (!File.Exists((Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\types.json")))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\types.json");
            }
            var files = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\types.json");
            return JsonConvert.DeserializeObject<T>(files);
        }
    }
}