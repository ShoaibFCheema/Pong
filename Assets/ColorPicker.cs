using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
public class ColorPicker : MonoBehaviour
{
    public static ColorPicker instance;
    public GameObject leftPaddle;
    public GameObject Ball;
    public GameObject rightPaddle;
    public GameObject selected;
    public GameObject canvas;

    public InputField left;
    public InputField right;

    public Image leftImage;
    public Image rightImage;
    public Image ballImage;
    public Image selectedImage;

    public Slider red;
    public Slider blue;
    public Slider green;

    private void Awake()
    {
        instance = this;
    }

    public void onLeftPaddle()
    {
        selected = leftPaddle;
        selectedImage = leftImage;
    }

    public void onRightPaddle()
    {
        selected = rightPaddle;
        selectedImage = rightImage;
    }

    public void onBall()
    {
        selected = Ball;
        selectedImage = ballImage;
    }

    public void onColorPicked()
    {
        if (selected != null)
        {
            Color color = selected.GetComponent<SpriteShapeRenderer>().color;
            color.r = red.value;
            color.b = blue.value;
            color.g = green.value;
            selected.GetComponent<SpriteShapeRenderer>().color = color;
            selectedImage.GetComponent<Image>().color = color;
        }
    }

    public void onBack()
    {
        canvas.SetActive(false);
    }

    public void onLeftNameChanged()
    {
        BallMovement.instance.leftName = left.textComponent.text;
    }

    public void onRightNameChanged()
    {
        BallMovement.instance.rightName = right.textComponent.text;
    }
}
