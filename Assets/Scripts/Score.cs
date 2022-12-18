using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private Dictionary<Player, long> playersValue = new Dictionary<Player, long>();

    public void ChangePlayerScore(Player player, long scoreValue) {
        playersValue[player] = scoreValue;
    }

    public void AddPlayer(Player player) {

        if (playersValue.ContainsKey(player))
            throw new System.Exception(player.name + ", This player is already on the list");

        playersValue.Add(player, 0);
    }

    public void AddPlayer(Player player,long value) {
        if (playersValue.ContainsKey(player))
            throw new System.Exception(player.name + ", This player is already on the list");

        playersValue.Add(player, value);

    }

    public Player GetPlayerWithMaxScore() {

        Player playerMax = null;
        long maxScore = 0;

        foreach (var pair in playersValue) { 
           if(pair.Value > maxScore) { 
                maxScore = pair.Value;
                playerMax = pair.Key;
            }
                
        }
        
        return playerMax;
    }
}
