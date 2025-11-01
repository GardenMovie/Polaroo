using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SlotCreator : MonoBehaviour
{
    public GameObject letterSlotPrefab;
    private Transform parentTransform;

    public string word;

    private bool done = true;

    private List<GameObject> letterSlots = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        word = GameManager.Instance.selectedWord;

        parentTransform = transform;
        int wordSize = word.Length;
        for (int i = 0; i < wordSize; i++)
        {
            GameObject slot = Instantiate(letterSlotPrefab, parentTransform);
            //slot.transform.GetChild(0).GetComponent<TMP_Text>().text = inputWord[i].ToString();
            letterSlots.Add(slot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string guess = "";
        for (int i = 0; i < word.Length; i++)
        {
            GameObject slot = letterSlots[i];
            if (slot.transform.childCount > 0)
            {
                guess += letterSlots[i].transform.GetChild(0).GetComponent<TMP_Text>().text;
            }
            else
            {
                guess += "0";
            }
        }
        Color[] letterColors = GetLetterColors(word, guess);

        done = true;
        for (int i = 0; i < word.Length; i++)
        {
            GameObject slot = letterSlots[i];

            slot.GetComponent<UnityEngine.UI.Image>().color = letterColors[i];
            if (letterColors[i] != Color.green)
            {
                done = false;
            }
        }

        if (done)
        {
            DoneLetters();
            enabled = false;
        }
    }


    public GameObject LetterSlots;
    public GameObject LetterPanel;
    public GameObject FinishBtns;
    public AudioClip DoneSFX;

    void DoneLetters()
    {
        //LetterSlots.SetActive(false);
        LetterPanel.SetActive(false);
        FinishBtns.SetActive(true);
        GameManager.Instance.PlaySFX(DoneSFX);
    }

    Color[] GetLetterColors(string word, string guess)
    {
        int length = word.Length;
        Color[] result = new Color[length];
        Dictionary<char, int> letterCount = new();         // Count of each letter in the word
        Dictionary<char, int> usedCount = new();           // Count of how many times the letter was already used for green or yellow

        // Count letters in the target word
        foreach (char c in word)
        {
            if (!letterCount.ContainsKey(c))
                letterCount[c] = 0;
            letterCount[c]++;
        }

        // First pass: assign green where exact match
        for (int i = 0; i < length; i++)
        {
            char guessChar = guess[i];
            char correctChar = word[i];

            if (guessChar == '0')
            {
                result[i] = Color.grey;
                continue;
            }

            if (guessChar == correctChar)
            {
                result[i] = Color.green;

                if (!usedCount.ContainsKey(guessChar))
                    usedCount[guessChar] = 0;

                usedCount[guessChar]++;
            }
        }

        // Second pass: assign yellow or red
        for (int i = 0; i < length; i++)
        {
            if (result[i] == Color.green || result[i] == Color.grey)
                continue;

            char guessChar = guess[i];

            if (letterCount.ContainsKey(guessChar))
            {
                int used = usedCount.ContainsKey(guessChar) ? usedCount[guessChar] : 0;

                if (used < letterCount[guessChar])
                {
                    result[i] = Color.yellow;

                    if (!usedCount.ContainsKey(guessChar))
                        usedCount[guessChar] = 0;

                    usedCount[guessChar]++;
                }
                else
                {
                    result[i] = Color.red;
                }
            }
            else
            {
                result[i] = Color.red;
            }
        }

        return result;
    }

}
