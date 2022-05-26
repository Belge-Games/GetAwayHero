using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameObject[] players;

    private void Start()
    {
        GameObject[] foundPlayers = GameObject.FindGameObjectsWithTag(Constants.Tags.PLAYER);
        if(foundPlayers == null) return;
        players = foundPlayers;
    }

    public static GameObject GetPlayer()
    {
        return players[0];
    }

    public static GameObject GetClosestPlayer(Vector3 position)
    {
        if(players.Length == 0) return null;
        if(players.Length == 1) return GetPlayer();

        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }
        return closest;
    }
}
