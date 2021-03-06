﻿using MyNotebook.Models;
using System;
using System.IO;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission19 : MissionGenerator
    {
        public override int NumOfMission => 19;
        public override string MissionName => "Файловая система";
        public override int TimeToSolveMission => 180;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;

        string answer;

        public override MissionBase Generate()
        {
            string path = GeneratePath();
            answer = Directory.GetParent(Directory.GetParent(path).FullName).FullName + "\\" + Path.GetFileName(path);
            string q = $"В каталоге находился файл {Path.GetFileName(path)}. В этом каталоге создали подкаталог и\n" +
                       $"переместили файл туда. Полное имя файла стал: {path}.\n" +
                       $"Укажите имя файла до перемещения.";

            return new TextMission(NumOfMission, MissionName, q, answer, solvedRight);
        }

        bool solvedRight(string a)
        {
            if (a == null)
            {
                return false;
            }
            return answer.ToLower() == a.ToLower();
        }

        string GeneratePath()
        {
            string path = "";
            path += rnd.RandomBool() ? "C:\\" : "D:\\";
            switch (rnd.Next(0, 3))
            {
                case 0:
                    path += rnd.Next(2000, 2020) + "\\";
                    path += rnd.RandomBool() ? "июль\\" : rnd.RandomBool() ? "июнь\\" : "август\\";
                    path += rnd.RandomBool() ? "сирень.doc" : "отдых.doc";
                    return path;
                case 1:
                    path += "Документы\\";
                    path += rnd.RandomBool() ? "покупка\\" : rnd.RandomBool() ? "договоры\\" : "срочно\\";
                    path += rnd.RandomBool() ? "список.txt" : "информация.doc";
                    return path;
                case 2:
                    path += rnd.RandomBool() ? "img\\" : "pic\\";
                    path += "wallpaper\\";
                    path += rnd.RandomBool() ? "rain.png" : "hill.jpg";
                    return path;
                default:
                    throw new Exception("Mission 19 error");
            }
        }
    }
}
