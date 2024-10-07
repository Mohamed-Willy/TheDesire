using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalClosingCamera : MonoBehaviour
{
    [SerializeField] List<GameObject> toEnable;
    [SerializeField] List<GameObject> toDisable;

    private void Start () {
        foreach (GameObject obj in toEnable) {
            obj.SetActive(false);
        }
        foreach (GameObject obj in toDisable) {
            obj.SetActive(true);
        }

        AudioManager.Instance.soundSource.clip = AudioManager.Instance.closingSceneSound;

        StartCoroutine(DisableAndEnable());
    }
    IEnumerator DisableAndEnable () {
        Debug.Log("Called");
        yield return new WaitForSeconds(10.9f);
        Debug.Log("Called Again");
        foreach (GameObject obj in toEnable) {
            obj.SetActive(true);
        }
        foreach (GameObject obj in toDisable) {
            obj.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
