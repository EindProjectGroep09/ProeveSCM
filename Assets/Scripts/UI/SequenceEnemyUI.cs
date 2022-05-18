using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceEnemyUI : MonoBehaviour
{
    public static SequenceEnemyUI instance;
    /*?
     Visible sequence
    Maybe visible for a little while?
    textwolkje waar het in staat
     */

    [SerializeField] private Text textCloud;
    
    public List<string> sequenceText = new List<string>();
    private string sequenceTextColor;
    private SequenceEnemyManager SEManager;
    //private List<string> strings = new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        SEManager = FindObjectOfType<SequenceEnemyManager>();
    }

    private void Update()
    {
        for (int i = 0; i < SEManager.enemySequence.Count; i++)
        {
            if (SEManager.enemySequence[i].ToString().Contains("0"))
            {
               sequenceText.Add( SEManager.enemySequence[i].ToString().Replace("0", "Red"));
            }
            else
            {
                sequenceText.Add(SEManager.enemySequence[i].ToString().Replace("1", "Blue"));
            }
        }
        if (sequenceText.Count == 3)
        {
            textCloud.text = sequenceText[0] + ", " + sequenceText[1] + ", " + sequenceText[2];
        }
    }

/*    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 150, 20), sequenceText[0] + ", " + sequenceText[1] + ", " + sequenceText[2]) ;
    }*/
}
