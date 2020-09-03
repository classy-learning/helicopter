namespace Helicopter
{
  using UnityEngine;

  public class Throttle : MonoBehaviour
  {
    private float input;
    public float Value
    {
      get => input;
      set => input = Mathf.Clamp01(value);
    }
  }
}
