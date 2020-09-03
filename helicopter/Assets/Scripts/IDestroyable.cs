namespace Helicopter
{
  public interface IDestroyable
  {
    bool IsDestroyed { get; }
    bool Destroy();
  }
}
