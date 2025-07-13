

using System;

public abstract class TextLevel : Text3DAbstract
{
    private void FixedUpdate()
    {
        this.UpdatingLevel();
    }

    protected abstract void UpdatingLevel();

}