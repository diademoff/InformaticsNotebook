Как добавить миссию (задание)?

1. Сначала определите тип, все типы миссий в папке Models\MissionTypes
От выбранного типа зависит то, как миссия будет отображаться на форме.
Допустим я хочу добавить такое задание: Сложите число [] и [].
Для этого лучше всего подходит тип TextMission
TextMission - там label с текстом задания вверху и textbox для вода ответа внизу.
2. Переходим к написанию кода:
Создаем класс Mission+[следующий номер] в папке ViewModels.
Добавляем аттрибут [Serializable].
Наследуем класс от MissionGenerator (находится в папке Models)
У нас получается что-то такое:

```csharp
using MyNotebook.Models;
using System;
namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission : MissionGenerator
    {
        public override MissionBase Generate()
        {
        }
    }
}
```

3. Теперь в методе Generate пишите код, который вернет объект класса TextMission (или любой MissionBase).
Можете пользоваться объектом класса "Random" rnd в методе Generate;
У меня получился такой код:

```csharp
using MyNotebook.Models;
using System;
namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission : MissionGenerator
    {
        public override MissionBase Generate()
        {
			int num1 = rnd.Next(1, 10);
			int num2 = rnd.Next(1, 10);
			string question = $"Найдите сумму чисел {num1} и {num2}";
			string answer = (num1 + num2).ToString();
			return new TextMission(0, "Сложение чисел", question, answer);
        }
    }
}
```
4. Теперь добавляем наше задание в общий список всех заданий.
В Классе MissionGeneratorCollection по аналогии дописываем "new Mission0()" в нужную категорию.
Если нужной категории нет, можете создать.
класс MissionGeneratorCollection - это просто хранилище генераторов всех миссий по категориям.