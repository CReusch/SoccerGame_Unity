using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    public GameTimeAndScore GameController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Goal"))
        {
            GameController.IncrementScore();
        }
    }
}
