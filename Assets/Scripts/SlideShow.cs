 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 
 public class SlideShow : MonoBehaviour
 {
     public Sprite[] slides = new Sprite[4];
	 public SpriteRenderer image;
     public Button nextButton;
	 public Button prevButton;
     private int currentSlide = 0;
     private float timeSinceLast = 1.0f;
     
     void Start()
     {		 
		nextButton.onClick.AddListener(nextSlide);
		prevButton.onClick.AddListener(prevSlide);
     }
     
     void Update()
     {
		 if (currentSlide >= slides.Length || currentSlide < 0)
        {
            currentSlide = 0;
        }
		 
		if (Input.GetKeyDown(KeyCode.Space) && currentSlide < slides.Length){
            currentSlide++;
        }
		if(currentSlide == 0){
			prevButton.gameObject.SetActive(false);
		} else if (!prevButton.gameObject.activeInHierarchy){
			prevButton.gameObject.SetActive(true);
		}
		
		if(currentSlide == slides.Length-1){
			nextButton.gameObject.SetActive(false);
		} else if (!nextButton.gameObject.activeInHierarchy){
			nextButton.gameObject.SetActive(true);
		}
		 image.sprite = slides[currentSlide];
		 //Debug.Log(currentSlide);
     }
	 
	 void nextSlide(){
		 currentSlide++;
	 }
	 
	 void prevSlide(){
		 currentSlide--;
	 }
 }