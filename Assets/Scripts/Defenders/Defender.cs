using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

    public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amout)
    {
        FindObjectOfType<StarDisplay>().AddStars(amout);
    }
}
