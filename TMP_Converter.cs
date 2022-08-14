using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

namespace TG.UI
{
    [ExecuteInEditMode]
    public class TMP_Converter : MonoBehaviour
    {
        Text uText;
        TextMeshProUGUI nTextData;
        TextMeshProUGUI nText;
        TMP_Converter converter;
        bool update = false;
        TextWrapper textWrapper;
        
        private void Awake()
        {
            if (!update && (gameObject.GetComponent<TextMeshProUGUI>() == null))
            {
                uText = GetComponent<Text>();
                getOldData();
                DestroyImmediate(uText);
                nText = this.gameObject.AddComponent<TextMeshProUGUI>() as TextMeshProUGUI;
                update = true;
                converter = this;
            }
            else
            {
                update = false;
            }
            if (gameObject.GetComponent<TextWrapper>() == null)
            {
                textWrapper = this.gameObject.AddComponent<TextWrapper>() as TextWrapper;
            }
            else
            {
                textWrapper = GetComponent<TextWrapper>();
            }
        }
        
        private void Start()
        {
            if (!update && nTextData != null)
                return;
            //nTextData.text = uText.text;
            //nTextData.fontSize = uText.fontSize;
            //nTextData.lineSpacing = uText.lineSpacing;
            //nTextData.color = uText.color;
            nText.text = nTextData.text;
            nText.fontSize = nTextData.fontSize;
            nText.lineSpacing = nTextData.lineSpacing;
            nText.color = nTextData.color;
            nTextData = null;
            textWrapper.enabled = true;
            //nText.enabled = true;
            //uText.enabled = false;
            textWrapper.unityText = null;
            //textWrapper.textMeshText = nText;
            DestroyImmediate(this.GetComponent<TMP_Converter>());
        
        }
        
        
        void getOldData()
        {
            nTextData = new TextMeshProUGUI();
            nTextData.text = uText.text;
            nTextData.fontSize = uText.fontSize;
            nTextData.lineSpacing = uText.lineSpacing;
            nTextData.color = uText.color;
        }

    }

}
