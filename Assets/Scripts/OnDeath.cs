using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    public GameController GCscript;

    private void Start()
    {
        GCscript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    private void OnDestroy()
    {
        Score.scoreValue += 5;
        GCscript.EnemyDeath();
    }
}
