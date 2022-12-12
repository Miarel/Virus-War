using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Tutorial;

public class TutorialDialogs : MonoBehaviour
{
    public GameObject tutorialCell;
    public GameObject tutorialNeutralCell;
    public GameObject tutorialEnemyCell;
    public GameObject back;
    private bool isFirstTip = true;
    private bool isSecondTip = false;
    private bool isThirdTip = false;
    private bool isFourthTip = false;
    private bool isFifthTip = false;
    public TextMeshProUGUI tutorialText;
    public GameObject arrow;
    public GameObject arrowLow;
    private bool nextTip = false;
    [TextArea(3,10)]
    [SerializeField] string[] textBlock1;
    [SerializeField] string[] textBlock2;
    private void Start()
    {
        var cell = tutorialCell.GetComponent<TutorialCell>();
        //cell.reproductionSpeed = 0;
        StartCoroutine(RunTutorial());
    }
    IEnumerator RunTutorial()
    {
        foreach (var tip in textBlock1)
        {
            nextTip = false;
            string sentence = tip;
            Debug.Log(sentence);
            tutorialText.text = sentence;
            yield return new WaitUntil(()=>nextTip);
        }
        EndTutorial();
    }
    public void ContinueTutorial()
    {
        nextTip = true;
    }
    
    public void EndTutorial()
    {

    }
    public void Update()
    {
        var cell = tutorialCell.GetComponent<TutorialCell>();
        if (cell.isSelected && isFirstTip)
        {
            arrow.SetActive(false);
            ContinueTutorial();
            isFirstTip = false;
            cell.reproductionSpeed = 1;
            isSecondTip = true;
        }
        else if (isSecondTip)
        {
            if(Mathf.Round(cell.tempDNA) == 6)
            {
                ContinueTutorial();
                isSecondTip = false;
                isThirdTip = true;
            }
        }
        else if (isThirdTip)
        {
            if(Mathf.Round(cell.tempDNA) == 12)
            {
                ContinueTutorial();
                isThirdTip = false;
                isFourthTip = true;
            }
        }
        else if (isFourthTip)
        {
            tutorialNeutralCell.SetActive(true);
            arrow.SetActive(true);
            var x = arrow.GetComponent<RectTransform>();
            x.anchorMax = new Vector2 (0.72f, 0.9f);
            x.anchorMin = new Vector2 (0.62f, 0.8f);
            if ((tutorialNeutralCell.GetComponent<TutorialCell>().currentState).ToString()=="Ally")
            {
                ContinueTutorial();
                Debug.Log("complete");
                isFifthTip = true;
                isFourthTip = false;
                arrow.SetActive(false);
            }
        }
        else if (isFifthTip)
        {
            arrowLow.SetActive(true);
            tutorialEnemyCell.SetActive(true);
            tutorialEnemyCell.GetComponent<TutorialCell>().reproductionSpeed = 0.5f;
            if (tutorialEnemyCell.GetComponent<TutorialCell>().currentState.ToString()=="Ally") 
            {
                back.SetActive(true);
                ContinueTutorial();
            }
        }
    }
}
