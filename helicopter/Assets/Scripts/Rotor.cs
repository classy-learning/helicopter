namespace Helicopter
{
  using UnityEngine;

  public class Rotor : MonoBehaviour
  {
    [Tooltip("The amount of lift generated per radian per second.")]
    public float Lift = 1;

    public Rigidbody Driveshaft;

    private void FixedUpdate() => Driveshaft.AddForce(
      transform.up *
      Driveshaft.angularVelocity.magnitude *
      Lift *
      Time.fixedDeltaTime
    );
  }
}
