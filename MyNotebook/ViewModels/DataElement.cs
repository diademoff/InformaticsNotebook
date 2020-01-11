using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyNotebook.ViewModels
{
    public class DataElement
    {
        public string Term { get; private set; }
        public Bitmap[] Images { get; private set; }
        public string[] Defenitions { get; private set; }

        public DataElement(string term, Bitmap[] images, string[] defenitions)
        {
            Term = term ?? throw new ArgumentNullException(nameof(term));
            Images = images ?? throw new ArgumentNullException(nameof(images));
            Defenitions = defenitions ?? throw new ArgumentNullException(nameof(defenitions));
        }

        public DataElement(string term, string[] defenitions)
        {
            Term = term ?? throw new ArgumentNullException(nameof(term));
            Images = new Bitmap[0];
            Defenitions = defenitions ?? throw new ArgumentNullException(nameof(defenitions));
        }

        public DataElement(string term, Bitmap[] images)
        {
            Term = term ?? throw new ArgumentNullException(nameof(term));
            Images = images ?? throw new ArgumentNullException(nameof(images));
            Defenitions = new string[0];
        }

        public override int GetHashCode()
        {
            return Term.GetHashCode();
        }
    }

    public static class DataCollection
    {
        static HashSet<DataElement> DataElements;

        static DataCollection()
        {
            DataElements = new HashSet<DataElement>(new DataElement[]
            {
                new DataElement("Процессор", new Bitmap[] {Properties.Resources.cpu1, Properties.Resources.cpu2, Properties.Resources.cpu3 },
                    new string[]{ "сердце компьютера , которое служит для обработки информации по заданной программе",
                                  "устройство, способное обрабатывать программный код и определяющее основные функции компьютера по обработке информации",
                                  "исполнитель машинных инструкций, часть аппаратного обеспечения компьютера или программируемого логического контроллера; отвечает за выполнение операций, заданных программами" }),
                new DataElement("Жесткий диск", new Bitmap[] { Properties.Resources.hdd1, Properties.Resources.hdd2, Properties.Resources.hdd3 },
                    new string[]{ "основное устройство для хранения информации в компьютере",
                                  "запоминающее устройство, являющееся основным накопителем данных в большинстве компьютеров",
                                  "это постоянное запоминающее устройство компьютера, то есть, его основная функция - долговременное хранение данных" }),
                new DataElement("Материнская плата", new Bitmap[] { Properties.Resources.motherboard1, Properties.Resources.motherboard2, Properties.Resources.motherboard3,  Properties.Resources.motherboard4 },
                    new string[]{ }),
                new DataElement("Сетевая карта", new Bitmap[] { Properties.Resources.networkcard1, Properties.Resources.networkcard2, Properties.Resources.networkcard3 },
                    new string[]{ }),
                new DataElement("Оперативная память", new Bitmap[] { Properties.Resources.ram1, Properties.Resources.ram2, Properties.Resources.ram3},
                    new string[]{ "модуль, используемый для временного хранения данных при включенном питании",
                                  "память временного хранения данных и команд, необходимых процессору для выполнения операций в текущем сеансе работы" }),
                new DataElement("Звуковая карта", new Bitmap[] { Properties.Resources.soundcard1, Properties.Resources.soundcard2, Properties.Resources.soundcard3 },
                    new string[]{ }),
                new DataElement("Видеокарта", new Bitmap[] {  Properties.Resources.videocard1, Properties.Resources.videocard2 },
                    new string[]{ }),

                new DataElement("Информация", new[] { "это совокупность каких-либо сведений, данных",
                                                      "это осознанные сведения, которые являются объектом хранения, преобразования, передачи и использования" }),
                new DataElement("Компьютер", new[] { "универсальная машина для работы с информацией",
                                                     "это электронно-вычислительная машина (ЭВМ), предназначенная для работы в диалоге с человеком",
                                                     "это устройство для сбора,обработки, хранения и вывода информации"}),
                new DataElement("Клавиатура", new[] { "устройство, позволяющее пользователю вводить информацию в компьютер",
                                                      "это основное устройство ввода числовой и текстовой информации",
                                                      "это клавишное устройство, предназначенное для управления работой компьютера и ввода в него информации"}),
                new DataElement("Монитор", new[] { "устройство, предназначенное для воспроизведения видеосигнала и визуального отображения информации, полученной от компьютера",
                                                   "устройство отображения компьютерной информации"}),
                new DataElement("Мышь", new[] { "координатное устройство для управления курсором и отдачи различных команд компьютеру",
                                                "периферийное устройство ввода информации для управления курсором и подачи команд ПК"}),
                new DataElement("Принтер", new[] { "периферийное устройство компьютера, предназначенное для вывода текстовой или графической информации, хранящейся в компьютере",
                                                   "устройство печати цифровой информации на вещественный носитель"}),
                new DataElement("Данные", new[] { "это совокупность сведений, зафиксированных на определенном носителе в форме, пригодной для постоянного хранения, передачи и обработки",
                                                  "представление фактов, понятий или инструкций в форме, приемлемой для обработки ЭВМ",
                                                  "сведения, факты, показатели, выраженные как в числовой, так и любой другой форме"}),
                new DataElement("Аппаратное обеспечение", new[] { "электронные и механические части вычислительного устройства",
                                                                  "это система взаимосвязанных технических устройств, предназначенных для ввода, обработки, хранения и вывода информации" })

            });
        }

        public static DataElement[] GetAllElementsWhere(bool needImage, bool needDefenition)
        {
            List<DataElement> res = new List<DataElement>();
            foreach (var item in DataElements)
            {
                if (needImage && item.Images.Length == 0)
                {
                    continue;
                }
                if (needDefenition && item.Defenitions.Length == 0)
                {
                    continue;
                }

                res.Add(item);
            }
            return res.ToArray();
        }
    }
}