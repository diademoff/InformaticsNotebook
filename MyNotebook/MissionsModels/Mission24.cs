﻿using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission24 : MissionGenerator
    {
        public override int NumOfMission => 24;
        public override string MissionName => "Сложные условия (Pascal)";
        public override int TimeToSolveMission => 220;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;

        [Serializable]
        enum Sym
        {
            More = 1,
            Less = 2
        }
        public override MissionBase Generate()
        {
        again:
            Sym s = (Sym)rnd.Next(1, 3);
            Sym t = (Sym)rnd.Next(1, 3);
            bool or = rnd.RandomBool();
            string or_and = or ? "or" : "and";
            string q = $"var s,t: integer;\n" +
                       $"begin\n" +
                       $"  readln(s);\n" +
                       $"  readln(t);\n" +
                       $"  if (s{ToStr(s)}10) {or_and} (t{ToStr(t)}10)\n" +
                       $"    then writeln('ДА')\n" +
                       $"    else writeln('НЕТ')\n" +
                       $"end.\n" +
                       $"Было проведено 9 запусков этой программы, при которых в качестве значений\n" +
                       $"переменных s и t вводились следующие пары чисел. При каких парах программа напечатала «ДА»\n";
            List<string> answers = new List<string>();
            List<int> expected = new List<int>();
            int index = 0;
            while (index != 9)
            {
                int n_s = rnd.Next(-20, 20);
                int n_t = rnd.Next(-20, 20);

                if (!answers.Contains($"({n_s}, {n_t}); "))
                {
                    answers.Add($"({n_s}, {n_t}); ");
                    index++;
                }

                if (IsOK(n_s, n_t, s, t, or))
                {
                    if (!expected.Contains(index))
                        expected.Add(index);
                }

            }
            if (expected.Count == 0 || expected.Count == answers.Count)
            {
                goto again;
            }
            for (int i = 0; i < answers.Count; i++)
            {
                q += $"{i + 1}. {answers[i]}\n";
            }
            return new TextMission(NumOfMission, MissionName, q, string.Join("", expected));
        }
        bool IsOK(int s, int t, Sym s_, Sym t_, bool or)
        {
            if (or)
            {
                return IsOk(s, s_) || IsOk(t, t_);
            }
            else
            {
                return IsOk(s, s_) && IsOk(t, t_);
            }

            bool IsOk(int n, Sym ss)
            {
                switch (ss)
                {
                    case Sym.More:
                        return n > 10;
                    case Sym.Less:
                        return n < 10;
                }
                throw new Exception("24. IsOK_");
            }
        }

        string ToStr(Sym s)
        {
            switch (s)
            {
                case Sym.More:
                    return ">";
                case Sym.Less:
                    return "<";
                default:
                    throw new Exception("24, less, more");
            }
        }
    }
}
