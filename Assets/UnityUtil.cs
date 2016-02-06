using System.Collections;
using UnityEngine;

namespace MyUnitResources
{



    public class WaitForWhile
    {
        public bool Flag { get; private set; }
        public float Time { get; private set; }

        public IEnumerator Wait()
        {
            Flag = false;
            yield return new WaitForSeconds(Time);
            Flag = true;

        }

        public WaitForWhile(float time)
        {
            this.Time = time;
            this.Flag = false;
        }


    }


    static class UnityUtil
    {




        /// <summary>
        /// Quit Unity Editor (if in editor) or game
        /// </summary>
        public static void Quit()
        {
            //If we are running in a standalone build of the game
#if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
#endif

            //If we are running in the editor
#if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }


        /*        /// <summary>
                /// Wait for the time defined in the method
                /// </summary>
                /// <param name="timeInSeconds"> The time that the method will be in wait state </param>
                /// <returns>Returns true when the waiting time is over</returns> 
                public static void WaitForWhile(float timeInSeconds)
                {
                    float counter = 0f;
                    while (counter < timeInSeconds)
                    {
                        counter += Time.deltaTime;

                    }

                }*/

        public static void Wait(float sec)
        {
            float counter = 0;
            while (counter < sec)
            {
                counter += Time.deltaTime;
            }
        }

    }



}



