namespace KD.AutoBot.Connection.Windows.Native
{
    /// <summary>
    /// Holds data about native Win32 API constants.
    /// 
    /// For list of all Windows messages see:
    /// https://msdn.microsoft.com/pl-pl/library/windows/desktop/ms644927(v=vs.85).aspx
    /// </summary>
    public static class NativeConstants
    {
        public const uint WM_GETTEXTLENGTH = 0x000E;
        public const uint WM_GETTEXT = 0x000D;
        public const int BN_CLICKED = 245;
    }
}