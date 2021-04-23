public enum HitTypes
{
    Brick,
    Player,
    Wall,
    Other,
}
public interface IHitListener
{
    void OnHit(HitTypes type, int streak);
}