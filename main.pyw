import os
import threading
import time
from tkinter import messagebox

flag = True


def task_to_run():
    if flag:
        os.system("shutdown /s /t 1")


if __name__ == '__main__':
    timer = threading.Timer(10.0, task_to_run)
    timer.start()

    res = messagebox.askyesno("关机", "将在10秒后自动关机，是否取消关机？")
    flag = not res
