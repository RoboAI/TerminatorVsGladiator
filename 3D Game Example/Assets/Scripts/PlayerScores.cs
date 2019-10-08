using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : IComparable
{
    private int[] scores;
    public string Name { get; set; }

    public int[] Scores
    {
        get
        {
            return scores;
        }
        set
        {
            scores = value;
            Array.Sort(scores);
            Array.Reverse(scores);
        }
    }

    public override string ToString(){
        string scoreFullString = "";
        for(int j=0; j < Scores.Length; j++){
            scoreFullString += String.Format("{0,-8}", Scores[j]);
        }
        return scoreFullString;
    }

    public PlayerScores()
    {
        Init();
    }

    private void Init()
    {
        Name = "";
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (scores == null) return 0;

        if (scores.Length == 0) return 0;

        PlayerScores ca = obj as PlayerScores;

        if (ca == null) return 1;

        if (ca.scores == null) return 1;

        if (ca.scores.Length == 0) return 1;

        return this.scores[0].CompareTo(ca.scores[0]);
    }

    public void AssignValues(string singlePlayerDetails)
    {
        if(singlePlayerDetails == null)
            return;

        string[] details = singlePlayerDetails.Split(',');

        if(details == null || details.Length == 0)
            return;

        //first element should contain the Name, so assign this
        Name = details[0];

        List<string> playerDetails = new List<string>(details);
        List<int> playerScores = new List<int>();

        playerDetails.RemoveAt(0);//remove 'Name'

        //convert the strings to ints, then add to playerScores
        playerDetails.ForEach(e => {
            int outParse = 0;
            int.TryParse(e, out outParse);
            playerScores.Add(outParse);
        });

        //we want minimum of 3, so add if necessary
        if(playerScores.Count < 3){
            for(int i = 0; i < 3 - playerScores.Count; i++){
                playerScores.Add(0);
            }
        }

        //store the array in the class
        Scores = playerScores.ToArray();
    }
}
