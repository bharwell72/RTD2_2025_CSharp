using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ParseConfig
{
    public static sessionFileDef LoadFromFile(string filePath)
    {
        string json = File.ReadAllText(filePath);
        sessionFileDef config = JsonSerializer.Deserialize<sessionFileDef>(json);
        return config;
    }
}