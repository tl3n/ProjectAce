using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ArtefactSO/Happy Theater Mask")]
public class HappyMaskArtefact : ItemsData
{
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        ArtefactFactory factory = ScriptableObject.CreateInstance<HappyMaskCreator>();
        var artefact = factory.CreateArtefact();

        //copy data from factory-created artifact to this instance
        this.Name = artefact.Name;
        this.Id = artefact.Id;
        this.Description = artefact.Description;
        this.ItemQuantity = artefact.ItemQuantity;
        this.effects = artefact.effects;
        this.icon = artefact.icon;
        this.prefab = artefact.prefab;

    }
}
