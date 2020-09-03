namespace Helicopter
{
  using System.Collections.Generic;
  using UnityEngine;

  public class Motor : MonoBehaviour, IConsumer
  {
    [Tooltip("How hard to twist the Driveshaft.")]
    public float Torque = 1;

    public Engine Engine;
    public Rigidbody Driveshaft;
    public Throttle Throttle;

    private void FixedUpdate()
    {
      float amount = Throttle.Value * Time.fixedDeltaTime;

      if ((this as IConsumer).Consume(amount))
      {
        Vector3 torque = transform.up * amount * Torque;
        Driveshaft.AddTorque(torque);
      }
    }

    bool IConsumer.Consume(float amount) => (Engine as IProducer).Produce(amount);

    IEnumerable<IProducer> IConsumer.Producers => new List<IProducer>() {Engine};
  }
}
