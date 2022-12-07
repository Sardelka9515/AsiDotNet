using System.Drawing;
using System.Runtime.InteropServices;

namespace AsiDotNet;

internal class Main
{
    public static void ScriptMain()
    {
        Logger.Info("AsiDotNet started");

        // Note: SHVDN creates a separate fiber to prevent SHV from corrupting the CLR stack here.
        // I'm not sure what's the case of NativeAOT, but so far so good :) 
        while (true)
        {
            try
            {
                OnTick();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.ToString());
            }

            ScriptWait(0);
        }
    }

    private static void OnTick()
    {
        DrawText(300, 200, "This text is drawn by a C# asi !", Color.CornflowerBlue);
        CleanupStrings();
    }

    [UnmanagedCallersOnly(EntryPoint = "DllMain")]
    public static bool DllMain(HMODULE hModule, int reason, LPVOID lpReserved)
    {
        switch (reason)
        {
            case DLL_PROCESS_ATTACH:
                ScriptRegister(hModule, ScriptMain);
                break;

            case DLL_PROCESS_DETACH:
                // Doesn't seem to work?
                ScriptUnregister(hModule);
                break;
        }

        return true;
    }

    private static unsafe void DrawText(float x, float y, string text, Color color, float scaleX = 0.5f,
        float scaleY = 0.5f)
    {
        Invoke(0x66E0276CC5F6B9DA /*SET_TEXT_FONT*/, 0); // Chalet London :>
        Invoke(0x07C837F9A01C34C9 /*SET_TEXT_SCALE*/, scaleX, scaleY);
        Invoke(0xBE6B23FFA53FB442 /*SET_TEXT_COLOUR*/, color.R, color.G, color.B, color.A);
        Invoke(0x25FBB336DF1804CB /*BEGIN_TEXT_COMMAND_DISPLAY_TEXT*/, CellEmailBcon);
        PushLongString(text);
        Invoke(0xCD015E5BB0D96A57 /*END_TEXT_COMMAND_DISPLAY_TEXT*/, x / BASE_WIDTH, y / BASE_HEIGHT);
    }
}