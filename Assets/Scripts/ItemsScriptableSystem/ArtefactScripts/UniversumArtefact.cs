using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ArtefactSO/Universum")]
public class UniversumArtefact : ItemsData
{
    
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        ArtefactFactory factory = ScriptableObject.CreateInstance<UniversumCreator>();
        var artifact = factory.CreateArtefact();

        //copy data from factory-created artifact to this instance
        this.Name = artifact.Name;
        this.Description = artifact.Description;
        this.ItemQuantity = artifact.ItemQuantity;
        this.effects = artifact.effects;
        this.icon = artifact.icon;
        this.prefab = artifact.prefab;

    }
}