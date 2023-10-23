using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundController : MonoBehaviour
{
    [Header("GameObject References")]
    [SerializeField] private AudioSource soundTrigger;
    [SerializeField] private GameObject displayText;
    [SerializeField] private TextMeshProUGUI textDisplay;

    public void OnTriggerEnter(Collider other)
    {
        // play sound
        soundTrigger.Play();

        // activate UI subtitles
        if (other.gameObject.CompareTag("Player"))
        {
            displayText.SetActive(true);
            StartCoroutine(FadeOut());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        displayText.SetActive(false);
    }

    private IEnumerator FadeOut()
    {
        float duration = 10f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            textDisplay.color = new Color(textDisplay.color.r, textDisplay.color.g, textDisplay.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
