using UnityEngine;
using System;

public class FunctionTimer
{

    public static FunctionTimer Create(Action action, float timer)
    {
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));

        FunctionTimer functiontimer = new FunctionTimer(action, timer, gameObject);

        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functiontimer.Update;

        return functiontimer;
    }

    public class MonoBehaviourHook : MonoBehaviour 
    {
        public Action onUpdate;

        private void Update()
        {
            if(onUpdate != null) 
                onUpdate();
        }
    }

    private Action action;
    private float timer;
    private bool isDestroyed;
    private GameObject gameObject;

    private FunctionTimer(Action action, float timer, GameObject gameObject)
    {
        this.action = action;
        this.timer = timer;
        this.gameObject = gameObject;
        isDestroyed = false;
    }

    public void Update()
    {
        if(!isDestroyed){
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                action();
                DestroyTimer();
            }
        }
    }

    private void DestroyTimer()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
    }
}
