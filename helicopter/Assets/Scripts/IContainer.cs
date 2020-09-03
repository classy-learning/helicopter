namespace Helicopter
{
  public interface IContainer
  {
    float Capacity { get; }
    float Value { get; }
    bool Drain(float amount);
    bool Fill(float amount);
  }
}
