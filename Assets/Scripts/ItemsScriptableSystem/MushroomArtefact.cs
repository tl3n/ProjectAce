using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mushroom")]

public class MushroomArtefact : ItemsData
{
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        ArtefactFactory factory = ScriptableObject.CreateInstance<MushroomCreator>();
        var artifact = factory.CreateArtifact();

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
