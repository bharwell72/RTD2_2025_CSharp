using System.Collections.Generic;
using System.Text.Json.Serialization;

public class PlotPageConfig
{
    public int numPages { get; set; }
    public int activePage { get; set; }
    public string activePageName { get; set; }
    public List<int> activeChans { get; set; }
    public int selectedPlotPageIndex { get; set; }
    public int nPageConfigs { get; set; }

    [JsonIgnore]
    public Dictionary<string, PlotPageDetail> DefaultPlotPages { get; set; } = new Dictionary<string, PlotPageDetail>();
}