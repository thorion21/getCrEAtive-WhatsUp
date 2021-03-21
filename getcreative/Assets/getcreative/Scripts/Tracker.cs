using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Calmness,
    Frenzy,
    Reanimate,
    Demolish
}

public class Tracker : MonoBehaviour
{
    private StageContext context;
    public GameObject calmnessObj, frenzyObj, reanimateObj, demolishObj;
    private CalmnessStrategy calmnessStrategy;
    private FrenzyStrategy frenzyStrategy;
    private ReanimateStrategy reanimateStrategy;
    private DemolishStrategy demolishStrategy;

    private State currentState;
    private PirateController player;


    private void Awake()
    {
        context = new StageContext();

        calmnessStrategy = calmnessObj.GetComponent<CalmnessStrategy>();
        frenzyStrategy = frenzyObj.GetComponent<FrenzyStrategy>();
        reanimateStrategy = reanimateObj.GetComponent<ReanimateStrategy>();
        demolishStrategy = demolishObj.GetComponent<DemolishStrategy>();


        player = GameObject.Find("Player2").GetComponent<PirateController>();

        currentState = State.Calmness;
        context.setStrategy(calmnessStrategy);
        context.executeStrategy();
    }

    public State getCurrentState()
    {
        return currentState;
    }

    public void announceEvent(State state)
    {
        if (currentState == state)
            return;

        player.InflictDamage(20);

        switch (state)
        {
            case State.Calmness:
                context.setStrategy(calmnessStrategy);
                break;
            case State.Frenzy:
                context.setStrategy(frenzyStrategy);
                break;
            case State.Reanimate:
                context.setStrategy(reanimateStrategy);
                break;
            default:
                context.setStrategy(demolishStrategy);
                break;
        }

        currentState = state;
        context.executeStrategy();
    }

    void Update()
    {
        
    }
}
