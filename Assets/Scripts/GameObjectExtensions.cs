using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static bool HasTag(this GameObject gameObject, Tag t)
    {
        if (gameObject.TryGetComponent<Tags>(out var tags))
        {
            return tags.HasTag(t);
        }
        return false;
    }

    public static float MaxThrust(Tag t)
    {
        return 1.5f;

    }
}
