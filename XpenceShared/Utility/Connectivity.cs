using Plugin.Connectivity;

namespace XpenceShared.Utility
{
    //TODO extract interface
    public static class Connectivity
    {
        /// <summary>
        /// Returns status for the connection to Internet
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {
            if (!CrossConnectivity.IsSupported)
                return true;

            //Do this only if you need to and aren't listening to any other events as they will not fire.
            using (var connectivity = CrossConnectivity.Current)
            {
                return connectivity.IsConnected;
            }

        }
    }
}