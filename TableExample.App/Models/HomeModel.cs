namespace TableExample.App
{
    using System.Collections.Generic;

    public class HomeModel
    {
        public List<Row> Rows { get; } = new List<Row>();

        public class Row
        {
            public string Value1 { get; set; }

            public string Value2 { get; set; }
        }
    }
}