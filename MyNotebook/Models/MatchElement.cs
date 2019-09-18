using System;

namespace MyNotebook.Models
{
    public class MatchElement
    {
        /// <summary>
        /// Темин
        /// </summary>
        public string Term { get; private set; }

        /// <summary>
        /// Определение для термина
        /// </summary>
        public string[] Definitions { get; private set; }

        public MatchElement(string term, string[] definitions)
        {
            Term = term ?? throw new ArgumentNullException(nameof(term));
            Definitions = definitions ?? throw new ArgumentNullException(nameof(definitions));
        }
    }
}
