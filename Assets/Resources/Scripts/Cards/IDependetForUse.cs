using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDependetForUse
{
    public bool IsAlternative();

    public void UseAlternative();

    public string GetAlternativeDescKey();
}
