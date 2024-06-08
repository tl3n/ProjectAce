using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ArtefactSO/Black Cat")]
public class BlackCatArtefact : ItemsData
{
    
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        ArtefactFactory factory = ScriptableObject.CreateInstance<BlackCatCreator>();
        var artifact = factory.CreateArtefact();

        //copy data from factory-created artifact to this instance
        this.Name = artifact.Name;
        this.Id = artifact.Id;
        this.Description = artifact.Description;
        this.ItemQuantity = artifact.ItemQuantity;
        this.effects = artifact.effects;
        this.icon = artifact.icon;
        this.prefab = artifact.prefab;

    }
}
