using System.Collections;

public abstract class State
{
    public virtual IEnumerator Start()
    {
        yield break;
    }
    
    public virtual IEnumerator Attack()
    {
        yield break;
    }
    
    public virtual IEnumerator Heal()
    {
        yield break;
    }
}
