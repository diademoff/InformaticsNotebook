using System;
using System.Drawing;

namespace MyNotebook.MissionsModels
{
    /// <summary>
    /// Element for DataCollection
    /// </summary>
    [Serializable]
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
}