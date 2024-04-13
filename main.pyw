import os
import threading
from tkinter import messagebox

def shutdown_now():
    os.system("shutdown -s -t 0")

if __name__ == '__main__':
    timer = threading.Timer(60.0, shutdown_now)
    timer.start()

    # 打开一个TK的消息框，用变量res接收返回值（bool类型，因为用是askyesno函数）
    res = messagebox.askyesno("关机", "1分钟后自动注销，是否关机？")

    if res:
        shutdown_now()  # 用户确认关机，立即执行关机操作
    else:
        timer.cancel()  # 用户取消关机，取消定时器任务
