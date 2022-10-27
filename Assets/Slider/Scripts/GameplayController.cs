using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Beats
{
    public class GameplayController : MonoBehaviour
    {
        
        [Header ("Input")]
        [SerializeField] KeyCode _left;
        [SerializeField] KeyCode _down;
        [SerializeField] KeyCode _up;
        [SerializeField] KeyCode _right;



        [Header ("Track")]
        [Tooltip ("Beats Track to play")]
        [SerializeField] Track _track;

        /// <summary>
        /// The current Track.
        /// </summary>
        public Track track { get { return _track; } }

        public float beatsPerSecond { get; private set; }

        public float secondsPerBeat { get; private set; }

        //Animator animator;

        bool _played;
        bool _completed;
        public bool isCheering;
        public bool isBooing;
        public int scoreCount;
        public GameObject button;
        public GameObject scoreCounter;
        
        TrackView _trackView;

        WaitForSeconds waitAndStop;

        static GameplayController _instance;

        public static GameplayController Instance 
        {
            
            get
            {
                if (_instance == null)
                {
                    _instance = (GameplayController)GameObject.FindObjectOfType (typeof(GameplayController));
                }
                return _instance;
            }
            set 
            {
                _instance = value;
            }
        }


        #region MonoBehaviour Methods
        
        
        void Awake ()
        {
            _instance = this;
            _trackView = FindObjectOfType<TrackView> ();
            if (!_trackView)
                Debug.Log ("No TrackView found in current scene");

            beatsPerSecond = track.bpm / 60f;
            secondsPerBeat = 60f / track.bpm;

            waitAndStop = new WaitForSeconds (secondsPerBeat * 2);
        }

        void OnDestroy()
        {
            _instance = null;
        }

        void Start ()
        {
            button.gameObject.SetActive(false);
            print(scoreCount);      
            isCheering =false;
            isBooing=false;            
            InvokeRepeating("NextBeat", 0f, secondsPerBeat);
        }

        public void Update ()
        {
            scoreCounter.GetComponent<Text>().text = scoreCount +" Points";
            

            if (_played || _completed) {
                return;
            }

            if (Input.GetKeyDown (_left)){
                
                PlayBeat (0);}
                
            if (Input.GetKeyDown (_down)){
                
                
                PlayBeat (1);}
                
            if (Input.GetKeyDown (_up)){
                
                PlayBeat (2);}
            
            if (Input.GetKeyDown (_right)){
                 PlayBeat (3);}
               
        }

        #endregion

        #region Gameplay

        private int _current;

        public int current {
            get {
                return _current;
            }
            set {
                _current = value;

                if (_current == _track.beats.Count)
                {
                    CancelInvoke ("NextBeat");
                    _completed = true;
                    StartCoroutine (WaitAndStop());
                    
                    if(scoreCount >= 9000)
                    {
                        isCheering= true;
                        Debug.Log("cheer");
                        button.gameObject.SetActive(true);
                    }
                    if(scoreCount < 9000)
                    {
                        isBooing=true;
                        Debug.Log("boo");
                        button.gameObject.SetActive(true);
                    }
                }
            }
        }
        public void ButtonAppear()
        {
            SceneManager.LoadScene("DifficultyScreen");
        }
        void PlayBeat (int input)
        {
                //Debug.Log (input);
            _played = true;
            if (_track.beats [current] == -1)
            {
                scoreCount -= 50;
                //Debug.Log (string.Format ("{0} played untimely", input));
            }
            else if (_track.beats [current] == input)
            {
               // Debug.Log (string.Format ("{0} played right", input));
               scoreCount += 100;
                _trackView.TriggerBeatView (current, TrackView.Trigger.Right);
            }
            else
            {
                scoreCount -= 100;
               // Debug.Log (string.Format ("{0} played, {1} expected", input, _track.beats [current]));
                _trackView.TriggerBeatView (current, TrackView.Trigger.Wrong);
            }
        }

        void NextBeat ()
        {
            //Debug.Log ("Tick");
            if (!_played && _track.beats [current] != -1) {
                scoreCount -= 100;
                //Debug.Log (string.Format ("{0} missed", _track.beats [current]));
                _trackView.TriggerBeatView (current, TrackView.Trigger.Missed);
            }
            _played = false;
            current++;
        }

        private IEnumerator WaitAndStop()
        {
            yield return waitAndStop;
            enabled = false;
        }

        #endregion
    }
}