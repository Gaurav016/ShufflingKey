using Plugin.ShufflingKeypad.Abstractions;
using System;

namespace Plugin.ShufflingKeypad
{
  /// <summary>
  /// Cross platform ShufflingKeypad implemenations
  /// </summary>
  public class CrossShufflingKeypad
  {
    static Lazy<IShufflingKeypad> Implementation = new Lazy<IShufflingKeypad>(() => CreateShufflingKeypad(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IShufflingKeypad Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IShufflingKeypad CreateShufflingKeypad()
    {
#if PORTABLE
        return null;
#else
        return new ShufflingKeypadImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
