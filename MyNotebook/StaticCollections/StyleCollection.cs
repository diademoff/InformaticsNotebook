using MyNotebook.Forms;
using System.Drawing;

namespace MyNotebook.StaticCollections
{
    public static class StyleCollection
    {
        public static StyleNotebook[] Styles = new StyleNotebook[]
        {
            new StyleNotebook()
            {
                Name = "Светлая тема",

                ContainerBackColor = Color.FromArgb(255, 255, 255),

                ButtonForeColor = Color.FromArgb(20, 20, 20),
                ButtonMouseDownBackColor = Color.FromArgb(255, 240, 188),
                ButtonFlatAppearanceBorderColor = Color.FromArgb(229, 229, 229),

                TextForeColor = Color.FromArgb(20, 20, 20),

                GroupBoxForeColor = Color.FromArgb(128, 128, 128),

                PanelsBackColor = Color.FromArgb(240, 240, 240)
            },
            new StyleNotebook()
            {
                Name = "Тёмная тема",

                ContainerBackColor = Color.FromArgb(25, 25, 25),

                ButtonForeColor = Color.FromArgb(250, 250, 250),
                ButtonMouseDownBackColor = Color.FromArgb(91, 71, 0),
                ButtonFlatAppearanceBorderColor = Color.FromArgb(250, 250, 250),

                TextForeColor = Color.FromArgb(240, 240, 240),

                GroupBoxForeColor = Color.FromArgb(240, 240, 240),

                PanelsBackColor = Color.FromArgb(35, 35, 35)
            }
        };

        public static StyleNotebook GetStyleByName(string name)
        {
            foreach (StyleNotebook style in Styles)
            {
                if (style.Name == name)
                {
                    return style;
                }
            }

            throw new System.Exception("Style not found");
        }
    }
}
