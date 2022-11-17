using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pele {
    public static class Serializer {
        
        private static readonly string _directoryPath = $"C:\\Users\\{Environment.UserName}\\Documents\\Pele\\";
        private static readonly String _path = $"{_directoryPath}\\Szkola.pele";

        public static void ZapiszDane(List<Pele.Szkola> szkoly) {
            File.WriteAllText(
                _path,
                JsonSerializer.Serialize(szkoly)    
            );
        }

        public static List<Pele.Szkola?>? WczytajDane() {
            if (!File.Exists(_path)) {
                return null;
            }
            Pele.Szkola?[]? szkoly = JsonSerializer.Deserialize<Pele.Szkola?[]>(
                File.ReadAllText(_path)    
            );

            return szkoly?.ToList() ?? null;
        }

        public static void Test() {
            Pele.Uczen uczen = new Uczen("sda", " sad", "asd", 12, 12, 12, 12, 12);
            string str = JsonSerializer.Serialize(uczen);
            JsonSerializer.Deserialize<Pele.Uczen>(str);

            Pele.Klasa klasa = new Klasa("sda", "asdasd", new[] {uczen}, 1);
            str = JsonSerializer.Serialize(klasa);
            JsonSerializer.Deserialize<Pele.Klasa>(str);
            JsonConvert
            
            Pele.Szkola szkola = new Szkola("sda", "sdasda", new[] {new Klasa("sad", "sad", new[] {uczen}, 1)});
            str = JsonSerializer.Serialize(szkola);
            JsonSerializer.Deserialize<Pele.Szkola>(str);
        }
    }
}