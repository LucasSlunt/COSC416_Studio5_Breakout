using DG.Tweening;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{


    public static ScreenShake Instance;

    private void Awake() => Instance = this;

    
    private void OnShake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    public static void Shake(float duration, float strength) => Instance.OnShake(duration, strength);
}
