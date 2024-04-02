import os
import threading
from tkinter import messagebox

# 表示是否关机
flag = True


def task_to_run():
    # 如果flag为True（即不取消关机），那么执行关机
    if flag:
        os.system("shutdown /s /t 1")


if __name__ == '__main__':
    # 创建一个threading.Timer，设置10秒间隔，所执行的任务会在10秒后执行
    timer = threading.Timer(10.0, task_to_run)
    # 启动timer
    timer.start()

    # 打开一个TK的消息框，用变量res接收返回值（bool类型，因为用是askyesno函数）
    res = messagebox.askyesno("关机", "将在10秒后自动关机，是否取消关机？")
    # flag设置为res的相反值，即点“是”时，res为True，那么flag为False，从而取消关机
    flag = not res
