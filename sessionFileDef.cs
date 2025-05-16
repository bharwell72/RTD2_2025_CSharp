using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

public class sessionFileDef
{
    public List<Channel> channels { get; set; }
    public General general { get; set; }
    public Trigger trigger { get; set; }
    public MultiSelect multiSelection { get; set; }
    public List<Board> boards { get; set; }
    public PlotPageConfig plotPageConfig { get; set; }
}

public class Channel
{
    public string msid { get; set; }
    public string units { get; set; }
    public List<DynRange> dynRange { get; set; }
    public List<string> coupling { get; set; }
    public List<string> measType { get; set; }
    public double gain { get; set; }
    public double sensitivity { get; set; }
    public double dcOffset { get; set; }

    public int dRangeSelectedIdx { get; set; }
    public int couplingSelectedIdx { get; set; }
    public int measTypeSelectedIdx { get; set; }
}

public class DynRange
{
    public string str { get; set; }
    public double Max { get; set; }
    public double Min { get; set; }
    public string Units { get; set; }
    //[JsonPropertyName("str")]
    //public object str { get; set; }

    //public double Max { get; set; }
    //public double Min { get; set; }
    //public string Units { get; set; }

    //[JsonIgnore]
    //public List<string> StrList
    //{
    //    get
    //    {
    //        if (str is string s)
    //            return new List<string> { s };

    //        if (str is JsonElement elem)
    //        {
    //            if (elem.ValueKind == JsonValueKind.String)
    //            {
    //                return new List<string> { elem.GetString() };
    //            }
    //            else if (elem.ValueKind == JsonValueKind.Array)
    //            {
    //                return elem.EnumerateArray().Select(e => e.GetString()).ToList();
    //            }
    //        }

    //        if (str is IEnumerable<string> list)
    //            return list.ToList();

    //        return new List<string>();
    //    }
    //}
}

//public class DynRangeListConverter : JsonConverter<List<DynRange>>
//{
//    public override List<DynRange> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        if (reader.TokenType == JsonTokenType.StartObject)
//        {
//            // Single object - wrap it in a list
//            var item = JsonSerializer.Deserialize<DynRange>(ref reader, options);
//            return new List<DynRange> { item };
//        }
//        else if (reader.TokenType == JsonTokenType.StartArray)
//        {
//            return JsonSerializer.Deserialize<List<DynRange>>(ref reader, options);
//        }
//        else
//        {
//            throw new JsonException("Unexpected token type for dynRange");
//        }
//    }

//    public override void Write(Utf8JsonWriter writer, List<DynRange> value, JsonSerializerOptions options)
//    {
//        JsonSerializer.Serialize(writer, value, options);
//    }
//}

public class General
{
    public int numBoards { get; set; }
    public List<int> chanNumber { get; set; }
    public int totalChans { get; set; }
    public string logFilePath { get; set; }
    public string configFilePathAndName { get; set; }
    public string defaultDataStoragePath { get; set; }
    public string dataFileName { get; set; }
    public int sampRate { get; set; }
    public int blockSize { get; set; }
    public int sampRateIdx { get; set; }
    public int blockSizeIdx { get; set; }
}

public class Trigger
{
    public int selectedTriggerChannel { get; set; }
    public int triggerChannelIndex { get; set; }
    public double triggerVoltage { get; set; }
}

public class MultiSelect
{
    public bool selAllRadio { get; set; }
    public string selVoltRange { get; set; }
    public string selCoupling { get; set; }
    public string selInputMode { get; set; }
    public int selVoltRangeIdx { get; set; }
    public int selCouplingIdx { get; set; }
    public int selInputModeIdx { get; set; }
}

public class Board
{
    public int nChan { get; set; }
}

//public class BoardList
//{
//    [JsonPropertyName("boards")]
//    public object boards { get; set; }

//    [JsonIgnore]
//    public List<string> boardList
//    {
//        get
//        {
//            if (boards is string s)
//                return new List<string> { s };

