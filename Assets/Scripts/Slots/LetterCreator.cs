using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LetterCreator : MonoBehaviour
{
    public GameObject LetterSinglePrefab;
    private Transform parentTransform;

    public string word;
    private string abc = "abcdefghijklmnopqrstuvwxyz";
    public int numLetters;

    private List<GameObject> letterSingles = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        word = GameManager.Instance.selectedWord;
        abc = abc.ToUpper();

        parentTransform = transform;
        
        int wordSize = word.Length;
        for (int i = 0; i < numLetters; i++)
        {
            GameObject slot = Instantiate(LetterSinglePrefab, parentTransform);
            if (i >= wordSize)
            {
                slot.transform.GetComponent<TMP_Text>().text = abc[Random.Range(0, abc.Length)].ToString();
            }
            else
            {
                slot.transform.GetComponent<TMP_Text>().text = word[i].ToString();
            }
            letterSingles.Add(slot);
        }
        gameObject.GetComponent<Scrambler>().Scramble();
    }

}

