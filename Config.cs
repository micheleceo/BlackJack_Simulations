using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static BlackJackSimul.ShoeEditor;

namespace BlackJackSimul
{
    /// <summary>
    /// Configuration parameters read from Configuration.json
    /// </summary>
    public class Config
    {
        public int ShoeDeckTotalNumber { get; set; } = 8;
        public int ShoeDeckToExtractNumber { get; set; } = 4;
        public int SimulationTotalShoes { get; set; } = 100;
        public float ShoeTrueCounter { get; set; } = 0;
        [JsonProperty("CounterType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CounterType CounterT { get; set; }
        public float FlatBet { get; set; }
        public bool f_dealer_Soft17_hit { get; set; } = false;
        public bool f_print_hands_on_console { get; set; } = true;

        public Config Clone()
        {
            return (Config)MemberwiseClone();
        }

    }//end of Class

}//end of namespace
