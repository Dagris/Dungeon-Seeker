﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class EnemyTarget : MonoBehaviour
    {
        public int index;
        public List<Transform> targets = new List<Transform>();
        public List<HumanBodyBones> h_bones = new List<HumanBodyBones>();

        Animator anim;

        void Start()
        {
            anim = GetComponentInChildren<Animator>();
            if(anim.isHuman == false)
            {
                return;
            }

            for (int i = 0; i < h_bones.Count; i++)
            {
                targets.Add(anim.GetBoneTransform(h_bones[i]));
            }
        }

        public Transform GetTarget(bool negative = false)
        {
            if(targets.Count == 0)
            {
                return transform;
            }

            int targetIndex = index;

            if(negative == false)
            {
                if (index < targets.Count - 1)
                {
                    index++;
                }
                else
                {
                    index = 0;
                    targetIndex = 0;
                }
            }
            else
            {
                if(index < 0 )
                {
                    index = targets.Count - 1;
                    targetIndex = targets.Count - 1;
                }
                else
                {
                    index--;
                }
            }
            
            return targets[index];
        }
    }

}

