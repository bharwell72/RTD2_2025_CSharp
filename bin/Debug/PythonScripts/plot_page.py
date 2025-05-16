import socket
import json
import threading
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import sys
import logging

# --- Settings ---
PORT = 49152
NUM_CHANNELS = 4
BUFFER_SIZE = 100  # max points to show
plot_config = {}

# --- Data and Control ---
xdata = [[] for _ in range(NUM_CHANNELS)]
ydata = [[] for _ in range(NUM_CHANNELS)]
is_running = False
data_lock = threading.Lock()

logging.basicConfig(
    filename='plot_page.log',
    level=logging.DEBUG,
    format='%(asctime)s %(levelname)s: %(message)s'
)

def log_exception(e):
    logging.error(f"Exception: {e}", exc_info=True)

def recv_all(sock, n):
    """Helper to receive n bytes or return None if EOF."""
    data = b''
    while len(data) < n:
        chunk = sock.recv(n - len(data))
        if not chunk:
            return None
        data += chunk
    return data

def read_framed_json(conn):
    """Reads a length-prefixed JSON message."""
    length_bytes = recv_all(conn, 4)
    if not length_bytes:
        return None
    length = int.from_bytes(length_bytes, 'little')
    json_bytes = recv_all(conn, length)
    if not json_bytes:
        return None
    return json.loads(json_bytes.decode())

def update_plot(frame, lines_axes):
    if not is_running:
        return [line for line, _ in lines_axes]

    with data_lock:
        for i, (line, ax) in enumerate(lines_axes):
            if ydata[i]:
                x_vals = list(range(len(ydata[i])))
                line.set_data(x_vals, ydata[i])
                y_min = min(ydata[i])
                y_max = max(ydata[i])
                ax.set_ylim(y_min - 1, y_max + 1)
                ax.set_xlim(0, BUFFER_SIZE)

    return [line for line, _ in lines_axes]

def socket_server():
    global is_running, plot_config, NUM_CHANNELS

    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    try:
        s.bind(('localhost', PORT))
    except OSError as e:
        print(f"[PYTHON ERROR] Failed to bind: {e}")
        sys.exit(1)

    s.listen(1)
    print(f"[PYTHON] Listening on port {PORT}...")

    while True:
        print(f"[PYTHON] Waiting for new connection on port {PORT}...")
        conn, addr = s.accept()
        print(f"[PYTHON] Connection accepted from {addr}")

        try:
            with conn:
                while True:
                    try:
                        packet = read_framed_json(conn)
                        if packet is None:
                            print("[PYTHON] Connection closed by client.")
                            break

                        if packet.get("command") == "config":
                            plot_config = packet["settings"]
                            NUM_CHANNELS = plot_config.get("num_channels", 4)
                            print(f"[PYTHON] Config received: {plot_config}")
                        elif packet.get("command") == "start":
                            print("[PYTHON] Received START command.")
                            is_running = True
                        elif packet.get("command") == "stop":
                            print("[PYTHON] Received STOP command.")
                            is_running = False
                        elif "samples" in packet:
                            with data_lock:
                                for i, val in enumerate(packet["samples"]):
                                    ydata[i].append(val)
                                    if len(ydata[i]) > BUFFER_SIZE:
                                        ydata[i].pop(0)
                    except json.JSONDecodeError as e:
                        print(f"[PYTHON ERROR] JSON decode error: {e}")
                        continue
                    except Exception as e:
                        log_exception(e)
                        break

        except Exception as e:
            log_exception(e)
            continue

# def socket_server():
#     global is_running, plot_config, NUM_CHANNELS

#     s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
#     s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
#     try:
#         s.bind(('localhost', PORT))
#     except OSError as e:
#         print(f"[PYTHON ERROR] Failed to bind: {e}")
#         sys.exit(1)

#     s.listen(1)
#     print(f"[PYTHON] Listening on port {PORT}...")

#     while True:
#         print(f"[PYTHON] Waiting for new connection on port {PORT}...")
#         conn, addr = s.accept()
#         print(f"[PYTHON] Connection accepted from {addr}")

#         try:
#             with conn:
#                 while True:
#                     try:
#                         data = conn.recv(4096)
#                         if not data:
#                             print("[PYTHON] Connection closed by client.")
#                             break

#                         packet = json.loads(data.decode())
#                         if packet.get("command") == "config":
#                             plot_config = packet["settings"]
#                             NUM_CHANNELS = plot_config.get("num_channels", 4)
#                             print(f"[PYTHON] Config received: {plot_config}")
#                         elif packet.get("command") == "start":
#                             print("[PYTHON] Received START command.")
#                             is_running = True
#                         elif packet.get("command") == "stop":
#                             print("[PYTHON] Received STOP command.")
#                             is_running = False
#                         elif "samples" in packet:
#                             with data_lock:
#                                 for i, val in enumerate(packet["samples"]):
#                                     ydata[i].append(val)
#                                     if len(ydata[i]) > BUFFER_SIZE:
#                                         ydata[i].pop(0)
#                     except json.JSONDecodeError as e:
#                         print(f"[PYTHON ERROR] JSON decode error: {e}")
#                         continue
#                     except Exception as e:
#                         log_exception(e)
#                         break

#         except Exception as e:
#             log_exception(e)
#             continue

def start_socket_thread():
    threading.Thread(target=socket_server, daemon=True).start()

def plot_init():
    fig, axs = plt.subplots(nrows=NUM_CHANNELS, ncols=1, figsize=(10, 6), sharex=True)
    fig.suptitle("Live Data")
    lines_axes = []

    if NUM_CHANNELS == 1:
        axs = [axs]

    for ax in axs:
        line, = ax.plot([], [])
        ax.set_xlim(0, BUFFER_SIZE)
        ax.set_ylim(-1, 1)
        lines_axes.append((line, ax))

    ani = FuncAnimation(fig, update_plot, fargs=(lines_axes,), interval=50, cache_frame_data=False)
    plt.tight_layout()
    plt.show()

if __name__ == "__main__":
    start_socket_thread()
    plot_init()