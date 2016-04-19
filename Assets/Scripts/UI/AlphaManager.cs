using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AlphaManager {

    private List<SpriteRenderer> _spriteRenderers;
    private List<Image> _images;
    private List<Text> _texts;

    public AlphaManager(GameObject go) {
        Debug.Log("SpriteRenderer");
        _spriteRenderers = new List<SpriteRenderer>();
        foreach(SpriteRenderer sr in go.GetComponentsInChildren<SpriteRenderer>()) {
            _spriteRenderers.Add(sr);
            Debug.Log(sr);
        }

        Debug.Log("Image");
        _images = new List<Image>();
        foreach(Image i in go.GetComponentsInChildren<Image>()) {
            _images.Add(i);
            Debug.Log(i);
        }

        Debug.Log("Text");
        _texts = new List<Text>();
        foreach(Text t in go.GetComponentsInChildren<Text>()) {
            _texts.Add(t);
            Debug.Log(t);
        }
    }

    public void SetAlpha(float alpha) {
        Color c;

        foreach(SpriteRenderer sr in _spriteRenderers) {
            c = sr.color;
            sr.color = new Color(c.r, c.g, c.b, alpha);
        }

        foreach(Image i in _images) {
            c = i.color;
            i.color = new Color(c.r, c.g, c.b, alpha);
        }

        foreach(Text t in _texts) {
            c = t.color;
            t.color = new Color(c.r, c.g, c.b, alpha);
        }
    }
}
