using MyNotebook.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyNotebook.ViewModels
{
    /// <summary>
    /// Определения компьютерных комплектующих
    /// </summary>
    public class Mission4 : MissionGenerator
    {
        string title = "Определения компьютерных комплектующих";
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>();
            matchElements.Add(new MatchElement("Информация", new[] { "это совокупность каких-либо сведений, данных",
                                                                     "это осознанные сведения, которые являются объектом хранения, преобразования, передачи и использования" }));
            matchElements.Add(new MatchElement("Компьютер", new[] { "универсальная машина для работы с информацией",
                                                                    "это электронно-вычислительная машина (ЭВМ), предназначенная для работы в диалоге с человеком",
                                                                    "это устройство для сбора,обработки, хранения и вывода информации"}));
            matchElements.Add(new MatchElement("Процессор", new[] { "сердце компьютера , которое служит для обработки информации по заданной программе",
                                                                    "устройство, способное обрабатывать программный код и определяющее основные функции компьютера по обработке информации",
                                                                    "исполнитель машинных инструкций, часть аппаратного обеспечения компьютера или программируемого логического контроллера; отвечает за выполнение операций, заданных программами"}));
            matchElements.Add(new MatchElement("Оперативная память", new[] { "модуль, используемый для временного хранения данных при включенном питании",
                                                                             "память временного хранения данных и команд, необходимых процессору для выполнения операций в текущем сеансе работы"}));
            matchElements.Add(new MatchElement("Жёсткий диск", new[] { "основное устройство для храпения информации в компьютере",
                                                                       "запоминающее устройство, являющееся основным накопителем данных в большинстве компьютеров",
                                                                       "это постоянное запоминающее устройство компьютера, то есть, его основная функция - долговременное хранение данных"}));
            matchElements.Add(new MatchElement("Клавиатура", new[] { "устройство, позволяющее пользователю вводить информацию в компьютер",
                                                                     "это основное устройство ввода числовой и текстовой информации",
                                                                     "это клавишное устройство, предназначенное для управления работой компьютера и ввода в него информации"}));
            matchElements.Add(new MatchElement("Монитор", new[] { "устройство, предназначенное для воспроизведения видеосигнала и визуального отображения информации, полученной от компьютера",
                                                                  "устройство отображения компьютерной информации"}));
            matchElements.Add(new MatchElement("Мышь", new[] { "координатное устройство для управления курсором и отдачи различных команд компьютеру",
                                                               "периферийное устройство ввода информации для управления курсором и подачи команд ПК"}));
            matchElements.Add(new MatchElement("Принтер", new[] { "периферийное устройство компьютера, предназначенное для вывода текстовой или графической информации, хранящейся в компьютере",
                                                                  "устройство печати цифровой информации на вещественный носитель"}));
            matchElements.Add(new MatchElement("Данные", new[] { "это совокупность сведений, зафиксированных на определенном носителе в форме, пригодной для постоянного хранения, передачи и обработки",
                                                                 "представление фактов, понятий или инструкций в форме, приемлемой для обработки ЭВМ",
                                                                 "сведения, факты, показатели, выраженные как в числовой, так и любой другой форме"}));
            matchElements.Add(new MatchElement("Аппаратное обеспечение", new[] { "электронные и механические части вычислительного устройства",
                                                                                 "это система взаимосвязанных технических устройств, предназначенных для ввода, обработки, хранения и вывода информации",
                                                                                 "это все аппаратные средства, из которых состоит компьютер, т.е. вся аппаратура, необходимая для работы компьютера"}));

            List<MatchElement> matchElementsInResult = new List<MatchElement>();
            for (int i = 0; i < matchElements.Count;)
            {
                var elToAdd = matchElements[rnd.Next(0, matchElements.Count)];
                if (!matchElementsInResult.Contains(elToAdd))
                {
                    matchElementsInResult.Add(elToAdd);
                    i++;
                }
            }
            matchElementsInResult = matchElementsInResult.OrderBy(x => rnd.Next()).ToList(); //shuffle array
            string[] terms = new string[8];
            string[] defs = new string[8];
            int[] answer = new int[8];
            for (int i = 0; i < terms.Length; i++)
            {
                var currentElement = matchElementsInResult[i];

                terms[i] = currentElement.Term;
                defs[i] = currentElement.Definitions.ToList().OrderBy(x => rnd.Next()).ToArray()[0]; //random element
                int currAnswer = i;
                currAnswer++;
                answer[i] = currAnswer;
            }
            //shuffle defs and answer
            for (int i = 0; i < defs.Length; i++)
            {
                int index1 = rnd.Next(0, defs.Length), index2 = rnd.Next(0, defs.Length);

                (defs[index1], defs[index2]) = (defs[index2], defs[index1]);
                (answer[index1], answer[index2]) = (answer[index2], answer[index1]);
            }

            return new MissionBase(4, title, terms, defs, answer);
        }
    }
}
