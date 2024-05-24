using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Black Cat")]
public class BlackCatCreator : ArtefactFactory
{
    public override ItemsData CreateArtifact()
    {
        var healingBoost = new HealingEffect(10);
        var speedBoost = new SpeedEffect(1.5f);
        var compositeEffect = new CompositeEffect(new List<EffectsInterface> { healingBoost, speedBoost });
       
        //add icon and quantity
        ItemsData BlackCat = ScriptableObject.CreateInstance<ItemsData>();
        BlackCat.Name = "Black Cat";
        BlackCat.ItemQuantity = 1;
        BlackCat.Description = "Heals immediately and gives speed boost";
        BlackCat.effects = compositeEffect;


        //BlackCat.icon = Resources.Load<Sprite>("Path/To/Your/Sprite");
        return BlackCat;
    }
}
