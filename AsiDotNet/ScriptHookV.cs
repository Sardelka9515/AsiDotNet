using System.Runtime.InteropServices;

namespace AsiDotNet;

public class ScriptHookV
{
    /// <summary>
    ///     Pause the script execution and yield back to ScriptHook for specified time
    /// </summary>
    /// <param name="ms">Time to wait in milliseconds</param>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?scriptWait@@YAXK@Z")]
    public static extern void ScriptWait(ulong ms);

    /// <summary>
    ///     Register a script procedure inside a module, the procedure should call <see cref="ScriptWait" /> 0 each time the
    ///     execution is finished to yield back to ScriptHookV
    /// </summary>
    /// <param name="hModule"></param>
    /// <param name="scriptProc"></param>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?scriptRegister@@YAXPEAUHINSTANCE__@@P6AXXZ@Z")]
    public static extern void ScriptRegister(IntPtr hModule, Action scriptProc);

    /// <summary>
    ///     Unregister a script procedure
    /// </summary>
    /// <param name="scriptProc"></param>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?scriptUnregister@@YAXP6AXXZ@Z")]
    public static extern void ScriptUnregister(Action scriptProc);

    /// <summary>
    ///     Unregister script procedures inside the specified module
    /// </summary>
    /// <param name="hModule"></param>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?scriptUnregister@@YAXPEAUHINSTANCE__@@@Z")]
    public static extern void ScriptUnregister(HINSTANCE hModule);

    /// <summary>
    ///     Initializes the stack for a new script function call.
    /// </summary>
    /// <param name="hash">The function hash to call.</param>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativeInit@@YAX_K@Z")]
    public static extern void NativeInit(ulong hash);

    /// <summary>
    ///     Pushes a function argument on the script function stack.
    /// </summary>
    /// <param name="val">The argument value.</param>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativePush64@@YAX_K@Z")]
    public static extern void NativePush64(ulong val);

    /// <summary>
    ///     Executes the script function call.
    /// </summary>
    /// <returns>A pointer to the return value of the call.</returns>
    [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?nativeCall@@YAPEA_KXZ")]
    public static extern unsafe ulong* NativeCall();

    #region Unused imports

    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?createTexture@@YAHPEBD@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?drawTexture@@YAXHHHHMMMMMMMMMMMM@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?getGameVersion@@YA?AW4eGameVersion@@XZ")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?getGlobalPtr@@YAPEA_KH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?getScriptHandleBaseAddress@@YAPEAEH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?keyboardHandlerRegister@@YAXP6AXKGEHHHH@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?keyboardHandlerUnregister@@YAXP6AXKGEHHHH@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?presentCallbackRegister@@YAXP6AXPEAX@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?presentCallbackUnregister@@YAXP6AXPEAX@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllObjects@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllPeds@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllPickups@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllVehicles@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?scriptRegisterAdditionalThread@@YAXPEAUHINSTANCE__@@P6AXXZ@Z")]

    #endregion
}