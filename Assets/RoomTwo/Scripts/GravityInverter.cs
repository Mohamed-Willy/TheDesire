using UnityEngine;

public class GravityInverter : MonoBehaviour
{
    CustomGravityObject gravityController;
    [SerializeField] bool theRightTile = false;
    // Start is called before the first frame update
    void Start()
    {
        gravityController = GetComponent<CustomGravityObject>();
    }

    public void InvertGravity () {
        gravityController.customGravity = new Vector3(0, gravityController.customGravity.y * -1, 0);

        if (!theRightTile)
            return;

        if (gravityController.customGravity.y > 0)
            PuzzleOneWatcher.Instance.IncreaseRightCount();
        else
            PuzzleOneWatcher.Instance.DecreaseRightCount();
    }
}
