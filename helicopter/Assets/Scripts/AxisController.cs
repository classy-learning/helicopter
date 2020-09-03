namespace Helicopter
{
  using UnityEngine;
  using UnityEngine.Events;

  public class AxisController : MonoBehaviour
  {
    [Tooltip("The name of the input axis.")]
    public string AxisName;

    [Tooltip("Called whenever the value of the input axis changes.")]
    public FloatEvent OnChange;

    private void FixedUpdate()
    {
      OnChange?.Invoke(Input.GetAxis(AxisName));
    }
  }
}
