using UnityEngine;

public class ShakeManager : SingletonMonoBehavior<ShakeManager>
{
    [SerializeField] private float strengthBase = 0.5f;
    [SerializeField] private float strengthMultiplier = 0.5f;
    [SerializeField] private float durationBase = 0.5f;
    [SerializeField] private float durationMultiplier = 0.5f;
    [SerializeField] private float maxTimeBetweenBreaks = 1.5f;

    private float screenShakeStrength = ShakeManager.Instance.strengthBase;
    private float screenShakeDuration = ShakeManager.Instance.durationBase;
    private float lastBlockBreak;


    // checks to see if the time between the last block broken and now is within the combo timer, and if so, makes the screen shake stronger. If it isn't, it's a normal
    // screen shake
    public static void addShake()
    {
        if (Time.time - ShakeManager.Instance.lastBlockBreak < ShakeManager.Instance.maxTimeBetweenBreaks)
        {
            ShakeManager.Instance.screenShakeDuration += ShakeManager.Instance.durationMultiplier;
            ShakeManager.Instance.screenShakeStrength += ShakeManager.Instance.strengthMultiplier;
        }
        else
        {
            ShakeManager.Instance.screenShakeDuration = ShakeManager.Instance.durationBase;
            ShakeManager.Instance.screenShakeStrength = ShakeManager.Instance.strengthBase;
        }
        InstantiateShake(ShakeManager.Instance.screenShakeDuration, ShakeManager.Instance.screenShakeStrength);
        ShakeManager.Instance.lastBlockBreak = Time.time;
    }

    // method that actually calls the camera to be shaken
    public static void InstantiateShake(float duration, float strength)
    {
        ScreenShake.Shake(duration, strength);
    }
}