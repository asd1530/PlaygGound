using Newtonsoft.Json;

namespace Common.Sie
{

    public class SieObject   
    {
        [JsonIgnore]
        public SieDimension Dimension { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        
    }
}
