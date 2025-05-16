# plot_page.py
import socket
import json
import threading
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
from collections import deque

# Settings
NUM_CHANNELS = 4
BUFFER_SIZE = 1000
PORT = 9999

# Data buffer
data_buffers = [deque(maxlen=BUFFER_SIZE) for _ in range(NUM_CHANNELS)]

def update_plot(frame, lines):
    for i, line in enumerate(lines):
        line.set_ydata(list(data_buffers[i]))
    return lines

def plot_init():
    fig, ax = plt.subplots()
    lines = [ax.plot([], [])[0] for _ in range(NUM_CHANNELS)]
    ax.set_ylim(-10, 10)  # Adjust based on signal range
    ax.set_xlim(0, BUFFER_SIZE)
    for line in lines:
        line.set_xdata(range(BUFFER_SIZE))
    ani = FuncAnimation(fig, update_plot, fargs=(lines,), interval=50)
    plt.show()

def start_plot_thread():
    thread = threading.Thread(target=plot_init)
    thread.daemon = True
    thread.start()

def start_socket_server():
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.bind(('localhost', PORT))
    s.listen(1)
    conn, _ = s.accept()
    with conn:
        while True:
            data = conn.recv(4096)
            if not data:
                break
            try:
                packet = json.loads(data.decode())
                for i, val in enumerate(packet["samples"]):
                    data_buffers[i].append(val)
            except Exception as e:
                print(f"Error decoding data: {e}")

if __name__ == "__main__":
    start_plot_thread()
    start_socket_server()
