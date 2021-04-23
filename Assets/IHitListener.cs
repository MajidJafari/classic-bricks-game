public enum HitTypes
{
    Brick,
    Player,
    Wall,
}
public interface IHitListener
{
    void OnHit(HitTypes type, int streak);
}