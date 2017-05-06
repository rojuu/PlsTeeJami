using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour
{
    public string fishName;
    public Sprite sprite;




    public override bool Equals(object other)
    {
        if (other.GetType() != typeof(Fish))
            return false;

        Fish otherFish = (Fish)other;
        return fishName.Equals(otherFish.fishName);
    }
}
