using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : IComparable
{
    public const int MAX_SCORES = 3;
    public const int MIN_SCORES = 3;

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
        }
    }

    public override string ToString(){
        string scoreFullString = "";

        //we only want to show a maximum (MAX_SCORES) number of scores
        int max_scores_count = (Scores.Length > MAX_SCORES) ? MAX_SCORES : Scores.Length;

        for(int j=0; j < max_scores_count; j++){
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

        //we want minimum of MIN_SCORES, so add if necessary
        if(playerScores.Count < MIN_SCORES){
            int min_scores_count = MIN_SCORES - playerScores.Count;
            for(int i = 0; i < min_scores_count; i++){
                playerScores.Add(0);
            }
        }

        //store the array in the class
        Scores = playerScores.ToArray();
        Array.Sort(Scores);
        Array.Reverse(Scores);

        //sort the array high to low
    }
}
