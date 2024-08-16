using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance;

    public ResourceQuant[] resources;

    private void Awake()
    {
        Instance = this;
    }

    public ResourceQuant GetResource(Resource resourceToGet)
    {
        foreach (ResourceQuant resource in resources)
        {
            if (resource.resource.type == resourceToGet.type)
            {
                return resource;
            }
        }

        return null;
    }
}
