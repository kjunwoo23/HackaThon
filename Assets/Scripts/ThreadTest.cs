using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class ThreadTest : MonoBehaviour
{
    Thread t;
    object lockObject = new Object();

    public void Start()
    {
        t = new Thread(new ThreadStart(Interpret));
    }

    public void PressButton()
    {
        t = new Thread(new ThreadStart(Interpret));
        t.Start();
        t.Join();
    }

    public void Interpret()
    {
        lock(lockObject)
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log(i);
            }
        }
    }
}
