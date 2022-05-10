using PelourinhoPOS.Debugging;

namespace PelourinhoPOS
{
    public class PelourinhoPOSConsts
    {
        public const string LocalizationSourceName = "PelourinhoPOS";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "54b1cab8c9c9417cb228c0d1ebbb3402";
    }
}
