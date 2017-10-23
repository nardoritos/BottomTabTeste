using Android.Content;
using Android.Net;

namespace BottomTabTeste
{
    class NetworkConnection
    {
        public static bool IsNetworkConnected(Context context)
        {
            ConnectivityManager conMgr = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            NetworkInfo activeNetwork = conMgr.ActiveNetworkInfo;
            return activeNetwork != null && activeNetwork.GetState() == NetworkInfo.State.Connected;
        }
    }
}