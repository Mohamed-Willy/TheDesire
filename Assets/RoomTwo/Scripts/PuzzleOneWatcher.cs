using System.Collections;
using UnityEngine;

public class PuzzleOneWatcher : MonoBehaviour
{
    public static PuzzleOneWatcher Instance;
    [SerializeField] GameObject theLights;
    [SerializeField] int rightfacesCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rightfacesCount = 0;
    }

    void Awake () {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseRightCount () {
        rightfacesCount --;
        CheckPuzzleCompleted();
    }

    public void IncreaseRightCount () {
        rightfacesCount ++;
        CheckPuzzleCompleted();
    }

    void CheckPuzzleCompleted () {
        if (rightfacesCount >= 18) {
            // End the fkin puzzle
            StartCoroutine (RemovePuzzle());
        }
    }

    IEnumerator RemovePuzzle () {
        theLights.SetActive(false);
        yield return new WaitForSeconds(2f);
        theLights.SetActive(true);
        Destroy(this.gameObject);
    }
}
