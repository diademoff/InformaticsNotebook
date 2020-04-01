using MyNotebook.Models;
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
        public override int NumOfMission => 17;
        public override string MissionName => "Декодирование сообщений";
        public override int TimeToSolveMission => 197;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;

        [Serializable]
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

        string[] getCode(string code)
        {
            return new string[]
            {
                $"{code}1",
                $"{code}0"
            };
        }

        string[] GetRandomCodes(int length, string code = "")
        {
            List<string> codes = new List<string>();

            code = code == "" ? "1" : code;

            do
            {
                length -= 2;
                codes.AddRange(getCode(code));
                code += rnd.RandomBool() ? "1" : "0";
            } while (length > 0);

            if (length < 0)
            {
                do
                {
                    length += 1;
                    codes.RemoveAt(codes.Count - 1);
                } while (length != 0);
            }

            return codes.ToArray();
        }
        public override MissionBase Generate()
        {
            char[] chars = "АБВГДЕЁЖЗИКЛМНОПРСТУХЮЯ".ToCharArray();

            crypts = new List<Crypt>();
            List<string> codesAdded = new List<string>();
            string[] codes = GetRandomCodes(4);
            List<string> symbols = new List<string>();
            for (int i = 0; i < codes.Length; i++)
            {
                string c = chars[rnd.Next(0, chars.Length)].ToString();
                if (symbols.Contains(c))
                {
                    --i;
                    continue;
                }
                symbols.Add(c);
                crypts.Add(new Crypt(c, codes[i]));
                codesAdded.Add(codes[i]);
            }

            var temp = GetStringUsingLetters(crypts);

            string answer = temp[0];
            cryptedString = temp[1];

            string q = $"Разведчик передал в штаб радиограмму. Каждая буква закодирована. \n" +
                       $"Разделителей между кодами букв нет. Запишите в ответе переданную \n" +
                       $"последовательность букв. Коды букв: \n" +
                       $"{string.Join("\n", crypts)}\n" +
                       $"Закодированная строка: {cryptedString}";
            return new TextMission(NumOfMission, MissionName, q, answer, IsSolvedRight);
        }
        string cryptedString;
        List<Crypt> crypts;
        bool IsSolvedRight(string answerGiven)
        {
            if (answerGiven == null)
            {
                return false;
            }
            string answerCodeGiven = "";
            for (int i = 0; i < answerGiven.Length; i++)
            {
                answerCodeGiven += crypts.Where(x => x.Letter == answerGiven[i].ToString()).ToArray()[0].Code;
            }
            return answerCodeGiven == cryptedString;
        }
    }
}
