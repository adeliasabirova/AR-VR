public class KeyFirstDoor : ITakeKey
{
    public bool IsKeyTaken { get; private set; }

    public KeyFirstDoor()
    {
        IsKeyTaken = false;
    }

    public void TakeKey()
    {
        IsKeyTaken = true;
    }
}
