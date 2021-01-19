using UnityEngine;

namespace Controllers {
    public class RuneMover : MonoBehaviour{
        public RectTransform _mergerSlot1, _mergerSlot2, _mergerSlot3, _mergerSlot4;


        public void MoveToMerger(GameObject rune) {
            //Check if & what slot is empty and moves Rune to here.   
            rune.GetComponent<RectTransform>().SetParent(_mergerSlot1.transform);
            rune.transform.position = new Vector3(0, 0, 0);
        }
    }
}
