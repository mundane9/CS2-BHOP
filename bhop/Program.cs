// CS2 Bhop - Mouse Wheel | bind "mwheeldown" "+jump" | Hold SPACE
// Mimics real mouse wheel: spams scroll every ~15ms while SPACE held.
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
class Program
{
    [DllImport("user32.dll")]   static extern short GetAsyncKeyState(int vKey);
    [DllImport("user32.dll")]   static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]   static extern int GetWindowThreadProcessId(IntPtr hWnd, out int pid);
    [DllImport("user32.dll")]   static extern uint SendInput(uint n, INPUT[] i, int size);
    [DllImport("winmm.dll")]    static extern uint timeBeginPeriod(uint ms);
    [DllImport("winmm.dll")]    static extern uint timeEndPeriod(uint ms);
    [StructLayout(LayoutKind.Sequential)] struct INPUT { public uint type; public MOUSEINPUT mi; }
    [StructLayout(LayoutKind.Sequential)] struct MOUSEINPUT { public int dx, dy, mouseData, dwFlags, time; public IntPtr dwExtraInfo; }
    static readonly INPUT[] scroll = { new INPUT { type = 0, mi = new MOUSEINPUT { mouseData = -120, dwFlags = 0x0800 } } };
    static void Main()
    {
        Console.WriteLine("CS2 Bhop | bind \"mwheeldown\" \"+jump\" | Hold SPACE\n");
        timeBeginPeriod(1);
        Console.CancelKeyPress += (s, e) => { timeEndPeriod(1); };
        // Wait for CS2
        Process game;
        while (true) { var p = Process.GetProcessesByName("cs2"); if (p.Length > 0) { game = p[0]; break; } Thread.Sleep(2000); }
        int sz = Marshal.SizeOf(typeof(INPUT));
        Console.WriteLine("Running...");
        while (!game.HasExited)
        {
            Thread.Sleep(15); // ~15ms between scrolls = rough mouse wheel speed
            if (!Focused(game.Id)) continue;
            if ((GetAsyncKeyState(0x20) & 0x8000) == 0) continue;
            // Scrollwheel
            SendInput(1, scroll, sz);
        }
        timeEndPeriod(1);
    }
    static bool Focused(int pid)
    { var w = GetForegroundWindow(); if (w == IntPtr.Zero) return false; GetWindowThreadProcessId(w, out int p); return p == pid; }
}
