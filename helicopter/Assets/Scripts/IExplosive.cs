namespace Helicopter
{
  public interface IExplosive
  {
    bool IsExploded { get; }
    bool Explode();
  }
}
