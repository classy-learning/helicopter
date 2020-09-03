namespace Helicopter
{
  using UnityEngine;

  // TODO: store fuel for consumption
  // TODO: produce fuel
  // TODO: leak fuel when damaged
  // TODO: explode when destroyed

  public class FuelTank : MonoBehaviour, IContainer, IProducer
  {
    public float Capacity = 100;

    public float Value { get; private set; }

    private void OnEnable()
    {
      Value = Capacity;
    }

    float IContainer.Capacity => Capacity;

    bool IContainer.Drain(float amount)
    {
      Value -= Mathf.Abs(amount);
      if (Value >= 0) return true;
      Value = 0;
      return false;
    }

    bool IContainer.Fill(float amount)
    {
      Value += Mathf.Abs(amount);
      if (Value <= Capacity) return true;
      Value = Capacity;
      return false;
    }

    bool IProducer.Produce(float amount) => (this as IContainer).Drain(amount);
  }
}
