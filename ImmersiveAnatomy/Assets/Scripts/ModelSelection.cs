using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [ExecuteAlways]
    public class ModelSelection : MonoBehaviour
    {
        [Header("Body")]
        public ModelGender gender;
        //public Anim anim;

        [Header("Anatomy")]
        public bool skin = false;
        public bool muscular = false;
        public bool skeletal = false;
        public bool nervous = false;
        public bool circulatory = false;
        public bool lymphatic = false;
        public bool digestive = false;
        public bool respiratory = false;
        public bool urinary = false;
        //public bool hair = true;
        //public bool eyes = true;
        //public bool brain = false;

        [Header("Connections")]
        public BodyPartSelection male;
        public BodyPartSelection female;

        //[Header("Animations")]
        //public RuntimeAnimatorController idle;
        //public RuntimeAnimatorController walk;
        //public RuntimeAnimatorController run;
        //public RuntimeAnimatorController jump;
        //public RuntimeAnimatorController ik;

       // private readonly Dictionary<Anim, RuntimeAnimatorController> animMapping = new();


        // State
        private BodyPartSelection currentBody;
        private ModelGender? currentGender = null;
        //private Anim? currentAnim = null;

        // Start is called before the first frame update
        //void Start()
        //{
        //    animMapping.Clear();
        //    animMapping.Add(Anim.idle, idle);
        //    animMapping.Add(Anim.walk, walk);
        //   animMapping.Add(Anim.run, run);
        //    animMapping.Add(Anim.jump, jump);
        //    animMapping.Add(Anim.ik, ik);
        //}

        // Update is called once per frame
        void Update()
        {
            if (currentGender != gender) SetGender();
            //if (currentAnim != anim) SetAnimation();
            SetAnatomy();
        }

        void SetGender()
        {
            if (gender == ModelGender.male)
            {
                male.gameObject.SetActive(true);
                female.gameObject.SetActive(false);
                currentBody = male;
            }
            else
            {
                male.gameObject.SetActive(false);
                female.gameObject.SetActive(true);
                currentBody = female;
            }
            currentGender = gender;
            // SetAnimation();
        }

        // void SetAnimation()
        // {
        //     if (animMapping.ContainsKey(anim))
        //     {
        //         currentBody.GetComponent<Animator>().runtimeAnimatorController = animMapping[anim];
        //     }
        //     else if (anim == Anim.none)
        //     {
        //         currentBody.GetComponent<Animator>().runtimeAnimatorController = null;
        //     }
        //     currentAnim = anim;
        // }

        void SetAnatomy()
        {
            currentBody.skin = skin;
            currentBody.circulatory = circulatory;
            currentBody.digestive = digestive;
            currentBody.lymphatic = lymphatic;
            currentBody.muscular = muscular;
            currentBody.nervous = nervous;
            currentBody.respiratory = respiratory;
            currentBody.urinary = urinary;
            currentBody.skeletal = skeletal;
            // currentBody.hair = hair;
            // currentBody.eyes = eyes;
            // currentBody.brain = brain;
        }
    }

    public enum ModelGender
    {
        male,
        female
    }

    // public enum Anim
    // {
    //     none,
    //     idle,
    //     walk,
    //     run,
    //     jump,
    //     ik,
    // }