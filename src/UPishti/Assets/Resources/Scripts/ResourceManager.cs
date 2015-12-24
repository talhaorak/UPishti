using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager {

    static ResourceManager instance = null;
    public static ResourceManager Instance
    {
        get
        {
            if (instance == null) instance = new ResourceManager();
            return instance;
        }
    }

    Dictionary<string, UnityEngine.Object> resources;
    ResourceManager()
    {
        resources = new Dictionary<string, Object>();

        resources["deck"] = Resources.Load<Texture2D>("Textures/deck_full2");
        /*
        Sprite[] cardSprites = Resources.LoadAll<Sprite>("Textures");
        foreach(Sprite sprite in cardSprites)
        {
            resources[sprite.name] = sprite.texture;
        } 
        */       
    }

    public UnityEngine.Object Get(string name)
    {
        return resources[name];
    }    
}
