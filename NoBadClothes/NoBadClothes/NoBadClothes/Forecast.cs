using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NoBadClothes
{
    public class Forecast
    {
        public string approvedTime { get; set; }
        public string referenceTime { get; set; }
        public Geometry geometry { get; set; }
        public List<Timeseries> timeSeries { get; set; }


        public class Geometry
        {
            public string type { get; set; }
            public float[][] coordinates { get; set; }
        }

        public class Timeseries
        {
            public string validTime { get; set; }
            public List<Parameter> parameters { get; set; }
        }

        public class Parameter
        {
            public string name { get; set; }
            public string levelType { get; set; }
            public int level { get; set; }
            public string unit { get; set; }
            public List<float> values { get; set; }
        }

    }
}
