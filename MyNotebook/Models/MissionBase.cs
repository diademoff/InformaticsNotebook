using MyNotebook.Models.MissionTypes;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MyNotebook.Models
{
    [XmlInclude(typeof(ChoosePictureMission))]
    [XmlInclude(typeof(MatchMission))]
    [XmlInclude(typeof(SelectMission))]
    [XmlInclude(typeof(TextMission))]
    [Serializable]
    public abstract class MissionBase : IEquatable<MissionBase> //task
    {
        protected Random rnd = new Random();
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public int NumOfMission { get; set; }
        /// <summary>
        /// Время когда на миссию дан ответ
        /// </summary>
        public DateTime TimeMissionSolved { get; set; }
        public int TimeSpanOnMissionSeconds { get; set; }
        public abstract string String_AnswerExpecting { get; set; }
        public abstract string String_AnswerGiven { get; }
        public virtual int MaxNumInTest { get; set; } = 10;
        public MissionType TypeOfMission { get; set; } = MissionType.Theory;
        public int TimeNeedToSolveMissionSeconds { get; set; }

        ~MissionBase()
        {
            if (!IsSolved())
            {
                TimeMissionSolved = DateTime.Now;
            }
        }

        public abstract bool IsSolvedRight();
        public abstract bool IsSolved();

        public abstract TabPage GetTabPage(bool showAnswerAtOnce);

        public abstract TabPage GetSolvedTabPage();

        public abstract string GetHTMLResult();

        public virtual void StartMonitorTabPageActiveCountTime(TabPage tp)
        {
            bool active = false;
            tp.Enter += (s, e) => active = true;
            tp.Leave += (s, e) => active = false;


            var task = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (active)
                    {
                        TimeSpanOnMissionSeconds += 1;
                    }
                }
            });
            task.IsBackground = true;
            task.Start();
        }

        public override string ToString()
        {
            return $"{NumOfMission}. {Title}";
        }

        public bool Equals(MissionBase other)
        {
            if (NumOfMission != other.NumOfMission)
            {
                return false;
            }
            return String_AnswerExpecting.Equals(other.String_AnswerExpecting);
        }
    }
}
