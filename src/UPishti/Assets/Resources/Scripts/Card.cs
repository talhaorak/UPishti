using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

    Material frontMaterial;
    Game game;
    int shape = 0;
    int number = 0;
    Vector2 textureScale = new Vector2(0.076923f, 0.25f);
    //public Vector2 textureOffset = new Vector2(0.03939f, 0.02666f);
    Vector2 textureOffset = new Vector2(0, 0);

    public enum Shapes
    {
        Spade,
        Club,
        Heart,
        Diamond        
    }
    void Awake()
    {
        frontMaterial = transform.FindChild("Front").gameObject.GetComponent<Renderer>().material;
        game = GameObject.Find("Game").GetComponent<Game>();
    }
	void Start () {             
	}
	
	// Update is called once per frame
	void Update () {
        //    transform.Rotate(Vector3.forward, 1); 
        AdjustTiling();
	}

    public void SetCard(Shapes sshape, int snumber)
    {
        SetCard((int)sshape, snumber);        
    }

    public void SetCard(int sshape, int snumber)
    {
        shape = sshape;
        number = snumber;
        AdjustTiling();
    }

    public void AdjustTiling()
    {
        //   Vector2 toffset = new Vector2(game.textureOffset.x /2 + (game.textureOffset.x/2 + game.textureScale.x) * number, game.textureOffset.y + game.textureScale.y * shape);
        Vector2 toffset = new Vector2((textureOffset.x + textureScale.x)*number, (textureOffset.y + textureScale.y) * shape);
        frontMaterial.mainTextureOffset = toffset; //new Vector2(0.006f, 0.012f);
        frontMaterial.mainTextureScale = textureScale;
    }
}
