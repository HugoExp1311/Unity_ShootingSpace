
using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEditor;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    public class SequencerCommandBloodCellReward : SequencerCommand
    { // Rename to SequencerCommand<YourCommand>
    GameObject shieldUp;

        public void Awake()
        {
            // Add your initialization code here. You can use the GetParameter***() and GetSubject()
            // functions to get information from the command's parameters. You can also use the
            // Sequencer property to access the SequencerCamera, CameraAngle, Speaker, Listener,
            // SubtitleEndTime, and other properties on the sequencer. If IsAudioMuted() is true, 
            // the player has muted audio.
            //
            // If your sequencer command only does something immediately and then finishes,
            // you can call Stop() here and remove the Update() method:
            //
            // Stop();
            //
            // If you want to use a coroutine, use a Start() method in place of or in addition to
            // this method.
        }

public void Start() {
    shieldUp = Resources.Load<GameObject>("Prefabs/ShieldUp");
    if (shieldUp != null)
        {
            // Instantiate the loaded prefab
            Instantiate(shieldUp, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Shield Prefab not found!");
        }
     //Stop();
}
        public void Update()
        {
            // Add any update code here. When the command is done, call Stop().
            // If you've called stop above in Awake(), you can delete this method.
           
        }

        public void OnDestroy()
        {
            // Add your finalization code here. This is critical. If the sequence is cancelled and this
            // command is marked as "required", then only Awake() and OnDestroy() will be called.
            // Use it to clean up whatever needs cleaning at the end of the sequencer command.
            // If you don't need to do anything at the end, you can delete this method.
        }

    }

}


/**/
