using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTrigger : MonoBehaviour {

    public GameManager gameManager { get; set; }

	void OnTriggerEnter(Collider coll)
    {
        foreach(string tagPlayer in Tag.Players)
        {
            if (coll.tag == tagPlayer)
            {
                gameManager.FlagTaken(tagPlayer);
                Destroy(this.gameObject);
                break;
            }

        }
    }
}
