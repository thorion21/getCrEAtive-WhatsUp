using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageContext
{
    IStrategy strategy;

    public IStrategy getCurrentStrategy()
    {
        return strategy;
    }

    public void setStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void executeStrategy()
    {
        strategy.execute();
    }
}
