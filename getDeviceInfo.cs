using System;
using System.Collections.Generic;
using NationalInstruments.DAQmx;

//namespace RTD2_CSharp
public class DAQChannelInfo
{
    public string DeviceName { get; set; }
    public string ChannelName { get; set; }
    public string ProductType { get; set; }
    public string SerialNumber { get; set; }
    public double MinVoltage { get; set; }
    public double MaxVoltage { get; set; }
    public string PhysicalChannel { get; set; }
    public string Coupling { get; set; }
    public List<string> SupportedCouplings { get; set; } = new List<string>();
    public string MeasurementType { get; set; }
    public string TerminalConfig { get; set; }
    public string Units { get; set; }
    public string SensorType { get; set; }
    public string ExcitationSource { get; set; }
}

public class DAQDeviceInfo
{
    public string DeviceName { get; set; }
    public List<DAQChannelInfo> Channels { get; set; } = new List<DAQChannelInfo>();
}

public class DeviceEnumerator
{
    public static List<DAQDeviceInfo> GetAllDeviceInfo()
    {
        List<DAQDeviceInfo> devices = new List<DAQDeviceInfo>();
        //List<string> supportedCouplings = new List<string>();

        foreach (string deviceName in DaqSystem.Local.Devices)
        {
            Device device = DaqSystem.Local.LoadDevice(deviceName);
            DAQDeviceInfo devInfo = new DAQDeviceInfo
            {
                DeviceName = deviceName
            };

            foreach (string channel in device.AIPhysicalChannels)
            {
                try
                {
                    using (Task task = new Task())
                    {
                        var aiChannel = task.AIChannels.CreateVoltageChannel(
                            channel,
                            "",
                            AITerminalConfiguration.Pseudodifferential,
                            -10.0,
                            10.0,
                            AIVoltageUnits.Volts
                        );

                        task.Control(TaskAction.Verify);
                        List<string> supportedCouplings = new List<string>();
                        var channelInfo = new DAQChannelInfo
                        {
                            ChannelName = aiChannel.PhysicalName
                        };
                        
                        foreach (AICoupling coupling in Enum.GetValues(typeof(AICoupling)))
                        {
                            try
                            {
                                aiChannel.Coupling = coupling;
                                channelInfo.SupportedCouplings.Add(coupling.ToString());
                            }
                            catch (DaqException)
                            {
                                // Not supported, skip
                            }
                        }

                        //task.Control(TaskAction.Verify);
                        DAQChannelInfo chanInfo = new DAQChannelInfo
                        {
                            DeviceName = deviceName,
                            ChannelName = channel.Substring(channel.LastIndexOf("/") + 1),
                            PhysicalChannel = channel,
                            SupportedCouplings = supportedCouplings
                        };

                        try { chanInfo.Coupling = aiChannel.Coupling.ToString(); } catch { }
                        try { chanInfo.SupportedCouplings = channelInfo.SupportedCouplings; } catch { } // Add(aiChannel.Coupling.ToString()); } catch { }
                        try { chanInfo.TerminalConfig = aiChannel.TerminalConfiguration.ToString(); } catch { }
                        try { chanInfo.MeasurementType = aiChannel.MeasurementType.ToString(); } catch { }
                        try { chanInfo.MinVoltage = aiChannel.Minimum; } catch { }
                        try { chanInfo.MaxVoltage = aiChannel.Maximum; } catch { }
                        

                        // Future-proof fields (optional, based on your device capabilities)
                        try { chanInfo.Units = aiChannel.CustomScaleName; } catch { }
                        //try { chanInfo.SensorType = aiChannel.SensorType.ToString(); } catch { }
                        try { chanInfo.ExcitationSource = aiChannel.ExcitationSource.ToString(); } catch { }

                        devInfo.Channels.Add(chanInfo);
                        devInfo.Channels.Add(channelInfo);
                    }
                }
                catch (DaqException ex)
                {
                    Console.WriteLine($"Error reading channel {channel}: {ex.Message}");
                }
            }

            devices.Add(devInfo);
        }

        Console.WriteLine($"Returning {devices.Count} devices");
        return devices;
    }
}
