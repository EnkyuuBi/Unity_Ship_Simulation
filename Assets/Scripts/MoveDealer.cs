using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDealer : Dealer<EngineStat> 
{
    protected override EngineStat add_sum(EngineStat change)
    {
        return this.sum += change;
    }

    protected override EngineStat subtract_sum(EngineStat change)
    {
        return this.sum -= change;
    }
}
