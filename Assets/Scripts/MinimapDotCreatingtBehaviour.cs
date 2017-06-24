using UnityEngine;

public class MinimapDotCreatingtBehaviour : MonoBehaviour 
{
    public Color dotColor = Color.white;
    public GameObject target;
    public GameObject dotGO;

	void Start () 
    {
        if(target == null)
        {
            target = gameObject;
        }

        var dotPrefab = Resources.Load("Prefabs/Minimap Dot", typeof(GameObject)) as GameObject;
        dotGO = Instantiate(dotPrefab);
        dotGO.name = string.Format("{0} - {1}", dotPrefab.name, target.name);

        dotGO.GetComponent<SpriteRenderer>().color = dotColor;
        dotGO.GetComponent<FollowBehaviour>().target = gameObject;
	}
}
