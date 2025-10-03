

using MsSqlClrExt;

namespace Testing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        static void Main()
        {
            var res = ClrTranslit.ClrRefineText("KCM-WPM063-09B ELEVATION (KING DINOSAUR REMIX)\n");
        }
    }
}
