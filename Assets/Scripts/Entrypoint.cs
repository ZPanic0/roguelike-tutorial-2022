using RoguelikeTutorial;
using UnityEngine;

public class Entrypoint : MonoBehaviour
{
    void Awake()
    {
        RB.Initialize(new Game());
    }
}
