using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PlotPageConfigConverter : JsonConverter<PlotPageConfig>
{
    public override PlotPageConfig Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new PlotPageConfig();
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        foreach (var property in root.EnumerateObject())
        {
            switch (property.Name)
            {
                case "numPages":
                    result.numPages = property.Value.GetInt32();
                    break;
                case "activePage":
                    result.activePage = property.Value.GetInt32();
                    break;
                case "activePageName":
                    result.activePageName = property.Value.GetString();
                    break;
                case "activeChans":
                    result.activeChans = JsonSerializer.Deserialize<List<int>>(property.Value.GetRawText(), options);
                    break;
                case "selectedPlotPageIndex":
                    result.selectedPlotPageIndex = property.Value.GetInt32();
                    break;
                case "nPageConfigs":
                    result.nPageConfigs = property.Value.GetInt32();
                    break;
                default:
                    if (property.Name.StartsWith("DefaultPlotPage") || property.Name.StartsWith("userDefPlotPage"))
                    {
                        var detail = JsonSerializer.Deserialize<PlotPageDetail>(property.Value.GetRawText(), options);
                        result.DefaultPlotPages[property.Name] = detail;
                    }
                    break;
            }
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, PlotPageConfig value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}



//using System.Collections.Generic;
//using System.Text.Json.Serialization;
//using System.Text.Json;
//using System;

//public class PlotPageConfigConverter : JsonConverter<PlotPageConfig>
//{
//    public override PlotPageConfig Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//    {
//        var config = new PlotPageConfig();

//        using var doc = JsonDocument.ParseValue(ref reader);
//        var root = doc.RootElement;

//        foreach (var prop in root.EnumerateObject())
//        {
//            switch (prop.Name)
//            {
//                case "numPages":
//                    config.numPages = prop.Value.GetInt32();
//                    break;
//                case "activePage":
//                    config.activePage = prop.Value.GetInt32();
//                    break;
//                case "activePageName":
//                    config.activePageName = prop.Value.GetString();
//                    break;
//                case "activeChans":
//                    config.activeChans = JsonSerializer.Deserialize<List<int>>(prop.Value.GetRawText());
//                    break;
//                case "selectedPlotPageIndex":
//                    config.selectedPlotPageIndex = prop.Value.GetInt32();
//                    break;
//                case "nPageConfigs":
//                    config.nPageConfigs = prop.Value.GetInt32();
//                    break;
//                default:
//                    if (prop.Name.StartsWith("DefaultPlotPage"))
//                    {
//                        var detail = JsonSerializer.Deserialize<PlotPageDetail>(prop.Value.GetRawText(), options);
//                        config.DefaultPlotPages[prop.Name] = detail;
//                    }
//                    break;
//            }
//        }

//        return config;
//    }

//    public override void Write(Utf8JsonWriter writer, PlotPageConfig value, JsonSerializerOptions options)
//    {
//        throw new NotImplementedException();
//    }
//}
