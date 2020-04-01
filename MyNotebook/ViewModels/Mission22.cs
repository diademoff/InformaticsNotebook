using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission22 : MissionGenerator
    {
        public override int NumOfMission => 22;
        public override string MissionName => "Термины по теме кодирование графики";
        public override int TimeToSolveMission => 415;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override MissionBase Generate()
        {
            List<MatchElement> elements = new List<MatchElement>();
            elements.Add(new MatchElement("Разрешение экрана", new[] { "величина, определяющая количество точек (элементов растрового изображения)",
                                                                       "это количество точек по вертикали и горизонтали, из которых состоит экран" }));
            elements.Add(new MatchElement("Пиксель", new[] {           "наименьший логический двумерный элемент цифрового изображения в растровой графике",
                                                                       "это самый маленький элемент изображения" }));
            elements.Add(new MatchElement("Частота обновления", new[] {"характеристика, обозначающая количество возможных изменений изображения в секунду ",
                                                                       "это величина, обозначающая, сколько раз ваш монитор обновляется новыми изображениями за одну секунду" }));
            elements.Add(new MatchElement("Векторная графика", new[] { "способ представления объектов и изображений (формат описания) в компьютерной графике, основанный на математическом описании элементарных геометрических объектов",
                                                                       "состоят не из пикселей, а из множества опорных точек и соединяющих их кривых" }));
            elements.Add(new MatchElement("Растровая графика", new[] { "изображение,которое складывается из множества маленьких ячеек — пикселей, где каждый пиксель содержит информацию о цвете",
                                                                       "изображение, представляющее собой сетку (мозаику) пикселей — цветных точек" }));
            elements.Add(new MatchElement("Фрактальная графика", new[] { "графика состоящая из частей, которые в каком-то смысле подобны целому",
                                                                       "графика ,в которой за основу метода построения изображений положен принцип наследования" }));
            elements.Add(new MatchElement("Палитра", new[]           { "фиксированный набор (диапазон) цветов и оттенков, имеющий вешнюю или цифровую реализацию в том или ином виде",
                                                                       "граниченный набор цветов, доступный графической системе компьютера" }));
            elements.Add(new MatchElement("Глубина цвета", new[] { "это термин компьютерной графики, означающий количество бит (объём памяти), используемое для хранения и представления цвета при кодировании одного пикселя растровой графики или видеоизображения" }));

            return new MatchMission(NumOfMission, MissionName, elements.ToArray());
        }
    }
}
