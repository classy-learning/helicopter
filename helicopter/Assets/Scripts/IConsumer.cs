namespace Helicopter
{
  using System.Collections.Generic;

  public interface IConsumer
  {
    IEnumerable<IProducer> Producers { get; }
    bool Consume(float amount);
  }
}
