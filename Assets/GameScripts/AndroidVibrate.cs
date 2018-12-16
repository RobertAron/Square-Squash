using UnityEngine;
using System.Collections;


public class AndroidVibrate
{
  private static readonly AndroidJavaObject curActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer") // Get the Unity Player.
                                                      .GetStatic<AndroidJavaObject>("currentActivity");// Get the Current Activity from the Unity Player.    
  private static readonly AndroidJavaObject Vibrator = curActivity == null? null : curActivity
                                                                              .Call<AndroidJavaObject>("getSystemService", "vibrator");// Then get the Vibration Service from the Current Activity.

  static void KyVibrator()
  {
    // Trick Unity into giving the App vibration permission when it builds.
    // This check will always be false, but the compiler doesn't know that.
    if (Application.isEditor) Handheld.Vibrate();
  }

  public static void Vibrate(long milliseconds)
  {
    if(Vibrator==null) return;
    Vibrator.Call("vibrate", milliseconds);
  }

  public static void Vibrate(long[] pattern, int repeat)
  {
    if(Vibrator==null) return;
    Vibrator.Call("vibrate", pattern, repeat);
  }
}