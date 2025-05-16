//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ParseConfig
{
    public static sessionFileDef LoadFromFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var options = new JsonSerializerOptions();
        options.Converters.Add(new PlotPageConfigConverter());

        sessionFileDef config = JsonSerializer.Deserialize<sessionFileDef>(json, options);
        return config;

        //string json = File.ReadAllText("default_config.json");
        //sessionFileDef config = JsonConvert.DeserializeObject<sessionFileDef>(json);
        //List<DAQDevice> devices = config.channels;
    }
}