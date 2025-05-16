import nidaqmx
import json
from nidaqmx.system import System
from nidaqmx.constants import Coupling

def list_ni_devices():
    system = System.local()
    config = {"channels": []}

    for device in system.devices:
        for chan in device.ai_physical_chans:
            try:
                # Use a task to access coupling info
                with nidaqmx.Task() as task:
                    task.ai_channels.add_ai_voltage_chan(chan.name)
                    ai_chan = task.ai_channels[0]

                    # Attempt to get supported coupling types
                    try:
                        supported_coupling = list(ai_chan.coupling_types)
                        coupling_list = [c.name for c in supported_coupling]
                    except Exception:
                        # If not supported, fall back to default list
                        coupling_list = ["AC", "DC"]

                    default_coupling_index = 0

                # Supported voltage ranges
                supported_ranges = list(chan.supported_voltage_ranges)
                dyn_ranges = []
                for r in supported_ranges:
                    dyn_ranges.append({
                        "str": f"±{abs(r)}V",
                        "Max": abs(r),
                        "Min": -abs(r),
                        "Units": "V"
                    })

                default_range_index = 0 if dyn_ranges else -1

                # Terminal configurations
                term_configs = [tc.name for tc in chan.terminal_configurations]
                default_term_index = 0 if term_configs else -1

                # Sample rate
                min_rate = chan.ai_min_sample_rate
                max_rate = chan.ai_max_single_chan_rate

                channel_info = {
                    "msid": chan.name,
                    "description": chan.description,
                    "units": "V",
                    "dynRangeList": dyn_ranges,
                    "dynRangeIndex": default_range_index,
                    "coupling": coupling_list,
                    "couplingIndex": default_coupling_index,
                    "measType": ["Voltage"],  # AI Voltage channels = Voltage
                    "measTypeIndex": 0,
                    "terminalConfigs": term_configs,
                    "terminalConfigIndex": default_term_index,
                    "sampleRateMin": min_rate,
                    "sampleRateMax": max_rate,
                    "gain": 1.0,
                    "sensitivity": 1.0,
                    "dcOffset": 0.0
                }

                config["channels"].append(channel_info)

            except Exception as e:
                print(f"Error reading channel {chan.name}: {e}")

    with open("default_config.json", "w") as f:
        json.dump(config, f, indent=4)

if __name__ == "__main__":
    list_ni_devices()



# import nidaqmx
# import json
# from nidaqmx.system import System

# def list_ni_devices():
#     system = System.local()
#     devices_info = []

#     for device in system.devices:
#         info = {
#             'name': device.name,
#             'product_type': device.product_type,
#             'serial_number': device.serial_number,
#             'ai_physical_chans': [chan.name for chan in device.ai_physical_chans],
#             'ao_physical_chans': [chan.name for chan in device.ao_physical_chans],
#             'di_lines': [line.name for line in device.di_lines],
#             'do_lines': [line.name for line in device.do_lines]
#         }
#         devices_info.append(info)

#     with open("default_config.json", "w") as f:
#         json.dump(devices_info, f, indent=4)

# if __name__ == "__main__":
#     list_ni_devices()
