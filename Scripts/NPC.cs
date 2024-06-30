/*
 * Author: Verlaine Ong
 * Date: 20/06/2024
 * Description: 
 * Contains functions for audio and text of NPC
 */
using System.Collections;
using UnityEngine;
using TMPro;

[System.Serializable]
public class NPCDialogueLine
{
    /// <summary>
    /// A string for the text line
    /// </summary>
    public string text;
    public AudioClip audioClip;
}

public class NPC : MonoBehaviour
{
    [SerializeField] private AudioSource dialogueAudioSource;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private NPCDialogueLine[] dialogueLines; // Array of dialogue lines with text and audio
    [SerializeField] private KeyCode interactKey = KeyCode.Mouse0; // Left mouse button

    /// <summary>
    /// An integer index of the current line of dialogue
    /// </summary>
    private int currentLineIndex = 0;

    /// <summary>
    /// A bool to deactivate dialogue at first
    /// </summary>
    private bool isDialogueActive = false;

    /// <summary>
    /// A bool to show dialogue not ended at first
    /// </summary>
    private bool dialogueEnded = false;

    /// <summary>
    /// A function to start dialogue when player collides with NPC
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDialogueActive && !dialogueEnded)
        {
            StartCoroutine(ShowDialogue());
        }
    }

    /// <summary>
    /// A function to show next text line when player left clicks on the mouse
    /// </summary>
    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(interactKey))
        {
            ProceedToNextLine();
        }
    }

    /// <summary>
    /// A function to start dialogue
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowDialogue()
    {
        isDialogueActive = true;
        dialogueText.gameObject.SetActive(true);
        ShowCurrentLine();
        yield return null; // Ensure the coroutine yields at least once
    }

    /// <summary>
    /// A function that handles the logic of the number of lines.
    /// </summary>
    private void ShowCurrentLine()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex].text;
            dialogueAudioSource.clip = dialogueLines[currentLineIndex].audioClip;
            dialogueAudioSource.Play();
        }
        else
        {
            EndDialogue();
        }
    }

    /// <summary>
    /// A function to increment lines and show the next one
    /// </summary>
    private void ProceedToNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            ShowCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    /// <summary>
    /// A function to end dialogue and destroy NPC.
    /// </summary>
    private void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        dialogueEnded = true;
        isDialogueActive = false;

        if (gameObject.CompareTag("npc"))
        {
            Destroy(gameObject);
        }
    }
}