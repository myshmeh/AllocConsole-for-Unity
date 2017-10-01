using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;
using System.Reflection;


namespace Assets.Scripts.Debugs
{
    public static class AllocConsoleHandler
    {
        [DllImport("Kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("msvcrt.dll")]
        public static extern int system(string cmd);

        public static void Open()
        {
            AllocConsole();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Application.logMessageReceivedThreaded += (condition, stackTrace, type) => Console.WriteLine(condition + " " + stackTrace);
        }

        //clear allocconsole
        public static void ClearAllocConsole()
        {
            system("CLS");
        }
    }
}

/*
        //clear Unity Console
        [MenuItem("Tools/Clear Console %#c")] // CMD + SHIFT + C
        public static void ClearConsole()
        {
            // This simply does "LogEntries.Clear()" the long way:
            var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
            var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            clearMethod.Invoke(null, null);
        }*/
