import nidaqmx
from nidaqmx.system import System
import json

def get_device_info():
    system = System.local()
    devices_info = []

    for device in system.devices:
        dev_info = {
            "name": device.name,
            "product_type": device.product_type,
            "serial_number": device.serial_num,
            "ai_samp_modes": str(device.ai_samp_modes),
            "ai_max_single_chan_rate": device.ai_max_single_chan_rate,
            "ai_max_multi_chan_rate": device.ai_max_multi_chan_rate,
            "ai_min_rate": device.ai_min_rate,
            "ai_coupling": str(device.ai_couplings),
            "ai_voltage_ranges": device.ai_voltage_rngs,
            "ai_meas_types": [str(mt) for mt in device.ai_meas_types],
            "anlg_trig_supported": device.anlg_trig_supported,
            "ai_channels": []
        }

        for chan in device.ai_physical_chans:
            chan_info = {
                "name": chan.name,
                # "ai_max": chan.ai_max,
                # "ai_min": chan.ai_min,
                "ai_term_cfgs": [str(cfg) for cfg in chan.ai_term_cfgs],
                "ai_meas_type": str(chan.ai_meas_types)
            }

            try:
                with nidaqmx.Task() as task:
                    task.ai_channels.add_ai_voltage_chan(chan.name)
                    ai_chan = task.ai_channels[0]
                    chan_info["supported_ai_coupling"] = [str(c) for c in ai_chan.ai_coupling_vals]
                    chan_info["ai_coupling"] = str(ai_chan.ai_coupling)
                    # chan_info["ai_microphone_sensitivity"] = ai_chan.ai_microphone_sensitivity
                    # chan_info["ai_lowpass_cutoff_freq"] = ai_chan.ai_lowpass_cutoff_freq
                    chan_info["ai_gain"] = ai_chan.ai_gain
                    chan_info["ai_max"] = ai_chan.ai_max
                    chan_info["ai_min"] = ai_chan.ai_min
            except Exception as e:
                chan_info["note"] = f"{type(e).__name__}: {e}"

            dev_info["ai_channels"].append(chan_info)

        devices_info.append(dev_info)

    print(json.dumps(devices_info, indent=2))

if __name__ == "__main__":
    get_device_info()
