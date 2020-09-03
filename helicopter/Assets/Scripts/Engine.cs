namespace Helicopter
{
  using System.Collections.Generic;
  using System.Linq;
  using UnityEngine;

  // produce power by consuming fuel

  public class Engine : MonoBehaviour, IConsumer, IProducer
  {
    [Tooltip("Conversion rate from fuel to power.")]
    [Range(0,1)]
    public float Efficiency = 1;

    public List<FuelTank> FuelTanks;

    IEnumerable<IProducer> IConsumer.Producers => FuelTanks.Cast<IProducer>();

    bool IConsumer.Consume(float amount)
    {
      float totalProduct = 0;
      while (totalProduct < amount)
      {
        FuelTank fuelTank = FuelTanks.FirstOrDefault(t => t.Value > 0);
        if (fuelTank == null) return false;
        float product = Mathf.Min(amount, fuelTank.Value);
        (fuelTank as IProducer).Produce(product);
        totalProduct += product;
      }
      return true;
    }

    bool IProducer.Produce(float amount) => (this as IConsumer).Consume(amount / Efficiency);
  }
}
