namespace MyNotebook.MissionsModels
{
    public static class Extentions
    {
        public static class URLGenerator
        {
            public static string[] part1 = new[]
            {
                "https",
                "http",
                "ftp"
            };
            public static string[] part2 = new[]
            {
                "://"
            };
            public static string[] part3 = new[]
            {
                "exams",
                "page",
                "home",
                "events"
            };
            public static string[] part4 = new[]
            {
                ".ru",
                ".org",
                ".info",
                ".edu",
                ".net",
                ".su"
            };
            public static string[] part5 = new[]
            {
                "/"
            };
            public static string[] part6 = new[]
            {
                "student",
                "data",
                "table",
                "biology",
                "biology",
                "literature"
            };
            public static string[] part7 = new[]
            {
                ".rar",
                ".html",
                ".htm",
                ".xls",
                ".jpg"
            };

            public static string GenerateURL()
            {
                return $"{part1.RandomElement()}{part2.RandomElement()}{part3.RandomElement()}{part4.RandomElement()}{part5.RandomElement()}{part6.RandomElement()}{part7.RandomElement()}";
            }
        }
    }
}