//            if (boards is JsonElement elem)
//            {
//                if (elem.ValueKind == JsonValueKind.String)
//                {
//                    return new List<string> { elem.GetString() };
//                }
//                else if (elem.ValueKind == JsonValueKind.Array)
//                {
//                    return elem.EnumerateArray().Select(e => e.GetString()).ToList();
//                }
//            }

//            if (boards is IEnumerable<string> list)
//                return list.ToList();

//            return new List<string>();
//        }
//    }
//}

public class PlotPageConfig
{
    public int numPages { get; set; }
    public int activePage { get; set; }
    public string activePageName { get; set; }
    public List<int> activeChans { get; set; }
    public int selectedPlotPageIndex { get; set; }
    public int nPageConfigs { get; set; }
    public Dictionary<string, PlotPageDetail> DefaultPlotPages { get; set; } = new();
}

public class PlotPageDetail
{
    public List<PlotObject> plotObjects { get; set; }
    public List<int> selChans { get; set; }
    public int axesPerPage { get; set; }
}

public class PlotObject
{
    public string typePlot { get; set; }
    public string ChannelName { get; set; }
    public int ChannelInd { get; set; }
    public string ChannelEU { get; set; }
    public double ChannelSens { get; set; }
    public double ChannelGain { get; set; }
    public double ChannelDCOffset { get; set; }
    public double ChannelVoltRange { get; set; }
    public string ChannelClipping { get; set; }
    public double maxValAllChans { get; set; }
    public int clipCount { get; set; }
    public List<int> chanIdx { get; set; }
    public List<int> pntInBlk { get; set; }
    public double vRange { get; set; }
    public double Fs { get; set; }
    public int blocksize { get; set; }
    public double timePerBlock { get; set; }
    public bool noReduction { get; set; }
    public string ReductionMethod { get; set; }
    public List<object> listeners { get; set; }
    public int procBlockCount { get; set; }
    public int blockSinceReset { get; set; }
    public int nextDraw { get; set; }
    public int drawFrequency { get; set; }
    public double totalProcessTime { get; set; }
    public int COUNTS_MODE { get; set; }
    public int VOLTS_MODE { get; set; }
    public int EU_MODE { get; set; }
    public int unitsMode { get; set; }
    public string UnitsModeDesc { get; set; }
    public int MISSING_BLOCK_USE_NAN { get; set; }
    public int MISSING_BLOCK_USE_PREV_BLOCK { get; set; }
    public int MISSING_BLOCK_USE_NOTHING { get; set; }
    public int MissingBlockStrategy { get; set; }
    public double voltsPerCount { get; set; }
    public List<int> LineColor { get; set; }
    public string LineStyle { get; set; }
    public PlotData Data { get; set; }
    public bool firstDraw { get; set; }
}

public class PlotData
{
    public List<double> x { get; set; }
    public List<double> y { get; set; }
}

//public class dynRangeObj
//{
//    public string str { get; set; }
//    public double Max { get; set; }
//    public double Min { get; set; }
//    public string Units { get; set; }
//}

//public class tableConfig
//{
//    //public int chNum { get; set; }
//    public string msid { get; set; }
//    public string units { get; set; }
//    public dynRangeObj dynRange { get; set; }
//    public List<string> coupling { get; set; }
//    public List<string> measType { get; set; }
//    public double gain { get; set; }
//    public double sensitivity { get; set; }
//    public double dcOffset { get; set; }

//    public int dRangeSelectedIdx { get; set; }
//    public int couplingSelectedIdx { get; set; }
//    public int measTypeIdx { get; set; }
//}

//        //public class Board
//        //{
//        //    public int id { get; set; }
//        //    public List<Channel> channels { get; set; }
//        //}

//        //public class RootConfig
//        //{
//        //    //public GeneralConfig general { get; set; }
//        //    //public TriggerConfig trigger { get; set; }
//        //    //public MultiSelection multiSelection { get; set; }
//        //    public List<Board> boards { get; set; }
//        //    // and so on
//        //}