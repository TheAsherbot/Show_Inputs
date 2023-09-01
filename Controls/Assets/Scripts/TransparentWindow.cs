using System;
using System.Runtime.InteropServices;

using TheAshBot.TwoDimentional;

using UnityEngine;

public class TransparentWindow : MonoBehaviour
{


    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cxTopHeight;
        public int cxBottomHeight;
    }

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    private IntPtr hWnd;

    private void Start()
    {
        hWnd = GetActiveWindow();
        MARGINS margins = new MARGINS { cxLeftWidth = -1 };
        DwmExtendFrameIntoClientArea(hWnd, ref margins);
        
        Application.runInBackground = true;
    }

}
