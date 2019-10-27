﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook.Models
{
    [Serializable]
    public abstract class MissionBase //task
    {
        protected Random rnd = new Random();
        public string Title { get; set; }
        public string Note { get; set; }
        public int NumOfMission { get; set; }
        public DateTime TimeMissionSolved { get; set; }
        public TimeSpan TimeSpanOnMission { get; set; }
        public abstract string String_AnswerGiven { get; }

        public abstract bool IsSolvedRight();
        public abstract bool IsAnswerGiven();

        public abstract TabPage GetTabPage(bool showAnswerAtOnce);

        public virtual void StartMonitorTabPageActiveCountTime(TabPage tp)
        {
            bool active = false;
            tp.Enter += (s, e) => active = true;
            tp.Leave += (s, e) => active = false;

            new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (active)
                    {
                        TimeSpanOnMission = TimeSpanOnMission.Add(TimeSpan.FromSeconds(1));
                    }
                }
            }).Start();
        }

        public override string ToString()
        {
            return $"{NumOfMission}. {Title}";
        }
    }
}
