using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace handwritten_text_recognition
{
    public class Responsee
    {
        public string status { get; set; }
        public Recognitionresult[] recognitionResults { get; set; }
    }

    public class Recognitionresult
    {
        public int page { get; set; }
        public float clockwiseOrientation { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string unit { get; set; }
        public Line[] lines { get; set; }
    }

    public class Line
    {
        public int[] boundingBox { get; set; }
        public string text { get; set; }
        public Word[] words { get; set; }
    }

    public class Word
    {
        public int[] boundingBox { get; set; }
        public string text { get; set; }
        public string confidence { get; set; }
    }
}
