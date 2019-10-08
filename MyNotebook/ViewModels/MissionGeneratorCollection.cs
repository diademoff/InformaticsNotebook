using MyNotebook.Models;

namespace MyNotebook.ViewModels
{
    public static class MissionGeneratorCollection
    {
        public static MissionGenerator[] Missions = new MissionGenerator[]
        {
            new Mission1(),
            new Mission2(),
            new Mission3(),
            new Mission4(),
            new Mission5()
        };
    }
}
