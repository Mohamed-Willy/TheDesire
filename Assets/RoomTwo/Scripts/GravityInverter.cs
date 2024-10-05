using System.Collections;
using UnityEngine;

public class GravityInverter : MonoBehaviour
{
    CustomGravityObject gravityController;
    [SerializeField] bool theRightTile = false;
    bool invertedAlready = false;
    // Start is called before the first frame update
    void Start()
    {
        gravityController = GetComponent<CustomGravityObject>();
        invertedAlready = false ;
    }

    public void InvertGravity () {
        if (invertedAlready) return;
        invertedAlready = true;
        gravityController.customGravity = new Vector3(0, gravityController.customGravity.y * -1, 0);

        if (theRightTile) {
            if (gravityController.customGravity.y > 0)
                PuzzleOneWatcher.Instance.IncreaseRightCount();
            else
                PuzzleOneWatcher.Instance.DecreaseRightCount();
        } else {
            if (gravityController.customGravity.y > 0)
                PuzzleOneWatcher.Instance.IncreaseWrongCount();
            else
                PuzzleOneWatcher.Instance.DecreaseWrongCount();
        }
        StartCoroutine(ResetInverted());
    }

    IEnumerator ResetInverted () {
        yield return new WaitForSeconds(0.5f);
        invertedAlready = false ;
    }
}
