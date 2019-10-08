using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TopScoresLoader : MonoBehaviour
{
    List<TextMeshProUGUI> listNamesText = new List<TextMeshProUGUI>();
    List<TextMeshProUGUI> listScoresText = new List<TextMeshProUGUI>();
    List<PlayerScores> listScores = new List<PlayerScores>();

    // Start is called before the first frame update
    void Start()
    {
        //***************** setup arrays that hold the TextMeshPro[s] *****************
        GameObject namesParent = GameObject.Find("NamesParent");
        GameObject scoresParent = GameObject.Find("ScoresParent");

        foreach(Transform child in namesParent.transform){
            listNamesText.Add(child.GetComponent<TextMeshProUGUI>());
        }

        foreach(Transform child in scoresParent.transform){
            listScoresText.Add(child.GetComponent<TextMeshProUGUI>());
        }
        //***************************************************************************

        //read the file
        string[] lines = File.ReadAllLines(@"C:/gamescores/gamescores.txt");

        //store the lines from the file into the array of PlayerScores
        for(int i = 0; i < listNamesText.Count && i < lines.Length; i++)
        {
            PlayerScores ps = new PlayerScores();
            ps.AssignValues(lines[i]);
            listScores.Add(ps);
        }

        //sort the array in descending order
        listScores.Sort();
        listScores.Reverse();

        //finally loop through everything to assign the values to the TextMeshPro's
        for(int i = 0; i < listNamesText.Count && i < listScoresText.Count && i < listScores.Count; i++)
        {
            listNamesText[i].SetText(listScores[i].Name);
            listScoresText[i].SetText(listScores[i].ToString());
        }
    }
}
