using UnityEngine;

public class ColorFloor : MonoBehaviour
{
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void RefreshColor (GravityColor.Type current)
    {
        var db = GravityManager.Instance.database;

        var data = db.gravityColors.Find(d => d.type == current);

        if (data != null)
        {
            rend.material.color = data.color;
        }
        
    }
}
