using UnityEngine;

public class Entry : MonoBehaviour
{
    void Awake()
    {
        RB.Initialize(new Game());
    }
}
