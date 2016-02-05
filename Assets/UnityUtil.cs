using UnityEngine;

namespace MyUnitResources
{
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


        /// <summary>
        /// Wait for the time defined in the method
        /// </summary>
        /// <param name="timeInSeconds"> The time that the method will be in wait state </param>
        /// <returns>Returns true when the waiting time is over</returns> 
        public static bool WaitForWhile(ref float counter,float timeInSeconds)
        {
           
            if (counter < timeInSeconds)
            {
                counter += Time.deltaTime;
                return false;
            }
            else
            {
                return true;
            }

        }

    }

}



