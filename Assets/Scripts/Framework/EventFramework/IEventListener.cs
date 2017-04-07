using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener
{
    void Event(params object[] message);
}
