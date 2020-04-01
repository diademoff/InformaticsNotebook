using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission16 : MissionGenerator
    {
        public override int NumOfMission => 16;
        public override string MissionName => "Логические выражения";
        public override int TimeToSolveMission => 197;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override string Tooltip => "Среди чисел выберите те, которые удовлетворяют условию";

        public new static Random rnd = new Random();
        struct LogicMission
        {
            /// <summary>
            /// не(first)
            /// </summary>
            public bool notFirst;
            /// <summary>
            /// 0 - <;
            /// 1 - >
            /// </summary>
            public int first;
            /// <summary>
            /// число в первом выражении
            /// </summary>
            public int numInFirst;
            /// <summary>
            /// не(second)
            /// </summary>
            public bool notSecond;
            /// <summary>
            ///0 - четное; 
            ///1 - нечетное; 
            ///2 - кратно [num] 
            /// </summary>
            public int second;
            /// <summary>
            /// число во втором выражении
            /// </summary>
            public int numInSecond;
            /// <summary>
            /// 0 - и;
            /// 1 - или
            /// </summary>
            public int logic;

            public LogicMission(bool notFirst,
                                int first,
                                int numInFirst,
                                bool notSecond,
                                int second,
                                int numInSecond,
                                int logic)
            {
                this.notFirst = notFirst;
                this.first = first;
                this.numInFirst = numInFirst;
                this.notSecond = notSecond;
                this.second = second;
                this.numInSecond = numInSecond;
                this.logic = logic;
            }

            public void SetAllRandomValues()
            {
                notFirst = rnd.Next(0, 2) == 0;
                first = rnd.Next(0, 2);
                notSecond = rnd.Next(0, 2) == 0;
                second = rnd.Next(0, 3);
                logic = rnd.Next(0, 2);

                numInFirst = rnd.Next(20, 80);
                numInSecond = rnd.Next(2, 6);
            }

            public string GetString()
            {
                string result = "";
                result += notFirst ? "не" : "";
                result += first == 0 ? $"(x < {numInFirst})" : $"(x > {numInFirst})";

                result += logic == 0 ? " и " : " или ";

                result += notSecond ? "не" : "";
                switch (second)
                {
                    case 0:
                        result += $"(x четное)";
                        break;
                    case 1:
                        result += $"(x нечетное)";
                        break;
                    case 2:
                        result += $"(x кратно {numInSecond})";
                        break;
                }

                return result;
            }

            public bool IsRight(int input)
            {
                bool b1 = first == 0 ? input < numInFirst : input > numInFirst;
                if (notFirst)
                {
                    b1 = !b1;
                }

                bool b2 = false;
                switch (second)
                {
                    case 0:
                        b2 = input % 2 == 0;
                        break;
                    case 1:
                        b2 = input % 2 != 0;
                        break;
                    case 2:
                        b2 = input % numInSecond == 0;
                        break;
                }
                if (notSecond)
                {
                    b2 = !b2;
                }

                bool result = logic == 0 ? (b1 & b2) : (b1 | b2);
                return result;
            }
        }
        public override MissionBase Generate()
        {
            while (true)
            {
                try
                {
                    LogicMission logicMission = new LogicMission();

                    logicMission.SetAllRandomValues();

                    List<int> right = new List<int>();
                    List<int> wrong = new List<int>();

                    for (int i = logicMission.numInFirst - 15; i < logicMission.numInFirst + 15; i++)
                    {
                        if (logicMission.IsRight(i))
                        {
                            right.Add(i);
                        }
                        else
                        {
                            wrong.Add(i);
                        }
                    }

                    int rightAnswer = rnd.Next(0, 4);
                    string nums = "";
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == rightAnswer)
                        {
                            nums += $"{i + 1}. {right.OrderBy(x => rnd.Next()).ToArray()[0]}\n";
                            continue;
                        }
                        int w = wrong.OrderBy(x => rnd.Next()).ToArray()[0];
                        wrong.Remove(w);
                        nums += $"{i + 1}. {w}\n";
                    }

                    string q = $"Среди чисел выберите те, которые удовлетворяют условию\n" +
                               $"{logicMission.GetString()}\n{nums}";

                    var mission = new TextMission(16, "Логические выражения", q, (rightAnswer + 1).ToString());
                    return mission;
                }
                catch { }
            }
        }
    }
}
