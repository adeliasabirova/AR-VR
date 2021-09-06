public class KeyBoss : ITakeKey
{
    private bool _bossKey1 = false;
    private bool _bossKey2 = false;
    public bool IsBossKeysTaken
    {
        get
        {
            if (_bossKey1 && _bossKey2)
                return true;
            else
                return false;
        }
    }
    public void TakeKey()
    {
        if (!_bossKey1 && _bossKey2)
            _bossKey1 = true;
        else
            _bossKey2 = true;
    }
}
