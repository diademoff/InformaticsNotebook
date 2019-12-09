﻿using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission17 : MissionGenerator
    {
        struct Crypt : IEquatable<Crypt>
        {
            public string Letter { get; set; }
            public string Code { get; set; }

            public Crypt(string letter, string code)
            {
                Letter = letter ?? throw new ArgumentNullException(nameof(letter));
                Code = code ?? throw new ArgumentNullException(nameof(code));
            }

            public override string ToString()
            {
                return $"{Letter} - {Code}";
            }

            public bool Equals(Crypt other)
            {
                return Code.Equals(other) || Letter.Equals(other.Letter);
            }
        }

        string[] GetStringUsingLetters(List<Crypt> crypts)
        {
            string answer = "";
            List<string> crypted = new List<string>();
            for (int i = 0; i < crypts.Count; i++)
            {
                answer += crypts[i].Letter;
                crypted.Add(crypts[i].Code);
            }

            for (int i = 0; i < rnd.Next(0, 2); i++)
            {
                Crypt rand = crypts.OrderBy(x => rnd.Next()).ToArray()[0];
                answer += rand.Letter;
                crypted.Add(rand.Code);
            }

            char[] array0 = answer.ToCharArray();
            int n = array0.Length;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);

                var value0 = array0[k];
                array0[k] = array0[n];
                array0[n] = value0;

                var value1 = crypted[k];
                crypted[k] = crypted[n];
                crypted[n] = value1;
            }

            string[] res = new string[2];
            res[0] = new string(array0);
            string cred = "";
            for (int i = 0; i < crypted.Count; i++)
            {
                cred += crypted[i];
            }
            res[1] = cred;

            return res;
        }
        string GetRandomCode()
        {
            int length = rnd.Next(2, 5);
            string res = "";

            for (int i = 0; i < length; i++)
            {
                res += rnd.Next(0, 2) == 0 ? "0" : "1";
            }

            return res;
        }

        public override MissionBase Generate()
        {

            char[] chars = "АБВГДЕЁЖЗИКЛМНОПРСТУХЮЯ".ToCharArray();

            List<Crypt> crypts = new List<Crypt>();
            List<string> codesAdded = new List<string>();
            while (crypts.Count < 4)
            {
                string code = GetRandomCode();
                if (codesAdded.Contains(code))
                {
                    continue;
                }
                crypts.Add(new Crypt(chars[rnd.Next(0, chars.Length)].ToString(), code));
                codesAdded.Add(code);
            }

            foreach (var item in crypts)
            {
                Console.WriteLine(item.Letter + " - " + item.Code);
            }
            var temp = GetStringUsingLetters(crypts);

            string answer = temp[0];
            string cryptedString = temp[1];

            string q = $"Разведчик передал в штаб радиограмму. Каждая буква закодирована. \n" +
                       $"Разделителей между кодами букв нет. Запишите в ответе переданную \n" +
                       $"последовательность букв. Коды букв: \n" +
                       $"{string.Join("\n", crypts)}\n" +
                       $"Закодированная строка: {cryptedString}";
            return new TextMission(17, "Декодирование сообщений", q, answer);
        }
    }
}
