using System.Collections.Generic;

public class DAQDevice
{
    public string name { get; set; }
    public string product_type { get; set; }
    public string serial_number { get; set; }
    public double ai_max_single_chan_rate { get; set; }
    public double ai_max_multi_chan_rate { get; set; }
    public double ai_min_rate { get; set; }
    public List<double> ai_voltage_ranges { get; set; }
    public List<string> ai_meas_types { get; set; }
    public bool anlg_trig_supported { get; set; }
    public List<AIChannel> ai_channels { get; set; }
}

public class AIChannel
{
    public string name { get; set; }
    public double ai_max { get; set; }
    public double ai_min { get; set; }
    public List<string> ai_term_cfgs { get; set; }
    public string ai_meas_type { get; set; }
    public string ai_coupling { get; set; }
    public double ai_microphone_sensitivity { get; set; }
    public double ai_lowpass_cutoff_freq { get; set; }
    public string note { get; set; }
}
