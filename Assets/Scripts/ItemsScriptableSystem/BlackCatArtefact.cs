using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Black Cat")]
public class BlackCatArtefact : ItemsData
{
    

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        //creating artefact with factory method
        ArtefactFactory factory = new BlackCatCreator();
        var artifact = factory.CreateArtifact();
    }

    
}
